using Microsoft.AspNetCore.Mvc;
using Muscle_Museum.Models;
using Museum_App.Interfaces;
using Museum_Domain.Enums;
using Museum_Domain.Models;

public class TicketController : Controller
{
    private readonly ITicketSaleService _ticketSaleService;

    public TicketController(ITicketSaleService ticketSaleService)
    {
        _ticketSaleService = ticketSaleService;
    }

    [HttpGet]
    public IActionResult Index()
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
            IsTurkish = model.IsTurkish,
            IsTurkish_Soldier = model.IsTurkishSoldier
        };

        var result = _ticketSaleService.SellTicket(
            visitor,
            Ticket_Type.TurkishPaid
        );

        if (!result.Success)
        {
            model.Message = result.Message;

            return View("Index", model);
            // 👉 Views/Ticket/Index.cshtml
            // 👉 Hata varsa tekrar form
        }

        return View("Print", new Ticket_Print_ViewModel
        {
            Price = result.Price,
            ReferenceNo = result.ReferenceNo,
            Date = DateTime.Now
        });
        // 👉 Views/Ticket/Print.cshtml
        // 👉 Yazdırmadan önce bileti gösteren ekran
    }

    [HttpPost]
    public IActionResult ConfirmPrint()
    {
        TempData["PrintSuccess"] = "Bilet yazdırıldı";

        return RedirectToAction("Index");
        // 👉 /Ticket/Index
        // 👉 Views/Ticket/Index.cshtml
        // 👉 Yeni satış için başa dönüş
    }
}
