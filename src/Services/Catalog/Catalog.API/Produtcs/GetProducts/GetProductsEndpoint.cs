﻿namespace Catalog.API.Produtcs.GetProducts
{
    public record GetProductsRequest(int? PageNumber = 1, int? PageSize = 10);
    public record GetProductsResponse(IEnumerable<Product> Products);

    public class GetProductsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet(
                "/products",
                async ([AsParameters] GetProductsRequest reqeust, ISender sender) =>
            {
                GetProductsResult result = await sender.Send(new GetProductsQuery());
                GetProductsResponse response = result.Adapt<GetProductsResponse>();

                return Results.Ok(response);
            })
            .WithName("GetProducts")
            .Produces<GetProductsResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get products")
            .WithDescription("Get products");
        }
    }
}
