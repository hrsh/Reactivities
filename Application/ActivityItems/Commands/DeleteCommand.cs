using MediatR;
using Persistance;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ActivityItems.Commands
{
    public class DeleteCommand : IRequest
    {
        public Guid ItemId { get; set; }

        public class Handler : IRequestHandler<DeleteCommand>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(
                DeleteCommand request, 
                CancellationToken cancellationToken)
            {
                _context.Activities.Remove(new Domain.Activity
                {
                    Id = request.ItemId
                });
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
