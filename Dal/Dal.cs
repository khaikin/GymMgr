using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Dal
{
    public class Dal:IDisposable
    {
        protected EFRepository<GymDbEntities> dbContext;
        public Dal()
        {
            dbContext = new EFRepository<GymDbEntities>() { DataContext = new GymDbEntities() };
         
        }



        public IEnumerable<Customer> GetCustomers()
        {

            return dbContext.GetList<Customer>();
        
        }


        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
