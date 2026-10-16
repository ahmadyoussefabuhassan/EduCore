using EduCore.Application.Abstractions.Messaging;
using EduCore.Domain.Abstractions;

namespace EduCore.Application.Instructors.Queries.GetAllInstructors
{
    public sealed class GetAllInstructorsQuery : PaginationRequest , IQuery<GetAllDataResponse<InstructorsResponse>>
    {
        public GetAllInstructorsQuery(
            int pageNumber = 1 ,
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