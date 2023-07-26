using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DEPTAT.Application.Contracts.Persistence;
using DEPTAT.Application.Features.Settings.Queries.ProgrammesQuery;
using DEPTAT.Application.Responses;
using MediatR;

namespace DEPTAT.Application.Features.Settings.Handlers.ProgrammeHandlers
{
    public class GetTotalProgrammeQueryHandler : IRequestHandler<GetTotalProgrammeQuery, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTotalProgrammeQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(GetTotalProgrammeQuery request, CancellationToken cancellationToken)
        {
            var responseList = new BaseResponseList<ProgrammeResponse>();
            try
            {
                if (_unitOfWork == null || _mapper == null)
                {
                    // Handle the situation where dependencies are not initialized properly.
                    // Log the issue and set the response as unsuccessful.
                    responseList.IsSuccess = false;
                    responseList.Message = "Dependencies not properly initialized.";
                    return 0; // or throw an exception if appropriate
                }
                else
                {
                    var otpList = await _unitOfWork.ProgrammeRepository.GetAll();
                    responseList.Result = _mapper.Map<IEnumerable<ProgrammeResponse>>(otpList);
                    responseList.Message = "Success";
                }


            }
            catch (Exception e)
            {
                // Log the exception for debugging/troubleshooting
                // Logger.Log(e);

                // Set the response as unsuccessful with an error message
                responseList.IsSuccess = false;
                responseList.Message = "An error occurred while fetching students.";
                // Optionally, throw the exception if you want the calling code to handle it.
                // throw;
            }

            return responseList.Result?.Count() ?? 0;
        }
    }
}

