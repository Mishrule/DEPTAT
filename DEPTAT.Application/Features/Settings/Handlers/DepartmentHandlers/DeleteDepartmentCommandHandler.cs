using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Features.Settings.Commands.DepartmentCommands;
using DEPTAT.Application.Responses;
using AutoMapper;
using DEPTAT.Application.Contracts.Persistence;

namespace DEPTAT.Application.Features.Settings.Handlers.DepartmentHandlers
{
    public class DeleteDepartmentCommandHandler: IRequestHandler<DeleteDepartmentCommand, BaseResponse<DepartmentResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        

        public DeleteDepartmentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<DepartmentResponse>> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<DepartmentResponse>();
            if (_unitOfWork.DepartmentRepository == null)
            {
                response.IsSuccess = false;
                response.Message = "Invalid Request: Delete operation failed";
            }

            var Department = await _unitOfWork.DepartmentRepository.Get(a => a.Id == request.Id);
            if (Department == null)
            {
                response.IsSuccess = false;
                response.Message = "Request not found";
            }

            await _unitOfWork.DepartmentRepository.Delete(Department.Id);
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
