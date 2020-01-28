using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Products
{
    public class Create
    {
        public class Command : IRequest
        {
            public Guid ProdId { get; set; }
            public string ProdName { get; set; }
            public Decimal ProdPrice { get; set; }
            public int ProdCategoryId { get; set; }
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
                var product = new Product
                {
                    ProdName = request.ProdName,
                    ProdPrice = request.ProdPrice,
                    ProdCategoryId = request.ProdCategoryId
                };

                _context.Products.Add(product);
                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes!");
            }
        }
    }
}