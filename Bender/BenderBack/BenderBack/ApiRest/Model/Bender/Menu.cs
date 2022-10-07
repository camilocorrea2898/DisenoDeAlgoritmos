using System;
using System.Collections.Generic;

namespace ApiRest.Model.Bender
{
    public partial class Menu
    {
        public Menu()
        {
            ProductHasCombos = new HashSet<ProductHasCombo>();
        }

        public int Idmenu { get; set; }
        public string? Type { get; set; }
        public decimal? Price { get; set; }
        public string? Idstock { get; set; }
        public string? Idproductcombo { get; set; }

        public virtual ICollection<ProductHasCombo> ProductHasCombos { get; set; }
    }
}
