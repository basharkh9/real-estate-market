namespace real_estate_market.Controllers.Resources
{
    public class RealEstateQueryResource
    {
        public int? CladdingId { get; set; }
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
        public int Page { get; set; }
        public byte PageSize { get; set; }
    }
}