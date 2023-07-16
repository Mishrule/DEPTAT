using AutoMapper;
using DEPTAT.Application.Contracts.Persistence;
using DEPTAT.Application.DTOs.Course.Validations;
using DEPTAT.Application.Features.Settings.Commands.CourseCommands;
using DEPTAT.Application.Responses;
using DEPTAT.Domain.Entities;
using MediatR;

namespace DEPTAT.Application.Features.Settings.Handlers.CourseHandlers
{
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, BaseResponse<CourseResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCourseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<CourseResponse>> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<CourseResponse>();
            var validator = new CreateCourseDtoValidator(_unitOfWork.CourseRepository);
            var validationResult = await validator.ValidateAsync(request.CreateCourseDto);

            if (validationResult.IsValid == false)
            {
                response.IsSuccess = false;
                response.Message = "Operation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                if (await _unitOfWork.CourseRepository.Exists(n => n.Name == request.CreateCourseDto.Name))
                {
                    response.IsSuccess = false;
                    response.Message = "Data already Exist";
                    
                }

                var CourseEntity = _mapper.Map<Course>(request.CreateCourseDto);

                CourseEntity = await _unitOfWork.CourseRepository.Insert(CourseEntity);
                var save = await _unitOfWork.Save();
                if (save)
                {
                    response.IsSuccess = true;
                    response.Message = "Record saved Successfully";
                }
                else
                {
                    response.Message = "Saved Failed Try again";
                    response.IsSuccess = false;
                }
            }

            return response;
        }
    }
}
