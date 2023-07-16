using DEPTAT.Application.Responses;
using MediatR;

namespace DEPTAT.Application.Features.Settings.Queries.CourseQuery
{
    public class GetCoursesQuery:IRequest<BaseResponseList<CourseResponse>>
    {
        public GetCoursesQuery() { }
    }
}
