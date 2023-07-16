using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Features.Settings.Commands.YearGroupCommands;
using DEPTAT.Application.Responses;
using AutoMapper;
using DEPTAT.Application.Contracts.Persistence;

namespace DEPTAT.Application.Features.Settings.Handlers.YearGroupHandlers
{
    public class DeleteYearGroupCommandHandler: IRequestHandler<DeleteYearGroupCommand, BaseResponse<YearGroupResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        

        public DeleteYearGroupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<YearGroupResponse>> Handle(DeleteYearGroupCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<YearGroupResponse>();
            if (_unitOfWork.YearGroupRepository == null)
            {
                response.IsSuccess = false;
                response.Message = "Invalid Request: Delete operation failed";
            }

            var yearGroup = await _unitOfWork.YearGroupRepository.Get(a => a.Id == request.Id);
            if (yearGroup == null)
            {
                response.IsSuccess = false;
                response.Message = "Request not found";
            }

            await _unitOfWork.YearGroupRepository.Delete(yearGroup.Id);
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
