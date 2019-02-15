using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevOps_DotNet.Models.Entity
{
    public class Content
    {
        public int ContentId { get; set; }
        public string ContentName { get; set; }

        public string Content1 { get; set; }
        public string Content2 { get; set; }
        public string Content3 { get; set; }
        public string Content4 { get; set; }
        public string Content5 { get; set; }

        public bool DeleteFlag { get; set; }
    }
}
