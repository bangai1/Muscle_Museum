using Museum_Domain.Enums;


namespace Museum_App.DTOs
{
   public class TicketResultDto
    {
        public Ticket_Type Ticket_Type { get; set; }
        public decimal Price { get; set; }
        public string? Message { get; set; }
        public string? ReferenceNo { get; set; }
        public bool Success { get; set; }
    }
}
