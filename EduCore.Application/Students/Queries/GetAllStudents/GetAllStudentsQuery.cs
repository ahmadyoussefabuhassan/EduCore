using EduCore.Application.Abstractions.Messaging;
using EduCore.Domain.Abstractions;

namespace EduCore.Application.Students.Queries.GetAllStudents
{
    public sealed class GetAllStudentsQuery : PaginationRequest ,IQuery<GetAllDataResponse<StudentsResponse>>
    {
        public GetAllStudentsQuery(int pageNumber = 1 ,
            int pageSize = 100 ,
            string? search = null)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Search = search;
        }
        public string? Search { get; set; }
    }
}
