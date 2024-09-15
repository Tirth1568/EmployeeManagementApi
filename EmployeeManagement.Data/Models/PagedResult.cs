namespace EmployeeManagement.Data.Models
{
    public class PagedResult<T>
    {
        public int TotalRecords { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public List<T> Records { get; set; }
    }

}
