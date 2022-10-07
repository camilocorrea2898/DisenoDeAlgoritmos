using System;
using System.Collections.Generic;

namespace ApiRest.Model.Bender
{
    public partial class ProductHasOrder
    {
        public int ProductIdproduct { get; set; }
        public int OrderIdorder { get; set; }

        public virtual Product ProductIdproductNavigation { get; set; } = null!;
    }
}
