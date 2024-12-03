namespace SampleApi.Models
{
    public class StateModel
    {
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public string StateName { get; set; }
        public string StateCode { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
