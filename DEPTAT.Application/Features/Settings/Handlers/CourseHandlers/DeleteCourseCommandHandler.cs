using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Features.Settings.Commands.CourseCommands;
using DEPTAT.Application.Responses;
using AutoMapper;
using DEPTAT.Application.Contracts.Persistence;

namespace DEPTAT.Application.Features.Settings.Handlers.CourseHandlers
{
    public class DeleteCourseCommandHandler: IRequestHandler<DeleteCourseCommand, BaseResponse<CourseResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        

        public DeleteCourseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<CourseResponse>> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<CourseResponse>();
            if (_unitOfWork.CourseRepository == null)
            {
                response.IsSuccess = false;
                response.Message = "Invalid Request: Delete operation failed";
            }

            var Course = await _unitOfWork.CourseRepository.Get(a => a.Id == request.Id);
            if (Course == null)
            {
                response.IsSuccess = false;
                response.Message = "Request not found";
            }

            await _unitOfWork.CourseRepository.Delete(Course);
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
