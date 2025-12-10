using System;

namespace DIP
{
	public class Program
	{

		//class CreditCardPayment
		//{
		//	public void Pay(int amount)
		//	{
		//		Console.WriteLine($"Paying Credit Card Payment : {amount} RS");
		//	}
		//}

		//class OrderService
		//{
		//	private CreditCardPayment creditCardPayment = new CreditCardPayment();
			
		//	public void PayAmount( int amount)
		//	{
		//		creditCardPayment.Pay(amount);
		//	}

		//}

		interface IPayment
		{
			void Pay(int amount);
		}

		class CreditCardPayment : IPayment
		{
			public void Pay(int amount)
			{
				Console.WriteLine($"Paying Credit Card Payment : {amount} RS");
			}
		}
		
		class UpiPayment : IPayment
		{
			public void Pay(int amount)
			{
				Console.WriteLine($"Paying UPI Payment : {amount} RS");
			}
		}

		class ApplePayment : IPayment
		{
			public void Pay(int amount)
			{
				Console.WriteLine($"Paying Apple Payment : {amount} RS");
			}
		}

		class OrderService
		{
			private IPayment paymentType; 

			public OrderService(IPayment userPaymentType)
			{
				paymentType = userPaymentType;
			}

			public void PayAmount(int amount)
			{
				paymentType.Pay(amount);
			}
			
			public void SetPayment(IPayment newPaymentType)
			{
				paymentType = newPaymentType;
			}
		}
		static public void Main()
		{
			CreditCardPayment creditCardPayment = new CreditCardPayment();
			UpiPayment upiPayment = new UpiPayment();

			OrderService orderService = new OrderService(creditCardPayment);
			orderService.PayAmount(1000);
			orderService.SetPayment(upiPayment);
			orderService.PayAmount(1000);

		}
	}
}
