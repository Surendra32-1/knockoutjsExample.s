namespace KnockoutPrastice.Utility
{
    public class PaginatedResult<T>
    {
        public int TotalCount { get; set; }
        public int ? PageSize { get; set; }
        public IEnumerable<T> Results { get; set; }
    }

}
