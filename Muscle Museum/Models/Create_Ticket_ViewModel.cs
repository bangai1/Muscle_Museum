namespace Muscle_Museum.Models
{
    public class Create_Ticket_ViewModel
    {
        public int Age { get; set; }
        public bool IsTurkish { get; set; }
        public bool IsTurkishSoldier { get; set; }

        // Result
        public bool Success { get; set; }
        public decimal Price { get; set; }
        public string? ReferenceNo { get; set; }
        public string? Message { get; set; }
    }
}
