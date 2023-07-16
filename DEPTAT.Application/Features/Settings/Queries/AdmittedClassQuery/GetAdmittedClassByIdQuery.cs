using DEPTAT.Application.Responses;
using MediatR;

namespace DEPTAT.Application.Features.Settings.Queries.AdmittedClassQuery
{
    public class GetAdmittedClassByIdQuery : IRequest<BaseResponse<AdmittedClassResponse>>
    {
        public int Id { get; set; }
        public GetAdmittedClassByIdQuery(int id)
        {
            Id = id;
        }
    }
}
