using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistance;

namespace Application.ActivityItems.Commands
{
    public class AddCommand : IRequest
    {
        public Activity Model { get; set; }

        public class Handler : IRequestHandler<AddCommand>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                this._context = context;
            }

            public async Task<Unit> Handle(AddCommand request, CancellationToken cancellationToken)
            {
                _context.Activities.Add(request.Model);
                var success = await _context.SaveChangesAsync(cancellationToken) > 0;

                if (success) return Unit.Value;

                throw new Exception("Error creating activity!");
            }
        }
    }
}