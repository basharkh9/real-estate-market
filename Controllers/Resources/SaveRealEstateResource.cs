namespace real_estate_market.Controllers.Resources
{
    public class SaveRealEstateResource
    {
        public int Id { get; set; }
        public int CladdingId { get; set; }
        public float Area { get; set; }
        public int Level { get; set; }
        public string Address { get; set; }
        public float Price { get; set; }
    }
}