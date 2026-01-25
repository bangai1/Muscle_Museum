using Museum_Domain.Models;
using Museum_Domain.Enums;
using Museum_App.DTOs;
using Museum_App.Interfaces;

namespace Museum_App.Services
{
    public class TicketPricingService : ITicketPricingService
    {
        public TicketResultDto Calculate(Ticket ticket, Visitor visitor)
        {
            var result = new TicketResultDto();

            if (visitor.IsTurkish_Soldier)
            {
                result.Ticket_Type = Ticket_Type.SoldierFree;
                result.Price = 0;
            }
            else if (visitor.IsTurkish)
            {
                if (visitor.Age < 18 || visitor.Age >= 65)
                {
                    result.Ticket_Type = Ticket_Type.TurkishFree;
                    result.Price = 0;
                }
                else
                {
                    result.Ticket_Type = Ticket_Type.TurkishPaid;
                    result.Price = 20;
                }
            }
            else
            {
                result.Ticket_Type = Ticket_Type.ForeignPaid;
                result.Price = 30;
            }

            return result;
        }
    }
}
