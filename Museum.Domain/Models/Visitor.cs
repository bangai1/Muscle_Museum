using Museum_Domain.Enums;

namespace Museum_Domain.Models
{
    public class Visitor
    {
        public Visitor_Type VisitorType { get; set; }

        public int Id { get; set; }

        public int Age { get; set; }

        public bool HasMuseumCard { get; set; }


        public List<Ticket> Tickets { get; set; } = new();


    }
}