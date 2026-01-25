namespace Museum_App.DTOs
{
    public class PaymentResultDto
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
        public string? ReferenceNo { get; set; }
    }
}
