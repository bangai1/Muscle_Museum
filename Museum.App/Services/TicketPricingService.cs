using Museum_Domain.Models;
using Museum_Domain.Enums;
using Museum_App.DTOs;
using Museum_App.Interfaces;


namespace Museum_App.Services
{
    public class TicketPricingService : ITicketPricingService
    {
        public TicketResultDto Calculate(Ticket ticket , Visitor visitor)
        {
            var result = new TicketResultDto();

            //Özel günler

            bool isWednesday = DateTime.Now.DayOfWeek == DayOfWeek.Wednesday;
            bool is29May = (DateTime.Now.Month == 5 && DateTime.Now.Day == 29);


           


            // Türk ziyaretçi ücretsiz
            if (visitor.VisitorType == Visitor_Type.TurkishVisitor && (visitor.Age < 18 || visitor.Age > 65))
            {
                result.Price = 0;
                
                return result;
            }

            // Asker
            if (visitor.VisitorType == Visitor_Type.TurkishSoldier)
            {
                result.Price = 0;
                return result;
            }

            // Müzekart
            if (visitor.HasMuseumCard)
            {
                
                result.Price = 0;
                return result;
            }

            // Çarşamba (halk günü)
            if (isWednesday)
            {
                if (visitor.VisitorType == Visitor_Type.TurkishStudent)
                {
                    //result.Ticket_Type = Ticket_Type.Full;
                    result.Price = 30;
                }
                else
                {
                   // result.Ticket_Type = Ticket_Type.Full;
                    result.Price = 80;
                }

                return result;
            }

            // Türk öğrenci
            if (visitor.VisitorType == Visitor_Type.TurkishStudent)
            {
                if (visitor.Age >= 18 && visitor.Age <= 25)
                {
                    result.Price = 50;
                    return result;
                }
            }

            // Yabancı öğrenci
            if (visitor.VisitorType == Visitor_Type.ForeignStudent)
            {
                if (visitor.Age >= 12 && visitor.Age <= 25)
                {
                    result.Price = 375;
                    return result;
                }
            }

            // Yabancı ziyaretçi
            if (visitor.VisitorType == Visitor_Type.ForeignVisitor)
            {
                //result.Ticket_Type = Ticket_Type.Full;
                result.Price = 750;
                return result;
            }

            // Veli
            if (visitor.VisitorType == Visitor_Type.Veli)
            {
                //result.Ticket_Type = Ticket_Type.Full;
                result.Price = 160;
                return result;
            }

            //// Default
            //result.Ticket_Type = Ticket_Type.Full;
            //result.Price = 160;

            return result;
        }



    }
}
