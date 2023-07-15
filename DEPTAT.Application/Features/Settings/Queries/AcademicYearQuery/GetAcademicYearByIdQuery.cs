using DEPTAT.Application.Responses;
using MediatR;

namespace DEPTAT.Application.Features.Settings.Queries.AcademicYearQuery
{
    public class GetAcademicYearByIdQuery : IRequest<BaseResponse<AcademicYearResponse>>
    {
        public int Id { get; set; }
        public GetAcademicYearByIdQuery(int id)
        {
            Id = id;
        }
    } 
}
