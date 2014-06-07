using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GymDal;

namespace GymMgr
{
    public class BaseUc : UserControl
    {

        private AdoDal dal;
        public AdoDal Dal
        {
            get
            {
                if (dal == null)
                    dal = new AdoDal();

                return dal;
            }
        }



        protected DataTable Customers
        {
            get
            {

                return Dal.GetListOfCustomers();

            }
        }

    }
}
