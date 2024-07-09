namespace InvoiceApi.Models.Dto
{
    public class CustomerDetailsDto
    {
        public required string CarRego { get; set; }
        public required string CustomerName { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CarMake { get; set; }
        public string? CarModel { get; set; }
        public string? PaymentStatus { get; set; }
    }
}
