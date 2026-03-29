using Museum_Domain.Models;
using Museum_Domain.Enums;

namespace Museum_App.Helpers
{
    public static class TicketHelper
    {
        public static string GetTicketDisplayName(Ticket ticket)
        {
            return ticket.Visitor.VisitorType switch
            {
                Visitor_Type.TurkishStudent => "Öğrenci",
                Visitor_Type.TurkishVisitor => "Türk Ziyaretçi",
                Visitor_Type.ForeignStudent => "Öğrenci (Yabancı)",
                Visitor_Type.TurkishSoldier => "Asker",
                Visitor_Type.ForeignVisitor => "Yabancı Ziyaretçi",
                Visitor_Type.Veli => "Veli",
                _ => ticket.TicketType.ToString()
            };
        }
    }
}