using DEPTAT.Application.Responses;
using MediatR;

namespace DEPTAT.Application.Features.Settings.Queries.AcademicYearQuery
{
    public class GetAcademicYearsQuery:IRequest<BaseResponseList<AcademicYearResponse>>
    {
        public GetAcademicYearsQuery() { }
    }
}
