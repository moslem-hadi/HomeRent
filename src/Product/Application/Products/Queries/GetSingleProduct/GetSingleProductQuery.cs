using Application.Common.Interfaces;
using Application.Products.Queries.GetProductsWithPagination;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Queries.GetSingleProduct
{
    public class GetSingleProductQuery : IRequest<ProductBriefDto>
    {
        public Guid Id { get; set; }
    }
    public class GetSingleProductQueryHandler : IRequestHandler<GetSingleProductQuery, ProductBriefDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetSingleProductQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductBriefDto> Handle(GetSingleProductQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ProductBriefDto>(await _context.Products.FirstOrDefaultAsync(a => a.Id == request.Id));
        }
    }
}