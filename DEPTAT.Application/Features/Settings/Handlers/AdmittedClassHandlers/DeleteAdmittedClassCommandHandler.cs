using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Features.Settings.Commands.AdmittedClassCommands;
using DEPTAT.Application.Responses;
using AutoMapper;
using DEPTAT.Application.Contracts.Persistence;

namespace DEPTAT.Application.Features.Settings.Handlers.AdmittedClassHandlers
{
    public class DeleteAdmittedClassCommandHandler: IRequestHandler<DeleteAdmittedClassCommand, BaseResponse<AdmittedClassResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        

        public DeleteAdmittedClassCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<AdmittedClassResponse>> Handle(DeleteAdmittedClassCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<AdmittedClassResponse>();
            if (_unitOfWork.AdmittedClassRepository == null)
            {
                response.IsSuccess = false;
                response.Message = "Invalid Request: Delete operation failed";
            }

            var AdmittedClass = await _unitOfWork.AdmittedClassRepository.Get(a => a.Id == request.Id);
            if (AdmittedClass == null)
            {
                response.IsSuccess = false;
                response.Message = "Request not found";
            }

            await _unitOfWork.AdmittedClassRepository.Delete(AdmittedClass.Id);
            var save = await _unitOfWork.Save();
            if (save)
            {
                response.IsSuccess = true;
                response.Message = "Success: Date Recorded Successfully";
            }
            else
            {
                response.Message = "Error: Save Failed Try again";
                response.IsSuccess = false;
            }

            return response;

        }
    }
}
