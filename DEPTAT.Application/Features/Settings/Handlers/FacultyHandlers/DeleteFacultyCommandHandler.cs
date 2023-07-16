using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Features.Settings.Commands.FacultyCommands;
using DEPTAT.Application.Responses;
using AutoMapper;
using DEPTAT.Application.Contracts.Persistence;

namespace DEPTAT.Application.Features.Settings.Handlers.FacultyHandlers
{
    public class DeleteFacultyCommandHandler: IRequestHandler<DeleteFacultyCommand, BaseResponse<FacultyResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        

        public DeleteFacultyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<FacultyResponse>> Handle(DeleteFacultyCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<FacultyResponse>();
            if (_unitOfWork.FacultyRepository == null)
            {
                response.IsSuccess = false;
                response.Message = "Invalid Request: Delete operation failed";
            }

            var Faculty = await _unitOfWork.FacultyRepository.Get(a => a.Id == request.Id);
            if (Faculty == null)
            {
                response.IsSuccess = false;
                response.Message = "Request not found";
            }

            await _unitOfWork.FacultyRepository.Delete(Faculty.Id);
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
