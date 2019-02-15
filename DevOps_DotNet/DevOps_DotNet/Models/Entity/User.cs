using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevOps_DotNet.Models.Entity
{
    public class User
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public int UserAge { get; set; }

        public string UserSex { get; set; }

        public bool DeleteFlag { get; set; }
    }
}
