using Museum_App.DTOs;
using Museum_App.Interfaces;
using Museum_App.Payment;

namespace Museum_Infrastructure.Services
{
    public class PosPaymentService : IPaymentService
    {
        public PaymentResultDto ProcessPayment(PaymentRequest request)
        {
            if (request.Amount <= 0)
            {
                return new PaymentResultDto
                {
                    IsSuccess = false,
                    ErrorMessage = "Ödeme tutarı geçersiz"
                };
            }

            return new PaymentResultDto
            {
                IsSuccess = true,
                ReferenceNo = Guid.NewGuid().ToString()
            };
        }
    }
}
