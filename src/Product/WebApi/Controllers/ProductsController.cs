using Application.Common.Models;
using Application.Products.Queries.GetProductsWithPagination;
using Application.Products.Queries.GetSingleProduct;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebUI.Controllers;

namespace WebApi.Controllers;

public class ProductsController : ApiControllerBase
{
    [HttpGet]
    public async Task<PaginatedList<ProductBriefDto>> GetProducts([FromQuery] GetProductsWithPaginationQuery query)
    {
        var result = await Mediator.Send(query);
        return result;
    }

    [HttpGet("{id}")]
    public async Task<ProductBriefDto> GetProduct([FromRoute] GetSingleProductQuery query)
    {
        var result = await Mediator.Send(query);
        return result;
    }
}
