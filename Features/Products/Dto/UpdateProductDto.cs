namespace BuriPosApi.Features.Products.Dto
{
    public class UpdateProductDto
    {
        public string Category { get; set; } = string.Empty;
        public string Barcode { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal CostOfGoods { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int? Quantity { get; set; }
        public bool IsComplete { get; set; }
    }
}