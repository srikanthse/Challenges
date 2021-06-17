namespace Challenges.Application.Dtos
{
    public class ProductWithSpecialDto
    {
        public string Name { get; set; }
        public decimal ProductStandardPrice { get; set; }
        public long SpecialQuantity { get; set; }
        public long SelectedQuantity { get; set; }
    }
}
