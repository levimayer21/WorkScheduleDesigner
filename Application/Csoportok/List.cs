using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Persistence;

namespace Application.Csoportok
{
    public class List
    {
        public class Query : IRequest<Result<List<Csoport>>>
        {
        }

        public class Handler : IRequestHandler<Query, Result<List<Csoport>>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<Csoport>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<List<Csoport>>.Success(await _context.Csoportok.ToListAsync());
            }
        }
    }
}