using Microsoft.AspNetCore.Mvc;
using ETickets.Models;
using MailKit.Net.Smtp;
using MimeKit;
using ETickets.ViewModels;
using System.Text;

namespace ETickets.Services
{
    public static class SendEmail
    {

        public static void Send(ApplicationUser user , List<CartViewModel> cartItems)
        {
            // Generate HTML content for cart items
            StringBuilder cartItemsHtml = new StringBuilder();
            foreach (var item in cartItems)
            {
                cartItemsHtml.Append($@"
                <h2> <strong>Movie Name: </strong>  {item.MovieName}</h2>
                <ol>
                <li><p> <strong> Date: </strong>{item.Date.ToShortDateString()}</p></li>
                <li><p><strong> Quantity: </strong>{item.Quantity}</P></li>
                </ol></hr>"
                );
            }
            string senderEmail = "ahmedkhaledabas@yahoo.com";
            string appPassword = "udixwwgiwfdyivkv";
            string senderName = "ETickets Web";
            string recipientEmail = user.Email;
            string subject = $"ETickets Teams";
            string body = $@"
        <html>
        <head>
            <style>
                /* Define your CSS styles here */
            </style>
        </head>
        <body>
            <div class='container'>
            <h3>Dear <span>{user.FirstName}</span> ,</h3>
                <p>Here are the items in your cart:</p>
                {cartItemsHtml.ToString()}
            </div>
        </body>
        </ html > ";
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(senderName, senderEmail));
            message.To.Add(new MailboxAddress(user.FirstName, recipientEmail));
            message.Subject = subject;

            var builder = new BodyBuilder();
            builder.HtmlBody = body; // You can also set TextBody for plain text

            message.Body = builder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                // Connect to the SMTP server
                client.Connect("smtp.mail.yahoo.com", 465, true);

                // Authenticate with the SMTP server
                client.Authenticate(senderEmail , appPassword);

                // Send the email
                client.Send(message);

                // Disconnect from the SMTP server
                client.Disconnect(true);
            }
        }
    }
}
