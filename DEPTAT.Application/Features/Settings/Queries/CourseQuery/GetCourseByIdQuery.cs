using DEPTAT.Application.Responses;
using MediatR;

namespace DEPTAT.Application.Features.Settings.Queries.CourseQuery
{
    public class GetCourseByIdQuery : IRequest<BaseResponse<CourseResponse>>
    {
        public int Id { get; set; }
        public GetCourseByIdQuery(int id)
        {
            Id = id;
        }
    }
}
