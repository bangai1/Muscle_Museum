using Museum_App.DTOs;
using Museum_App.Interfaces;
using Museum_Domain.Enums;
using Museum_Domain.Models;
using Museum_App.Payment;


namespace Museum_App.Services
{
    public class TicketSaleService : ITicketSaleService
    {
        private readonly ITicketPricingService _pricing;
        private readonly IPaymentService _payment;
        private readonly IPrinterService _printer;

        public TicketSaleService(
            ITicketPricingService pricing,
            IPaymentService payment,
            IPrinterService printer)
        {
            _pricing = pricing;
            _payment = payment;
            _printer = printer;
        }

        public TicketResultDto SellTicket(Visitor visitor, Ticket_Type type)
        {
            // 1️⃣ Ticket oluştur
            var ticket = new Ticket(type);

            // 2️⃣ Fiyat hesapla
            var pricingResult = _pricing.Calculate(ticket, visitor);

            // 3️⃣ POS’a ödeme gönder
            var paymentResult = _payment.ProcessPayment(new PaymentRequest
            {
                Amount = pricingResult.Price
            });

            if (!paymentResult.IsSuccess)
            {
                return new TicketResultDto
                {
                    Success = false,
                    Message = paymentResult.ErrorMessage
                };
            }

            // 4️⃣ Yazıcıdan bas
            //_printer.PrintTicket(ticket);

            // 5️⃣ Sonuç
            return new TicketResultDto
            {
                Success = true,
                Price = ticket.Price,
                ReferenceNo = paymentResult.ReferenceNo,
                Message = "Bilet başarıyla basıldı"
            };
        }
    }

}
