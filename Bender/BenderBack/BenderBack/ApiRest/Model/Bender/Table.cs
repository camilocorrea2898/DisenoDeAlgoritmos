using System;
using System.Collections.Generic;

namespace ApiRest.Model.Bender
{
    public partial class Table
    {
        public Table()
        {
            Orders = new HashSet<Order>();
        }

        public int Idtable { get; set; }
        public string? Availability { get; set; }
        public int BranchIdbranch { get; set; }

        public virtual Branch BranchIdbranchNavigation { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; }
    }
}
