namespace CQRSExample.CQRS.Commands
{
    public class AddProductCommand
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
