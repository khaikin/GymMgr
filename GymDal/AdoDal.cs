using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GymDal
{
    public class AdoDal
    {
        public static event EventHandler<LoginEvent> OnLogin;

        string _connectionString;
        public AdoDal(string connectionString)
        {
            _connectionString = connectionString;
        }


        public AdoDal()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        }

        public DataTable GetListOfCustomers()
        {
            var dt = new DataTable();
            var lst = new List<Customer>();

            using (var con = new SqlConnection(_connectionString))
            {
                using (var data = new SqlDataAdapter("select * from Customers", con))
                {
                    data.Fill(dt);
                }

                if (dt.Rows.Count == 0)
                    return dt;

                AddSubscriptionToCustomerDt(dt);

            }

            return dt;


        }

        private void AddSubscriptionToCustomerDt(DataTable dt)
        {


            dt.Columns.Add(new DataColumn("SubscriptionTo"));

            foreach (DataRow row in dt.Rows)
            {
                var pay = GetPaymentsPerCustomer((int)row["id"]);
                DateTime max = DateTime.MinValue;
                if (pay.Rows.Count > 0)
                    max = pay.AsEnumerable().Cast<DataRow>().Max(r => r.Field<DateTime>("To"));
                row["SubscriptionTo"] = max.ToShortDateString();
            }

        }


        public DataTable GetCustomer(int id)
        {
            var dt = new DataTable();
            var lst = new List<Customer>();

            using (var con = new SqlConnection(_connectionString))
            {
                using (var data = new SqlDataAdapter("select * from Customers where id=" + id, con))
                {
                    data.Fill(dt);
                }
            }
            AddSubscriptionToCustomerDt(dt);
            return dt;


        }

        public void DeleteCustomer(int id)
        {
            using (var con = new SqlConnection(_connectionString))
            using (var comm = new SqlCommand("DeleteCustomer", con) { CommandType = CommandType.StoredProcedure })
            {
                comm.Parameters.Add(new SqlParameter("@customerId", id));
                con.Open();
                comm.ExecuteNonQuery();
            }
        }

        public void AddLogin(int id)
        {
            if (id == 0)
            {
                if (OnLogin != null)
                    OnLogin(this, new LoginEvent { Name = "שגיאת מערכת!!!. ", SubscriptionTill = DateTime.MinValue, IsObligor = true });
                return;

            }

            using (var con = new SqlConnection(_connectionString))
            using (var comm = new SqlCommand("LoginByCustomerId", con) { CommandType = CommandType.StoredProcedure })
            {
                comm.Parameters.Add(new SqlParameter("@customerId", id));
                con.Open();
                comm.ExecuteNonQuery();
            }

            var cust = GetCustomer(id);
            if (cust.Rows.Count == 0)
            {
                if (OnLogin != null)
                    OnLogin(this, new LoginEvent { Name = "מנוי לא קיים", SubscriptionTill = DateTime.MinValue, IsObligor = true });
                return;
            }

            var name = cust.Rows[0]["FirstName"].ToString().Trim() + " " + cust.Rows[0]["LastName"].ToString().Trim();

            var pay = GetPaymentsPerCustomer(id);
            DateTime max = DateTime.MinValue;
            if (pay.Rows.Count > 0)
                max = pay.AsEnumerable().Cast<DataRow>().Max(r => r.Field<DateTime>("To"));


            if (OnLogin != null)
                OnLogin(this, new LoginEvent { Name = name, SubscriptionTill = max, IsObligor = (DateTime.Now > max) });
        }

        public void AddOrUpdateCustomer(DataRow customer)
        {
            string str = "";

            if (string.IsNullOrEmpty(customer["id"].ToString()) || customer["id"].ToString() == "0")
                str = " INSERT INTO [dbo].[Customers] " +
                        "            ([FirstName] " +
                        "            ,[LastName]" +
                        "            ,[IdentificationNumber]" +
                        "            ,[BirthDate]" +
                        "            ,[Email]" +
                        "            ,[Address]" +
                        "            ,[CreationTimeStamp]" +
                        "            ,[Active]" +
                        "            ,[CardSN]" +
                        "            ,[Phone]" +
                        "            )" +
                        "      VALUES" +
                        "            (N'{0}'" +
                        "            ,N'{1}'" +
                        "            ,{2}" +
                        "            ,'{3}'" +
                        "            ,N'{4}'" +
                        "            ,N'{5}'" +
                        "            ,'{6}'" +
                        "            ,'{7}'" +
                        "            ,'{9}'" +
                        "            ,'{10}'" +
                        "            )";



            else
                str = "UPDATE [dbo].[Customers] " +
                           "   SET [FirstName] = N'{0}'" +
                           "      ,[LastName] = N'{1}'" +
                           "      ,[IdentificationNumber] = '{2}'" +
                           "      ,[BirthDate] = '{3}'" +
                           "      ,[Email] = N'{4}'" +
                           "      ,[Address] = N'{5}'" +
                           "      ,[CreationTimeStamp] = '{6}'" +
                           "      ,[Active] = '{7}'" +
                           "      ,[WorkoutProgram_Id] = {8}" +
                           "      ,[CardSN] = '{9}'" +
                           "      ,[Phone] = '{10}'" +
                           " WHERE id=" + customer["id"];

            var cul = new CultureInfo("en-US");
            var query = string.Format(str,
                 customer["FirstName"],
                 customer["LastName"],
                 customer["IdentificationNumber"],
                // customer["BirthDate"],
                 DateTime.Parse(customer["BirthDate"].ToString()).ToString(cul),
                 customer["Email"],
                 customer["Address"],
                //customer["CreationTimeStamp"],
                  DateTime.Parse(customer["CreationTimeStamp"].ToString()).ToString(cul),
                 customer["Active"].ToString().ToLower() == "true" ? "1" : "0",
                 string.IsNullOrEmpty(customer["WorkoutProgram_Id"].ToString()) ? "NULL" : customer["WorkoutProgram_Id"].ToString(),
                 customer["CardSN"],
                 customer["Phone"]
                );

            using (var con = new SqlConnection(_connectionString))
            using (var comm = new SqlCommand(query, con))
            {
                con.Open();
                comm.ExecuteNonQuery();
            }


        }

        public DataTable GetPaymentsPerCustomer(int customerId)
        {
            var dt = new DataTable();

            using (var con = new SqlConnection(_connectionString))
            {
                using (var data = new SqlDataAdapter("select * from Payments where Customer_id =" + customerId, con))
                {
                    data.Fill(dt);
                }
            }

            return dt;
        }

        public void AddSubscription(int CurrentCustomerId, double Amount, string Comments, DateTime From, DateTime To)
        {
            using (var con = new SqlConnection(_connectionString))
            using (var comm = new SqlCommand("AddPayment", con) { CommandType = CommandType.StoredProcedure })
            {
                comm.Parameters.Add(new SqlParameter("@customerId", CurrentCustomerId));
                comm.Parameters.Add(new SqlParameter("@amount", Amount));
                comm.Parameters.Add(new SqlParameter("@comment", Comments));
                comm.Parameters.Add(new SqlParameter("@from", From));
                comm.Parameters.Add(new SqlParameter("@to", To));
                con.Open();
                comm.ExecuteNonQuery();
            }
        }

        public void AddOrUpdateExercise(int? id, string image, string name)
        {
            using (var con = new SqlConnection(_connectionString))
            using (var comm = new SqlCommand("AddOrUpdateExercise", con) { CommandType = CommandType.StoredProcedure })
            {

                SqlParameter idp = new SqlParameter("@id", SqlDbType.Int);
                idp.Value = (object)id ?? DBNull.Value;


                comm.Parameters.Add(new SqlParameter("@image", image));
                comm.Parameters.Add(new SqlParameter("@name", name));
                comm.Parameters.Add(idp);
                con.Open();
                comm.ExecuteNonQuery();
            }
        }

        public DataTable GetExercises()
        {
            var dt = new DataTable();

            using (var con = new SqlConnection(_connectionString))
            {
                using (var data = new SqlDataAdapter("select * from WorkoutExercises ", con))
                {
                    data.Fill(dt);
                }
            }

            return dt;
        }

        public void DeleteExrcise(int id)
        {
            using (var con = new SqlConnection(_connectionString))
            using (var comm = new SqlCommand("DeleteExercise", con) { CommandType = CommandType.StoredProcedure })
            {
                comm.Parameters.Add(new SqlParameter("@id", id));
                con.Open();
                comm.ExecuteNonQuery();
            }
        }

        public DataTable GetExercises(int id)
        {
            var dt = new DataTable();

            using (var con = new SqlConnection(_connectionString))
            {
                using (var data = new SqlDataAdapter("select * from WorkoutExercises where id = " + id, con))
                {
                    data.Fill(dt);
                }
            }

            return dt;
        }

        public DataTable GetWorkouts()
        {
            var dt = new DataTable();

            using (var con = new SqlConnection(_connectionString))
            {
                using (var data = new SqlDataAdapter("select * from Workouts ", con))
                {
                    data.Fill(dt);
                }
            }

            return dt;
        }

        public DataTable GetPrograms()
        {

            var dt = new DataTable();

            using (var con = new SqlConnection(_connectionString))
            {
                using (var data = new SqlDataAdapter("select * from WorkoutPrograms ", con))
                {
                    data.Fill(dt);
                }
            }

            return dt;
        }

        public object GetWorkouts(int programId)
        {
            var dt = new DataTable();

            using (var con = new SqlConnection(_connectionString))
            {
                using (var data = new SqlDataAdapter("select * from view_Workouts where WorkoutPrograms_Id=  " + programId, con))
                {
                    data.Fill(dt);
                }
            }

            return dt;
        }

        public void AddOrUpdateProgram(int? id, string name)
        {
            using (var con = new SqlConnection(_connectionString))
            using (var comm = new SqlCommand("AddOrUpdateProgram", con) { CommandType = CommandType.StoredProcedure })
            {
                SqlParameter idp = new SqlParameter("@id", SqlDbType.Int);
                idp.Value = (object)id ?? DBNull.Value;

                comm.Parameters.Add(idp);
                comm.Parameters.Add(new SqlParameter("@name", name));

                con.Open();
                comm.ExecuteNonQuery();
            }
        }

        public void DeleteProgram(int id)
        {
            using (var con = new SqlConnection(_connectionString))
            using (var comm = new SqlCommand("DeleteExercise", con) { CommandType = CommandType.StoredProcedure })
            {
                comm.Parameters.Add(new SqlParameter("@id", id));
                con.Open();
                comm.ExecuteNonQuery();
            }
        }

        public void AddOrUpdateWorkout(DataRow row)
        {
            //using (var con = new SqlConnection(_connectionString))
            //using (var comm = new SqlCommand("AddOrUpdateWorkout", con) { CommandType = CommandType.StoredProcedure })
            //{


            //    comm.Parameters.Add(new SqlParameter("@id", row["id"]));
            //    comm.Parameters.Add(new SqlParameter("@sets",row["Sets"] ));
            //    comm.Parameters.Add(new SqlParameter("@repetitions", row["Repetitions"]));
            //    comm.Parameters.Add(new SqlParameter("@WorkoutExercise_Id", row["WorkoutExercise_Id"]));
            //    comm.Parameters.Add(new SqlParameter("@WorkoutPrograms_Id", row["WorkoutPrograms_Id"]));
            //    con.Open();
            //    comm.ExecuteNonQuery();
            //}

            AddOrUpdateWorkout((int)row["id"], (int)row["Sets"], (int)row["Repetitions"], (int)row["WorkoutExercise_Id"], (int)row["WorkoutPrograms_Id"]);

        }

        public void AddOrUpdateWorkout(int? id, int sets, int repetiotions, int exercise, int program)
        {
            using (var con = new SqlConnection(_connectionString))
            using (var comm = new SqlCommand("AddOrUpdateWorkout", con) { CommandType = CommandType.StoredProcedure })
            {
                SqlParameter idp = new SqlParameter("@id", SqlDbType.Int);
                idp.Value = (object)id ?? DBNull.Value;

                comm.Parameters.Add(idp);
                comm.Parameters.Add(new SqlParameter("@sets", sets));
                comm.Parameters.Add(new SqlParameter("@repetitions", repetiotions));
                comm.Parameters.Add(new SqlParameter("@WorkoutExercise_Id", exercise));
                comm.Parameters.Add(new SqlParameter("@WorkoutPrograms_Id", program));
                con.Open();
                comm.ExecuteNonQuery();
            }
        }

        public DataTable GetReportData(int programID)
        {
            var dt = new DataTable();

            using (var con = new SqlConnection(_connectionString))
            {
                using (var data = new SqlDataAdapter("select * from view_ProgramReport where [ProgramID]=  " + programID, con))
                {
                    data.Fill(dt);
                }
            }

            return dt;
        }

        public void DeleteWorkOut(int id)
        {
            using (var con = new SqlConnection(_connectionString))
            using (var comm = new SqlCommand("DeleteWorkout", con) { CommandType = CommandType.StoredProcedure })
            {
                comm.Parameters.Add(new SqlParameter("@id", id));
                con.Open();
                comm.ExecuteNonQuery();
            }
        }

        public void AddLogin(string sn)
        {
            var id = GetClientIdByCardSn(sn);
            this.AddLogin(id);
        }

        public int GetClientIdByCardSn(string cardSn)
        {

            using (var con = new SqlConnection(_connectionString))
            using (var comm = new SqlCommand("GetIdByCardSN", con) { CommandType = CommandType.StoredProcedure })
            {
                comm.Parameters.Add(new SqlParameter("@CardSN", cardSn));
                var outID = comm.Parameters.Add(new SqlParameter("@id", 0));
                outID.Direction = ParameterDirection.Output;
                con.Open();
                comm.ExecuteNonQuery();
                int res;
                if (int.TryParse(outID.Value.ToString(), out res))
                    return res;

                return 0;
            }

        }

        public void DeleteCardSn(string sn)
        {
            using (var con = new SqlConnection(_connectionString))
            using (var comm = new SqlCommand("DeleteCardSn", con) { CommandType = CommandType.StoredProcedure })
            {
                comm.Parameters.Add(new SqlParameter("@sn", sn));
                con.Open();
                comm.ExecuteNonQuery();
            }
        }

        public User GetUser(string u)
        {
            var dt = new DataTable();

            using (var con = new SqlConnection(_connectionString))
            {
                using (var data = new SqlDataAdapter("SELECT * FROM Users  where username='" + u + "'", con))
                {
                    data.Fill(dt);
                }
            }
            if (dt.Rows.Count == 1)
                return new User { Id = (int)dt.Rows[0]["id"], UserName = u, Name = dt.Rows[0]["Name"].ToString(), Password = dt.Rows[0]["Password"].ToString().Base64Decode(), IsAdmin = dt.Rows[0]["IsAdmin"].ToString() == "True" };//.Base64Decode();
            return null; ;
        }

        public List<User> GetListOfUsers()
        {
            var dt = new DataTable();
            var lst = new List<User>();
            using (var con = new SqlConnection(_connectionString))
            {
                using (var data = new SqlDataAdapter("SELECT * FROM Users  ", con))
                {
                    data.Fill(dt);
                }
            }
            foreach (DataRow row in dt.Rows)
            {
                var user = new User { Id = (int)row["id"], UserName = row["UserName"].ToString(), Name = row["Name"].ToString(), Password = row["Password"].ToString().Base64Decode(), IsAdmin = row["IsAdmin"].ToString() == "True" };//.Base64Decode(); 
                lst.Add(user);
            }

            return lst;
        }

        public void AddUpdateUser(User user)
        {
            var str = "";
            if (user.Id == 0) // new
            {
                str = string.Format(
                              "              INSERT INTO [dbo].[Users]  " +
                              "         ([Name] " +
                              "         ,[UserName] " +
                              "         ,[Password] " +
                              "         ,[IsAdmin]) " +
                              "   VALUES " +
                              "         (N'{0}' " +
                              "         ,N'{1}' " +
                              "         ,N'{2}' " +
                              "         ,{3})          ", user.Name, user.UserName, user.Password.Base64Encode(), user.IsAdmin ? "1" : "0");
            }
            else
            {
                str = string.Format(
                                                " UPDATE [dbo].[Users] " +
                                "   SET [Name] = N'{0}' " +
                                 "     ,[UserName] = N'{1}' " +
                                  "    ,[Password] = N'{2}' " +
                                   "   ,[IsAdmin] = {3} WHERE id= {4}", user.Name, user.UserName, user.Password.Base64Encode(), user.IsAdmin ? "1" : "0", user.Id);

            }

            using (var con = new SqlConnection(_connectionString))
            using (var comm = new SqlCommand(str, con))
            {
                con.Open();
                comm.ExecuteNonQuery();
            }

        }

        public void DeleteUser(int p)
        {
            var str = "delete from Users where id=" + p;
            using (var con = new SqlConnection(_connectionString))
            using (var comm = new SqlCommand(str, con))
            {
                con.Open();
                comm.ExecuteNonQuery();
            }
        }

        public DataTable GetLogins(int paymentId, int costumerId)
        {
            DataTable res = new DataTable();

            using (var con = new SqlConnection(_connectionString))
            using (var comm = new SqlCommand("GetLoginsPerPaymentPeriod", con) { CommandType = CommandType.StoredProcedure })
            {
                comm.Parameters.Add(new SqlParameter("@paymentId", paymentId));
                comm.Parameters.Add(new SqlParameter("@customerid", costumerId));
                using (var da = new SqlDataAdapter(comm))
                {
                    con.Open();
                    da.Fill(res);
                }


                return res;
            }
        }
    }


    public class LoginEvent : EventArgs
    {
        public string Name { get; set; }
        public DateTime SubscriptionTill { get; set; }
        public bool IsObligor { get; set; }

        public override string ToString()
        {
            var str = new StringBuilder();

            str.AppendLine("שם: " + Name);
            str.AppendLine("מנוי עד: " + SubscriptionTill.ToShortDateString());
            return str.ToString();
        }


    }
}
