using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Csoportok
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Csoport Csoport { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var csoport = await _context.Csoportok.FindAsync(request.Csoport.Id);

                if (csoport == null)
                {
                    return null;
                }

                _mapper.Map(request.Csoport, csoport);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result)
                {
                    return Result<Unit>.Failure("Failed to update group");
                }

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}