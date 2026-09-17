namespace EduCore.Domain.Abstractions
{
    public class PaginationRequest
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Query { get; set; } = "";
    }
}
