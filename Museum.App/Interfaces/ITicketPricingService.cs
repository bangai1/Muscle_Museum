using Museum_App.DTOs;
using Museum_Domain.Models;

namespace Museum_App.Interfaces
{
    public interface ITicketPricingService
    {
        TicketResultDto Calculate(Ticket ticket, Visitor visitor);
    }

}
