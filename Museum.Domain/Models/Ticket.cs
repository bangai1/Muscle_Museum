using Museum_Domain.Enums;

namespace Museum_Domain.Models;


    public class Ticket
    {
         public Ticket_Type Type { get; set; }
        public int ID { get; set; }
        public string? Ticket_Type { get; set; } //maybe 
        public decimal Price { get; set; }
        public int Ticket_Serial_Number { get; set; }

    public Ticket()
    {
        Ticket_Serial_Number = 0;
    }

    public Ticket(Ticket_Type type)
    {
        Type = type;
    }
}

