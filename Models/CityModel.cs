namespace SampleApi.Models
{
    public class CityModel
    {
        public int CityId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string CityName { get; set; }
        public string CityCode { get; set; }
        public DateTime CreatedDate{ get; set; }
        public DateTime ModifiedDate { get; set; }



    }
}
