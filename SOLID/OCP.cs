using System;

namespace OCP
{
	class Program
	{

		//class NotificationService
		//{
		//	public void Send(string message , string type)
		//	{
		//		if (type.ToLower() == "email")
		//		{
		//			Console.WriteLine($"Sending Email : {message}");
		//		}else if (type.ToLower() == "sms")
		//		{
		//			Console.WriteLine($"Sending SMS : {message}");
		//		}else if (type.ToLower() == "whatsapp")
		//		{
		//			Console.WriteLine($"Sending whatsapp message : {message}");
		//		}
		//		// If we want to add more types , then we need to modify this class .
		//	}
		//}

		interface INotification
		{
			void Send(string message);
		}

		class EmailNotification : INotification
		{
			public void Send(string message)
			{
				Console.WriteLine($"Sending Email Notification : {message}");
			}
		}

		class SmsNotification : INotification
		{
			public void Send(string message)
			{
				Console.WriteLine($"Sending SMS Notification : {message}");
			}
		}

		class WhatsappNotification : INotification
		{
			public void Send(string message)
			{
				Console.WriteLine($"Sending Whatsapp Notification : {message}");
			}
		}

		class NotificationService
		{
			public void Send( INotification notificationType , string message)
			{
				notificationType.Send(message);
			}
		} 


		static public void Main()
		{
			NotificationService notificationService = new NotificationService();

			EmailNotification emailNotification = new EmailNotification();
			SmsNotification smsNotification = new SmsNotification();
			WhatsappNotification whatsappNotification = new WhatsappNotification();


			notificationService.Send(emailNotification, "Hello Vinod");
			notificationService.Send(smsNotification, "Hello Hruday");
		}



	}
}
