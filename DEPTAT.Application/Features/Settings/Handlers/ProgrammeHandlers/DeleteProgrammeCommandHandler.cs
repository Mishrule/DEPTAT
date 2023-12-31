﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Features.Settings.Commands.ProgrammeCommands;
using DEPTAT.Application.Responses;
using AutoMapper;
using DEPTAT.Application.Contracts.Persistence;

namespace DEPTAT.Application.Features.Settings.Handlers.ProgrammeHandlers
{
    public class DeleteProgrammeCommandHandler: IRequestHandler<DeleteProgrammeCommand, BaseResponse<ProgrammeResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        

        public DeleteProgrammeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<ProgrammeResponse>> Handle(DeleteProgrammeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<ProgrammeResponse>();
            if (_unitOfWork.ProgrammeRepository == null)
            {
                response.IsSuccess = false;
                response.Message = "Invalid Request: Delete operation failed";
            }

            var Programme = await _unitOfWork.ProgrammeRepository.Get(a => a.Id == request.Id);
            if (Programme == null)
            {
                response.IsSuccess = false;
                response.Message = "Request not found";
            }

            await _unitOfWork.ProgrammeRepository.Delete(Programme.Id);
            var save = await _unitOfWork.Save();
            if (save)
            {
                response.IsSuccess = true;
                response.Message = "Record Deleted";
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
