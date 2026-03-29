using Museum_Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Museum_Domain.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        public bool IsCancelled { get; set; } //iptal işi

        public DateTime CancelDate {  get; set; }

        [NotMapped]
        public Ticket_Type TicketType { get; set; }

        public int Price { get; set; }

        public string ReferenceNo { get; set; } = Guid.NewGuid().ToString();

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int VisitorId { get; set; }

        public Visitor Visitor { get; set; } = null!; 

        public Ticket() { }

        public Ticket( int price)
        {
            //TicketType = ticketType;
            Price = price;
        }
    }
}