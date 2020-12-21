using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.ActivityItems.Queries
{
    public class GetList : IRequest<List<Activity>>
    {
        public class Handler : IRequestHandler<GetList, List<Activity>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                this._context = context;

            }

            public async Task<List<Activity>> Handle(
                GetList request,
                CancellationToken cancellationToken) => await _context.Activities.ToListAsync(cancellationToken);
        }
    }
}