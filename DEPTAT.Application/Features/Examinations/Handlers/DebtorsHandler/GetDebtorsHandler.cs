﻿using AutoMapper;
using DEPTAT.Application.Contracts.Persistence;
using DEPTAT.Application.Features.Students.Queries.StudentQuery;
using DEPTAT.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Features.Examinations.Queries.DebtorQuery;

namespace DEPTAT.Application.Features.Examinations.Handlers.DebtorsHandler
{
    public class GetDebtorsHandler : IRequestHandler<GetDebtorsQuery, BaseResponseList<DebtorsResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetDebtorsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponseList<DebtorsResponse>> Handle(GetDebtorsQuery request, CancellationToken cancellationToken)
        {

            var responseList = new BaseResponseList<DebtorsResponse>();
            responseList.Errors = new List<string>();
            try
            {
                var studentList = await _unitOfWork.DebtorRepository.GetAll(includes: new List<string>{"Student.Programme.Department.Faculty"});
                responseList.Result = _mapper.Map<IEnumerable<DebtorsResponse>>(studentList);
                responseList.Message = "Success";
                responseList.IsSuccess = true;
            }
            catch (Exception e)
            {
                responseList.IsSuccess = false;
                responseList.Message = e.Message;
                responseList.Errors.Add(e.Message);
            }


            return responseList;
        }
    }
}
