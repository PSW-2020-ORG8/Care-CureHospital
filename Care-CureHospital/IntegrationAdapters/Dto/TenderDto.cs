namespace IntegrationAdapters.Dto
{
    public class TenderDto
    {
        public int Id { get; set; }

        public string MedicamentName { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public bool Active { get; set; }

        public bool ChoosenOffer { get; set; }

        public TenderDto() { }
    }
}
