using System;
using System.Collections.Generic;

namespace ApiRest.Model.Bender
{
    public partial class Branch
    {
        public Branch()
        {
            Tables = new HashSet<Table>();
            Users = new HashSet<User>();
        }

        public int Idbranch { get; set; }
        public string? Name { get; set; }
        public int? Tablequantity { get; set; }

        public virtual ICollection<Table> Tables { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
