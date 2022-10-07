using System;
using System.Collections.Generic;

namespace ApiRest.Model.Bender
{
    public partial class Combo
    {
        public Combo()
        {
            Orders = new HashSet<Order>();
            ProductHasCombos = new HashSet<ProductHasCombo>();
        }

        public int Idcombo { get; set; }
        public string? Namecombo { get; set; }
        public int? Idproduct { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ProductHasCombo> ProductHasCombos { get; set; }
    }
}
