using real_estate_market.Extensions;

namespace real_estate_market.Core.Models
{
    public class RealEstateQuery : IQueryObject
    {
        public int? CladdingId { get; set; }
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
        public int Page { get; set; }
        public byte PageSize { get; set; }
    }
}