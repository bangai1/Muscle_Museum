namespace Museum_App.Payment
{
    public class PaymentResult
    {
        public bool IsSuccess { get; set; }
        public string? ReferenceNo { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
