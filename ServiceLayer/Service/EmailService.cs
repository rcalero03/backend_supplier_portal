using DomainLayer.Models;
using ServiceLayer.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Identity;




namespace ServiceLayer.Service
{
    public class EmailService : IEmailService
    {
        private readonly SmtpSettingsDto _smtpSettings;

        public EmailService ()
        {

            //IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);
            //IConfigurationRoot root = builder.Build();

            //Console.WriteLine($"Hello, {root["weather"]} world!");
        }

        public async Task SentEmailAsync(MailRequestDto request)
        {
            try
            {
                var message = new MimeMessage();

                //message.From.Add(new MailboxAddress(_smtpSettings.SenderName, _smtpSettings.SenderEmail));
                //message.To.Add(new MailboxAddress("", request.Email));
                //message.Subject = request.Subject;
                //message.Body = new TextPart("html") { Text = request.Body };

                //using (var client = new SmtpClient())
                //{
                //    await client.ConnectAsync(_smtpSettings.Server);
                //    await client.AuthenticateAsync(_smtpSettings.UserName, _smtpSettings.Password);
                //    await client.SendAsync(message);
                //    await client.DisconnectAsync(true);
                //}

                message.From.Add(new MailboxAddress("rmorck03@gmail.com", "rmorck03@gmail.com"));
                message.To.Add(new MailboxAddress("", request.Email));
                message.Subject = request.Subject;
                message.Body = new TextPart("html") { Text = request.Body };

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync("smtp.gmail.com", 587, false);
                    await client.AuthenticateAsync("rmorck03@gmail.com", "vjbadgukzhhqvzvd");
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }

                Console.WriteLine("Correo enviado exitosamente");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
