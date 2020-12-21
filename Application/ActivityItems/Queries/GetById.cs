using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.ActivityItems.Queries
{
    public class GetById : IRequest<Activity>
    {
        public Guid Id { get; set; }

        public class Handler : IRequestHandler<GetById, Activity>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                this._context = context;

            }

            public async Task<Activity> Handle(GetById request, CancellationToken cancellationToken)
            {
                var t = await _context.Activities.FirstOrDefaultAsync(
                    a => a.Id == request.Id,
                    cancellationToken
                );

                return t;
            }
        }
    }
}