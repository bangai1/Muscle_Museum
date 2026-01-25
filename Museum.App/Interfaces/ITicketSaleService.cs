using Museum_App.DTOs;
using Museum_Domain.Enums;
using Museum_Domain.Models;


namespace Museum_App.Interfaces
{
    public interface ITicketSaleService
    {
        TicketResultDto SellTicket(Visitor visitor, Ticket_Type type);
    }

}
