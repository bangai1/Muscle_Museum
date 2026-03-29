using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Muscle_Museum.Models;
using Museum_App.Interfaces;
using Museum_App.Services;
using Museum_Domain.Enums;
using Museum_Domain.Models;


public class TicketController : Controller
{
    private readonly ITicketSaleService _ticketSaleService;
    private readonly MuseumDbContext _context;


    public TicketController(ITicketSaleService ticketSaleService, MuseumDbContext context)
    {
        _ticketSaleService = ticketSaleService;
        _context = context;
    }



    [HttpGet]
    public IActionResult Index()
    {
        var user = HttpContext.Session.GetString("User");

        if (string.IsNullOrEmpty(user))
        {
            return RedirectToAction("Login", "Auth");
        }

        return View();
    }



    //[HttpGet]
    //public IActionResult Index()
    //{
    //    return View();
    //    // 👉 Views/Ticket/Index.cshtml
    //    // 👉 Satış formu burada
    //}

    [HttpGet]
    public IActionResult Print()
    {
        return View();
        // 👉 Views/Ticket/Index.cshtml
        // 👉 Satış formu burada
    }



    [HttpPost]
    public IActionResult Sell(Create_Ticket_ViewModel model)
    {
        var visitor = new Visitor
        {
            Age = model.Age,
            HasMuseumCard = false,
            VisitorType =
                model.IsTurkishStudent ? Visitor_Type.TurkishStudent :
                model.IsForeignStudent ? Visitor_Type.ForeignStudent :
                model.IsTurkishSoldier ? Visitor_Type.TurkishSoldier :
                model.IsForeignVisitor ? Visitor_Type.ForeignVisitor :
                model.IsTurkishVisitor ? Visitor_Type.TurkishVisitor:
                model.IsVeli ? Visitor_Type.Veli : Visitor_Type.Veli
                
        };

       

        var result = _ticketSaleService.SellTicket(visitor);



        if (!result.Success)
        {
            model.Message = result.Message;
            model.Success = false;
            return View("Index", model);
        }

        return View("Print", result);
    }



    [HttpPost]
    public IActionResult ConfirmPrint(Create_Ticket_ViewModel model)
    {
        TempData["PrintSuccess"] = $"Bilet yazdırıldı - Ref: {model.ReferenceNo}";
        return RedirectToAction("Index");
    }


    [HttpPost]
    public IActionResult Cancel(string referenceCode)
    {
        var ticket = _context.Tickets
            .FirstOrDefault(x => x.ReferenceNo == referenceCode);

        if (ticket == null)
        {
            // Eğer bilet yoksa hata sayfasına yönlendir
            TempData["Error"] = "Bilet bulunamadı";
            return RedirectToAction("CancelResult");
        }

        // Bileti iptal et
        ticket.IsCancelled = true;
        ticket.CancelDate = DateTime.Now;
        _context.SaveChanges();

        // Mesaj ile birlikte sonucu göster
        TempData["Message"] = $"Referans Nolu ({referenceCode}) bilet iptal edilmiştir.";

        return RedirectToAction("CancelResult");
    }

    // ✅ Yeni Result sayfası
    public IActionResult CancelResult()
    {
        return View();
    }


    [HttpPost]
    public IActionResult Group(string referenceCode)
    {
        var ticket = _context.Tickets
            .FirstOrDefault(x => x.ReferenceNo == referenceCode);

        if (ticket == null)
        {
            // Eğer bilet yoksa hata sayfasına yönlendir
            TempData["Error"] = "Bilet bulunamadı";
            return RedirectToAction("CancelResult");
        }

        // Bileti iptal et
        ticket.IsCancelled = true;
        ticket.CancelDate = DateTime.Now;
        _context.SaveChanges();

        // Mesaj ile birlikte sonucu göster
        TempData["Message"] = $"Referans Nolu ({referenceCode}) bilet iptal edilmiştir.";

        return RedirectToAction("CancelResult");
    }






}
