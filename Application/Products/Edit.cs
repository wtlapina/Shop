using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.Products
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Guid ProdId { get; set; }
            public string ProdName { get; set; }
            public Decimal? ProdPrice { get; set; }
            public int? ProdCategoryId { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var prod = await _context.Products.FindAsync(request.ProdId);
                
                if (prod == null)
                    throw new Exception("Could not find product");

                prod.ProdName = request.ProdName ?? prod.ProdName;
                prod.ProdPrice = request.ProdPrice ?? prod.ProdPrice;
                prod.ProdCategoryId = request.ProdCategoryId ?? prod.ProdCategoryId;
                
                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes!");
            }
        }
    }
}