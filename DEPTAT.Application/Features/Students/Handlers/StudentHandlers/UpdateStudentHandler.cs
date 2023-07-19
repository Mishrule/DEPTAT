using AutoMapper;
using DEPTAT.Application.Contracts.Persistence;
using DEPTAT.Application.DTOs.Student.Validations;
using DEPTAT.Application.Exceptions;
using DEPTAT.Application.Features.Students.Commands.StudentCommands;
using DEPTAT.Application.Responses;
using MediatR;

namespace DEPTAT.Application.Features.Students.Handlers.StudentHandlers
{
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, BaseResponse<StudentResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateStudentHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<StudentResponse>> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<StudentResponse>();

            try
            {
                var validator = new UpdateStudentDtoValidator();
                var validationResult = await validator.ValidateAsync(request.UpdateStudentDto);

                if (validationResult.IsValid == false)
                {
                    response.IsSuccess = false;
                    response.Message = "Update Failed";
                    response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                }


                var student = await _unitOfWork.StudentRepository.Get(y => y.Id == request.UpdateStudentDto.Id);
                if (student == null)
                    throw new NotFoundException(nameof(student), request.UpdateStudentDto.Id);

                _mapper.Map(request.UpdateStudentDto, student);
                await _unitOfWork.StudentRepository.Update(student);
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
            }
            catch (Exception e)
            {
                response.IsSuccess = false;
                response.Message = e.Message;
            }

            
            return response;
        }
    }
}
