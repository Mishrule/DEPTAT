using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DEPTAT.Application.Features.Settings.Queries.ProgrammesQuery
{
	public class GetTotalProgrammeQuery : IRequest<int>
	{
		public GetTotalProgrammeQuery()
		{
		}
	}
}
