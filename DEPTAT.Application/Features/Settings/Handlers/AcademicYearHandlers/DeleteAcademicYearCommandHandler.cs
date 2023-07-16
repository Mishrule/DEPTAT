using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Features.Settings.Commands.AcademicYearCommands;
using DEPTAT.Application.Responses;
using AutoMapper;
using DEPTAT.Application.Contracts.Persistence;

namespace DEPTAT.Application.Features.Settings.Handlers.AcademicYearHandlers
{
    public class DeleteAcademicYearCommandHandler: IRequestHandler<DeleteAcademicYearCommand, BaseResponse<AcademicYearResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        

        public DeleteAcademicYearCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<AcademicYearResponse>> Handle(DeleteAcademicYearCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<AcademicYearResponse>();
            if (_unitOfWork.AcademicYearRepository == null)
            {
                response.IsSuccess = false;
                response.Message = "Invalid Request: Delete operation failed";
            }

            var AcademicYear = await _unitOfWork.AcademicYearRepository.Get(a => a.Id == request.Id);
            if (AcademicYear == null)
            {
                response.IsSuccess = false;
                response.Message = "Request not found";
            }

            await _unitOfWork.AcademicYearRepository.Delete(AcademicYear.Id);
            var save = await _unitOfWork.Save();
            if (save)
            {
                response.IsSuccess = true;
                response.Message = "Recorded Deleted";
			}
            else
            {
                response.Message = "Delete Failed Try again";
                response.IsSuccess = false;
            }

            return response;

        }
    }
}
