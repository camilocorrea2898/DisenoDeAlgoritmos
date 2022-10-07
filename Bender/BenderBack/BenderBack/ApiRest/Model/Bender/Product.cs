using System;
using System.Collections.Generic;

namespace ApiRest.Model.Bender
{
    public partial class Product
    {
        public Product()
        {
            ProductHasCombos = new HashSet<ProductHasCombo>();
            ProductHasOrders = new HashSet<ProductHasOrder>();
            Purchases = new HashSet<Purchase>();
            Stocks = new HashSet<Stock>();
        }

        public int Idproduct { get; set; }
        public string? Name { get; set; }
        public string? Supplier { get; set; }
        public string? Price { get; set; }
        public int InvoiceIdinvoice { get; set; }

        public virtual Invoice InvoiceIdinvoiceNavigation { get; set; } = null!;
        public virtual ICollection<ProductHasCombo> ProductHasCombos { get; set; }
        public virtual ICollection<ProductHasOrder> ProductHasOrders { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
