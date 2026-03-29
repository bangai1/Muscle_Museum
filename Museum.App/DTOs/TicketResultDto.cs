using Museum_Domain.Enums;
using Museum_Domain.Models;


namespace Museum_App.DTOs
{
   public class TicketResultDto
    {
       // public Ticket_Type Ticket_Type { get; set; }
        public int Price { get; set; }
        public string? Message { get; set; }
        public string? ReferenceNo { get; set; } = Guid.NewGuid().ToString();
        public bool Success { get; set; }
        public DateTime Date { get; set; }
        public Ticket Ticket { get; set; }
       
    }
}
