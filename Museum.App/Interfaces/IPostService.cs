using Museum_App.Payment;

public interface IPosService
{
    PaymentResult Pay(decimal amount);
}