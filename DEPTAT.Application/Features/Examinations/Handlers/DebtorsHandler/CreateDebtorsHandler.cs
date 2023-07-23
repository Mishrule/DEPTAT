using AutoMapper;
using DEPTAT.Application.Contracts.Persistence;
using DEPTAT.Application.DTOs.Student.Validations;
using DEPTAT.Application.Features.Students.Commands.StudentCommands;
using DEPTAT.Application.Responses;
using DEPTAT.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Contracts.Infrastructure.Excel;
using DEPTAT.Application.Features.Examinations.Commands.DebtorsCommand;

namespace DEPTAT.Application.Features.Examinations.Handlers.DebtorsHandler
{
    public class CreateDebtorsHandler : IRequestHandler<CreateDebtorCommand, BaseResponse<DebtorsResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILoadExcelToDb<DebtorsResponse> _loadExcelToDb;

        public CreateDebtorsHandler(IUnitOfWork unitOfWork, IMapper mapper, ILoadExcelToDb<DebtorsResponse> loadExcelToDb)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _loadExcelToDb = loadExcelToDb;
        }

        public async Task<BaseResponse<DebtorsResponse>> Handle(CreateDebtorCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<DebtorsResponse>();
            var fileList = await _loadExcelToDb.LoadExcelFile(request.CreateDebtorsDto.File);
            response.Errors = new List<string>();
            int successCount = 0;
            int failureCount = 0;

            foreach (var debtorEntity in fileList)
            {
                //response.Message += debtorEntity.StudentNumber + "Records <br /><hr />";
                try
                {
                    var exist = await _unitOfWork.DebtorRepository.Exists(n =>
                        n.StudentNumber == debtorEntity.StudentNumber
                        && n.AcademicYear == debtorEntity.AcademicYear);
                    if (exist)
                    {
                        response.IsSuccess = false;
                        response.Message = $"{debtorEntity.StudentNumber} already exist ";
                        response.Errors.Add(response.Message);
                    }
                    else
                    {
                        var studentEntity = _mapper.Map<Debtors>(debtorEntity);

                        if (studentEntity.AmountPaid == studentEntity.AmountBilled)
                        {
                            studentEntity.PaymentStatus = "Fully Paid";
                            studentEntity.Balance = studentEntity.AmountBilled - studentEntity.AmountPaid;
                        }

                        if (studentEntity.AmountPaid < studentEntity.AmountBilled)
                        {
                            studentEntity.PaymentStatus = "Owing";
                            studentEntity.Balance = studentEntity.AmountBilled - studentEntity.AmountPaid;
                        }
                        else if (studentEntity.AmountPaid > studentEntity.AmountBilled)
                        {
                            studentEntity.PaymentStatus = "Over Paid";
                            studentEntity.Balance = studentEntity.AmountBilled - studentEntity.AmountPaid;
                        }

                        studentEntity = await _unitOfWork.DebtorRepository.Insert(studentEntity);
                        var save = await _unitOfWork.Save();


                        if (save)
                        {
                            response.IsSuccess = true;
                            response.Message = $"{debtorEntity.StudentNumber} Record saved Successfully ";
                            response.Errors.Add(response.Message);
                        }
                        else
                        {
                            response.Message = $"{debtorEntity.StudentNumber} Failed to save Try again ";
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
                    response.Message = debtorEntity.StudentNumber  +"- successfully Saved";
                    response.Errors.Add(response.Message);
                }
                else
                {

                    failureCount += 1;
                    response.Message =  debtorEntity.StudentNumber + "- failed to Save";
                    response.Errors.Add(response.Message);
                  
                }
                
            }

            response.Message = successCount + " Succeeded and " + failureCount + " failed"; 
            return response;
        }
    }
}
