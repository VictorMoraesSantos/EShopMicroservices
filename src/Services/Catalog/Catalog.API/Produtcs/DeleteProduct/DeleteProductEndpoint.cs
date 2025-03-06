namespace Catalog.API.Produtcs.DeleteProduct
{
    public record DeleteProductResultResponse(bool IsSuccess);

    public class DeleteProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete(
                "/products/{id}",
                async (Guid id, ISender sender) =>
            {
                DeleteProductResult result = await sender.Send(new DeleteProductCommand(id));
                DeleteProductResultResponse response = result.Adapt<DeleteProductResultResponse>();

                return Results.Ok(response);
            })
            .WithName("DeleteProduct")
            .Produces<DeleteProductResultResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Delete product")
            .WithDescription("Delete product");
        }
    }
}
