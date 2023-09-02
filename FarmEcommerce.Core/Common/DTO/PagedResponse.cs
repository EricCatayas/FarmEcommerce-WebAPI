
namespace FarmEcommerce.Core.Common.DTO
{
    public class PagedResponse<T> 
    {
        public PagedResponse() { }
        public PagedResponse(IEnumerable<T> data)
        {
            Data = data;
        }
        public IEnumerable<T> Data;
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string NextPage { get; set; }
        public string PreviousPage { get; set; }

    }
}
