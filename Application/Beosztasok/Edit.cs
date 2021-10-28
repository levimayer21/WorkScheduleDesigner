using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Beosztasok
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Beosztas Beosztas { get; set; }
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
                var beosztas = await _context.Beosztasok.FindAsync(request.Beosztas.Id);

                if (beosztas == null)
                {
                    return null;
                }

                _mapper.Map(request.Beosztas, beosztas);

                beosztas.Modositva = DateTime.Now;

                var result = await _context.SaveChangesAsync() > 0;

                if (!result)
                {
                    return Result<Unit>.Failure("Failed to update event");
                }

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}