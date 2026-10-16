namespace EduCore.Domain.Abstractions
{
    public class GetAllDataResponse<T> 
    {
        public int PageNumber { get; set; }
        public int TotalPage { get; set; }
        public int TotalDateCount { get; set; }
        public List<T> Data { get; set; }
        public int TotalDataCount { get; set; }

        public GetAllDataResponse()
        {
            Data = new List<T>();
        }
    }
}
