using System;
using System.Collections.Generic;

namespace ApiRest.Model.Bender
{
    public partial class ProductHasCombo
    {
        public ProductHasCombo()
        {
            MenuIdmenus = new HashSet<Menu>();
        }

        public int ProductoIdproducto { get; set; }
        public int CombosIdcombos { get; set; }
        public string Idproductocombo { get; set; } = null!;

        public virtual Combo CombosIdcombosNavigation { get; set; } = null!;
        public virtual Product ProductoIdproductoNavigation { get; set; } = null!;

        public virtual ICollection<Menu> MenuIdmenus { get; set; }
    }
}
