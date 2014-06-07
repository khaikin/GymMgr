using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymDal
{
    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
        
        public bool IsAdmin { get; set; }
        public string UserName { get; set; }

        public int Id { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
