using Museum_App.Interfaces;
using Museum_Domain.Models;
using System.Text;

namespace Museum_Infrastructure.Services
{
    public class PrinterService : IPrinterService
    {
        public void PrintTicket(Ticket ticket)
        {
            var text = new StringBuilder();
            text.AppendLine("====== MUSEUM TICKET ======");
            text.AppendLine($"Ticket Type : {ticket.TicketType}");
            text.AppendLine($"Price       : {ticket.Price} ₺");
            text.AppendLine($"Date        : {DateTime.Now}");
            text.AppendLine("===========================");

            File.WriteAllText("ticket.txt", text.ToString());
        }
    }
}
