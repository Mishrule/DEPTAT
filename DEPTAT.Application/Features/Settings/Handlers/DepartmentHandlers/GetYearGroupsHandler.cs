﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DEPTAT.Application.Contracts.Persistence;
using DEPTAT.Application.Features.Settings.Queries.DepartmentQuery;
using DEPTAT.Application.Responses;
using MediatR;

namespace DEPTAT.Application.Features.Settings.Handlers.DepartmentHandlers
{
    public class GetDepartmentsHandler : IRequestHandler<GetDepartmentsQuery, BaseResponseList<DepartmentResponse>>
    {private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetDepartmentsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponseList<DepartmentResponse>> Handle(GetDepartmentsQuery request, CancellationToken cancellationToken)
        {
            var responseList = new BaseResponseList<DepartmentResponse>();
            var DepartmentList = await _unitOfWork.DepartmentRepository.GetAll(includes: new List<string> { "Faculty" });
            responseList.Result = _mapper.Map<IEnumerable<DepartmentResponse>>(DepartmentList);
            responseList.Message = "Success";
            responseList.IsSuccess = true;

            return responseList;
        }
    }
}
