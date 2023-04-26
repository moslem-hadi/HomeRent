using Application.Products.Queries.GetProductsWithPagination;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Queries.GetSingleProduct
{
    public class GetSingleProductQueryValidator : AbstractValidator<GetSingleProductQuery>
    {
        public GetSingleProductQueryValidator()
        {

            RuleFor(x => x.Id)
                .NotNull().WithMessage("Product Id is required.");
        }
    }
}