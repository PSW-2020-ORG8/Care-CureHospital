namespace TenderMicroservice.Dto
{
    public class OfferDto
    {
        public int Id { get; set; }

        public int TenderId { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public string Comment { get; set; }
        public string PharmacyName { get; set; }
        public string PharmacyEmail { get; set; }

        public bool ActiveTender { get; set; }
        public OfferDto() { }
    }
}
