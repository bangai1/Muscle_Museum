using Museum_Domain.Models;


namespace Museum_App.Interfaces
{
    public interface IPrinterService
    {
        void PrintTicket(Ticket ticket);
    }

}
