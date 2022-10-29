namespace ApiRest.Dto.Purchase
{
    public partial class Insert
    {        
        public string Date { get; set; }
        public string? Supplier { get; set; }
        public string? Nitsupplier { get; set; }
        public string? Quantity { get; set; }
        public int? ProductIdproduct { get; set; }
    }
    public partial class GetData
    {
        public int IdPurchase { get; set; }
        public string Date { get; set; }
        public string? Supplier { get; set; }
        public string? Nitsupplier { get; set; }
        public string? Quantity { get; set; }
        public int? ProductIdproduct { get; set; }
    }

    public partial class Edit
    {
        public string Date { get; set; }
        public string? Supplier { get; set; }
        public string? Nitsupplier { get; set; }
        public string? Quantity { get; set; }
        public int? ProductIdproduct { get; set; }
    }
}
