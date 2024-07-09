using System.ComponentModel.DataAnnotations;

namespace InvoiceApi.Models.Entities
{
    public class tblInvoiceItem
    {
        [Key]
        public int InvoiceItemId { get; set; }
        public required string ItemName { get; set; }
        public required int Quantity { get; set; }
        public required decimal ItemPrice { get; set; }

        // Foreign Key 
        public int InvoiceId { get; set; }
        public tblInvoice? tblInvoice { get; set; }
    }
}
