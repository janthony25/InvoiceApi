using System.ComponentModel.DataAnnotations;

namespace InvoiceApi.Models.Entities
{
    public class tblCustomer
    {
        [Key]
        public int CustomerId { get; set; }
        public required string CarRego { get; set; }
        public required string CustomerName { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CarMake { get; set; }
        public string? CarModel { get; set; }
        public string? PaymentStatus { get; set; }

        // Has many Invoice
        public ICollection<tblInvoice>? tblInvoice { get; set; }
    }
}
