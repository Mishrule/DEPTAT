using AutoMapper;
using DEPTAT.Application.Contracts.Infrastructure.Excel;
using DEPTAT.Application.Contracts.Persistence;
using DEPTAT.Application.Features.Examinations.Commands.DebtorsCommand;
using DEPTAT.Application.Responses;
using DEPTAT.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Features.Students.Commands.StudentCommands;

namespace DEPTAT.Application.Features.Students.Handlers.StudentHandlers
{
	public class CreateBulkStudentHandler : IRequestHandler<CreateStudentCommand, BaseResponse<StudentResponse>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly ILoadExcelToDb<StudentResponse> _loadExcelToDb;

		public CreateBulkStudentHandler(IUnitOfWork unitOfWork, IMapper mapper, ILoadExcelToDb<StudentResponse> loadExcelToDb)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_loadExcelToDb = loadExcelToDb;
		}

		public async Task<BaseResponse<StudentResponse>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
		{
			var response = new BaseResponse<StudentResponse>();
			var fileList = await _loadExcelToDb.LoadExcelFile(request.CreateStudentDto.File);
			response.Errors = new List<string>();
			int successCount = 0;
			int failureCount = 0;



			foreach (var student in fileList)
			{
				//response.Message += debtorEntity.StudentNumber + "Records <br /><hr />";
				try
				{
					var exist = await _unitOfWork.StudentRepository.Exists(n =>
						n.StudentNumber == student.StudentNumber);
					if (exist)
					{
						response.IsSuccess = false;
						response.Message = $"{student.StudentNumber} already exist ";
						response.Errors.Add(response.Message);
					}
					else
					{
						var studentEntity = _mapper.Map<Student>(student);

						

						studentEntity = await _unitOfWork.StudentRepository.Insert(studentEntity);
						var save = await _unitOfWork.Save();
						
						if (save)
						{
							response.IsSuccess = true;
							response.Message = $"{student.StudentNumber} Record saved Successfully ";
							response.Errors.Add(response.Message);
						}
						else
						{
							response.Message = $"{student.StudentNumber} Failed to save Try again ";
							response.IsSuccess = false;
							response.Errors.Add(response.Message);
						}
					}
				}

				catch (Exception e)
				{
					response.IsSuccess = false;
					response.Message = e.Message;
				}


				if (response.IsSuccess)
				{
					successCount += 1;
					response.Message = student.StudentNumber + "- successfully Saved";
					response.Errors.Add(response.Message);
				}
				else
				{

					failureCount += 1;
					response.Message = student.StudentNumber + "- failed to Save";
					response.Errors.Add(response.Message);

				}

			}

			response.Message = successCount + " Succeeded and " + failureCount + " failed";
			return response;
		}







	}
	

}
