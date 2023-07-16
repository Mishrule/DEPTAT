using DEPTAT.Application.Responses;
using MediatR;

namespace DEPTAT.Application.Features.Settings.Queries.AdmittedClassQuery
{
    public class GetAdmittedClassesQuery:IRequest<BaseResponseList<AdmittedClassResponse>>
    {
        public GetAdmittedClassesQuery() { }
    }
}
