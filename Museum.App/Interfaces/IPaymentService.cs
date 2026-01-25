using Museum_App.DTOs;
using Museum_App.Payment;

namespace Museum_App.Interfaces
{
    public interface IPaymentService
    {
        PaymentResultDto ProcessPayment(PaymentRequest request);
    }
}
