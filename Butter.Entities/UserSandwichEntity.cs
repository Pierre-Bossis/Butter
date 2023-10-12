using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butter.Entities
{
    public class UserSandwichEntity
    {
        public int IdUser { get; set; }
        public int IdSandwich { get; set; }

        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
