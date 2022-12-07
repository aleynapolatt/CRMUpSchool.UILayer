using CrmUpSchool.BusinessLayer.Abstract;
using CrmUpSchool.DataAccessLayer.Concrete;
using CrmUpSchool.EntityLayer.Concrete;
using CrmUpSchool.UILayer.Areas.Employee.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrmUpSchool.UILayer.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class MessageController : Controller
    {
        //dependency injection
        private readonly IMessageService _messageService;
        //private readonly okunulur üzeri değiştirilemez yapıyoruz ileride kafa karışır yanlışlıkla sistemi .. 
        private readonly UserManager<AppUser> _userManager;
        //message için parametre mesaj gönderecek kişinin mail adresi / giriş yapaan kullancılardan çekiyoruz/ 
        
        public MessageController(IMessageService messageService, UserManager<AppUser> userManager)
        {
            _messageService = messageService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> SendMessage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(Message m)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            m.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            m.SenderEmail = user.Email;
            m.SenderName = user.Name + " " + user.Surname;
            using (var context = new Context())
            {
                m.ReceiverName = context.Users.Where(x => x.Email == m.ReceiverEmail).Select(x => x.Name + " " + x.Surname).FirstOrDefault();
            }
            _messageService.TInsert(m);
            return RedirectToAction("SendMessage");

            //ttggzffbxilxqxox = mailşifre
        }

        [HttpGet]
        public async Task<IActionResult> SendEmail()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendEmail(MailRequest p)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddress = new MailboxAddress("Admin","ebrarbasaraan1@gmail.com");
            mimeMessage.From.Add(mailboxAddress);
            //mail kimden gelecek bilgisi

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", p.ReceiverEmail); //mode
            mimeMessage.To.Add(mailboxAddressTo);
            //kime gidecek

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = p.EmailContent;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = p.EmailSubject;

            SmtpClient client = new SmtpClient();
            //Smtp : Simple mail transfer protokol 
            client.Connect("smtp.gmail.com", 587,false);
            client.Authenticate("ebrarbasaraan1@gmail.com", "ttggzffbxilxqxox");
            client.Send(mimeMessage);
            client.Disconnect(true);

            return View();
        }
    }
}
