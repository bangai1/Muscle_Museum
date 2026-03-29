using Museum_App.DTOs;
using Museum_App.Interfaces;
using Museum_App.Payment;
using Museum_Domain.Enums;
using Museum_Domain.Models;
using System.Net.Sockets;

namespace Museum_App.Services
{
    public class TicketSaleService : ITicketSaleService
    {
        private readonly ITicketPricingService _pricing;
        private readonly IPaymentService _payment;
        private readonly IPrinterService _printer;
        private readonly MuseumDbContext _context;

        public TicketSaleService(
            ITicketPricingService pricing,
            IPaymentService payment,
            IPrinterService printer,
            MuseumDbContext context)
        {
            _pricing = pricing;
            _payment = payment;
            _printer = printer;
            _context = context;
        }

        public TicketResultDto SellTicket(Visitor visitor)
        {
            // 1️⃣ Visitor kaydet
            _context.Visitors.Add(visitor);
            _context.SaveChanges(); // ID oluşur

            // 2️⃣ Ticket ve pricing hesapla
            var tempTicket = new Ticket(10);
            var pricingResult = _pricing.Calculate(tempTicket, visitor);


            // 3️⃣ Payment
            var paymentResult = _payment.ProcessPayment(new PaymentRequest
            {
                Amount = pricingResult.Price
            });

            // 3️⃣ Payment (sadece 0 TL değilse)
            if (pricingResult.Price > 0)
            {
                paymentResult = _payment.ProcessPayment(new PaymentRequest
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
            }

            // 4️⃣ Ticket oluştur
            var ticket = new Ticket( pricingResult.Price)
            {
                VisitorId = visitor.Id, // visitor.Id değil senin modelde ID
                CreatedDate = DateTime.Now,
                ReferenceNo = Guid.NewGuid().ToString()
            };

            // 5️⃣ Ticket DB’ye kaydet
            _context.Tickets.Add(ticket);
            _context.SaveChanges();

            // 6️⃣ Sonuç DTO
            return new TicketResultDto
            {
                Success = true,
                Price = ticket.Price,
                //Ticket_Type = ticket.TicketType,
                ReferenceNo = ticket.ReferenceNo,
                Message = "Bilet başarıyla oluşturuldu",
                Date = ticket.CreatedDate,
                Ticket = ticket // Helper için
            };
        }

    }
 }