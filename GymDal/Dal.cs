using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.Validation;
using System.Data;

namespace GymDal
{
    public class Dal : IDisposable
    {
      
        protected EFRepository<GymDBEntities> dbContext;

        public Dal()
        {
            dbContext = new EFRepository<GymDBEntities>() { DataContext = new GymDBEntities() };
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return dbContext.GetQuery<Customer>(new[] { "Payments","Logins" });
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

        public void UpdateCustomer(Customer customer)
        {

            try
            {


                if (dbContext.DataContext.Entry(customer).State == System.Data.Entity.EntityState.Detached)
                    dbContext.Attach(customer);
                dbContext.DataContext.Entry(customer).State = System.Data.Entity.EntityState.Modified;

                dbContext.Commit();


            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }


        }

        public void AddNewCustomer(Customer newC)
        {
            dbContext.Add(newC);
            dbContext.Commit();
        }

        public void UpdatePayments(Customer cust)
        {
            var tmp = GetCustomers().First(c => c.id == cust.id);
            cust.Payments.ToList().ForEach(p =>
            {
                if (p.id == 0)
                {
                    p.Customer = tmp;
                    tmp.Payments.Add(p);
                }
            });

            dbContext.Commit();
        }

        public void CreateLogin(Customer cust)
        {
           
            var tmp = GetCustomers().First(c => c.id == cust.id);
            cust.LogIns.ToList().ForEach(p =>
            {
                    p.Customer = tmp;
                    tmp.LogIns.Add(p);
            });

            dbContext.Commit();
        }

        public IEnumerable<WorkoutProgram> GetPrograms()
        {

            return dbContext.GetQuery<WorkoutProgram>(new[] { "Workouts.WorkoutExercise" });
        }

        public IEnumerable<WorkoutExercise> GetSets()
        {
            return dbContext.GetQuery<WorkoutExercise>(new[] { "Workouts" });
        }

        public void AddNewWorkoutExercise(WorkoutExercise exercise)
        {

            dbContext.Add(exercise);
            dbContext.Commit();
        }

        public void UpdateWorkoutExercise(WorkoutExercise set)
        {

            if (dbContext.DataContext.Entry(set).State == System.Data.Entity.EntityState.Detached)
                dbContext.Attach(set);


            dbContext.DataContext.Entry(set).State = System.Data.Entity.EntityState.Modified;

            dbContext.Commit();
        }

        public void DeleteWorkoutExercise(WorkoutExercise set)
        {

            dbContext.Delete(GetSets().First(s => s.Id == set.Id));
            dbContext.Commit();

        }

        public void UpdateWorkout(Workout workout)
        {


            if (dbContext.DataContext.Entry(workout.WorkoutExercise).State == System.Data.Entity.EntityState.Detached)
            {
                var it = dbContext.DataContext.Workouts.Find(workout.Id);
                dbContext.DataContext.Entry(it).CurrentValues.SetValues(workout);
                it.WorkoutExercise = dbContext.DataContext.WorkoutExercises.Find(workout.WorkoutExercise.Id);

                //dbContext.Attach(workout.WorkoutExercise);
            }

            dbContext.Commit();


        }


        public IEnumerable<WorkoutExercise> GetExercises()
        {
            return dbContext.GetQuery<WorkoutExercise>();
        }


        public void UpdateWorkoutProgram(WorkoutProgram program)
        {
            var dbprogram = GetPrograms().First(p => p.Id == program.Id);

            program.Workouts.ToList().ForEach(w =>
            {
                if (w.Id == 0)
                {
                    w.WorkoutExercise = GetExercises().First(ex => ex.Id == w.WorkoutExercise.Id);
                    w.WorkoutProgram = dbprogram;
                    dbContext.Add(w);
                }
                else
                {
                    UpdateWorkout(w);
                }

            });
            dbprogram.Name = program.Name;

            dbContext.Commit();


        }


        public IEnumerable<Workout> GetWorkouts()
        {
            return dbContext.GetQuery<Workout>(new [] {"WorkoutProgram"});
        }

        public void DeleteWorkout(Workout c)
        {
           dbContext.Delete(GetWorkouts().First(w=>w.Id==c.Id));
            dbContext.Commit();
        }

        public void AddNewProgram(WorkoutProgram prog)
        {
            dbContext.Add(prog);
            dbContext.Commit();
        }


      

        public void DeleteProgram(WorkoutProgram prog)
        {

            prog.Workouts.ToList().ForEach(f => DeleteWorkout(f));

            dbContext.Delete(GetPrograms().First(p=>p.Id==prog.Id));
            dbContext.Commit();
        
        }

        public void CreateLogin(string sn)
        {
          //  throw new NotImplementedException();
        }
    }



}
