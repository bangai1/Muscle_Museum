namespace Muscle_Museum.Models
{
    public class Create_Ticket_ViewModel
    {
        // ======================
        // INPUT (Form alanları)
        // ======================

        public int Age { get; set; }

        public bool IsTurkish { get; set; }

        public bool IsTurkishStudent { get; set; }

        public bool IsTurkishSoldier { get; set; }

        public bool IsTurkishVisitor { get; set; } //eklendi

        public bool HasMuseumCard { get; set; }

        public bool IsForeignStudent { get; set; }

        public bool IsForeignVisitor { get; set; }

        public bool IsVeli { get; set; }

        // ======================
        // OUTPUT (Result alanları)
        // ======================

        public bool Success { get; set; }

        public decimal Price { get; set; }

        public string? ReferenceNo { get; set; }

        public string? Message { get; set; }

        public DateTime Date { get; set; }
    }
}