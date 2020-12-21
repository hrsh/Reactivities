using Domain;
using MediatR;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ActivityItems.Commands
{
    public class EditCommand : IRequest
    {
        public Activity Model { get; set; }

        public class Handler : IRequestHandler<EditCommand>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(EditCommand request, CancellationToken cancellationToken)
            {
                var t = await _context.Activities.FindAsync(request.Model.Id);
                if (null == t) throw new Exception("Could not find activity");

                t.Title = request.Model.Title ?? t.Title;
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
                //var save = await _context.SaveChangesAsync(cancellationToken) > 0;
                //if (save) return Unit.Value;

                //throw new Exception("Error updating activity");
            }
        }
    }
}
