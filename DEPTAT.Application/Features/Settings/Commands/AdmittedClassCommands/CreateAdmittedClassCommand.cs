using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions.Impl;
using DEPTAT.Application.DTOs.AdmittedClass;
using DEPTAT.Application.Responses;
using MediatR;

namespace DEPTAT.Application.Features.Settings.Commands.AdmittedClassCommands
{
    public class CreateAdmittedClassCommand:IRequest<BaseResponse<AdmittedClassResponse>>
    {
        public CreateAdmittedClassDto CreateAdmittedClassDto { get; }
    }
}
