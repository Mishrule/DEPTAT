using DEPTAT.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Features.Settings.Commands.CourseCommands;
using AutoMapper;
using DEPTAT.Application.Contracts.Persistence;
using DEPTAT.Application.DTOs.Course.Validations;
using DEPTAT.Application.Exceptions;

namespace DEPTAT.Application.Features.Settings.Handlers.CourseHandlers
{
    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, BaseResponse<CourseResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICourseRepository _CourseRepository;

        public UpdateCourseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ICourseRepository CourseRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _CourseRepository = CourseRepository;
        }

        public async Task<BaseResponse<CourseResponse>> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<CourseResponse>();
            //var validator = new UpdateCourseDtoValidator(_CourseRepository);
            //var validationResult = await validator.ValidateAsync(request.UpdateCourseDto);

            //if (validationResult.IsValid == false)
            //    throw new ValidationException(validationResult);
            //response.IsSuccess = false;
            //response.Message = "Update Failed";
            //response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

            var Course = await _unitOfWork.CourseRepository.Get(y => y.Id == request.UpdateCourseDto.Id);
            if (Course == null)
                throw new NotFoundException(nameof(Course), request.UpdateCourseDto.Id);

            _mapper.Map(request.UpdateCourseDto, Course);
            await _unitOfWork.CourseRepository.Update(Course);
            var save = await _unitOfWork.Save();
            if (save)
            {
                response.IsSuccess = true;
                response.Message = "Record updated Successfully";
            }
            else
            {
                response.Message = "Update Failed Try again";
                response.IsSuccess = false;
            }

            return response;
        }
    }
}
