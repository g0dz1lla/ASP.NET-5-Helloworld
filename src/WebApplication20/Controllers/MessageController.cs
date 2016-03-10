using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using WebApplication20.Models;
using WebApplication20.ViewModels.Message;
using WebApplication20.ViewModels.HiddenMessage;
using System.Security.Cryptography;


// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication20.Controllers
{
    //[Route("api/[controller]")]
    [Route("Message")]
    public class MessageController : Controller
    {
        private readonly ApplicationDbContext context;
        public MessageController(ApplicationDbContext Context)
        {
            this.context = Context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        [Route("ReadNote/{guid}")]
        public string ReadNote(HiddenMessageViewModel hiddenMessage)
        {
            var msg = context.Messages.First(t => t.Guid == hiddenMessage.Guid && t.StateId == 1 
            && 
            (String.IsNullOrEmpty(t.PasswordHash) || t.PasswordHash == HashString(hiddenMessage.PasswordHash)));
            var txt = "The note is absent";
            if (msg != null)
            {
                msg.StateId = 2;
                context.SaveChanges();
                txt = msg.Text;
            }
            return txt;

        }

        // GET api/values/5
        [HttpGet("{guid}")]
        public IActionResult Get(Guid guid)
        {
            if (context.Messages.Any(t => t.Guid == guid && t.StateId == 1
            && (
                (t.CreateDate.AddHours((double)t.HoursToDelete) > DateTime.Now)
                || (t.HoursToDelete == 0)
          )))
                return Redirect("http://localhost:43815/HiddenMessage.html?guid=" + guid);
            else
                return Redirect("http://localhost:43815/Message.html");
        }


        public static string HashString(string password)
        {
            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, 32);
            rfc2898DeriveBytes.IterationCount = 10000;
            return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(20));
        }

        // POST api/values
        [HttpPost]
        public Guid Post([FromBody]MessageViewModel message)
        {
            var guid = Guid.NewGuid();

            string hash = string.Empty;

            if (!String.IsNullOrEmpty(message.PasswordHash))
            {
                hash = HashString(message.PasswordHash);
            }


            var msg = new Message();
            msg.Text = message.Text;
            msg.Guid = guid;
            msg.StateId = 1;
            msg.PasswordHash = hash;
            msg.HoursToDelete = message.HoursToDelete;
            msg.CreateDate = DateTime.Now;
            context.Messages.Add(msg);
            context.SaveChanges();

            return guid;
        }

        // PUT api/values/5
        [HttpPut("{guid}")]
        public void Put(Guid guid, [FromBody]string value)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Messages.FirstOrDefault(t => t.Guid == guid).StateId = 2;
                context.SaveChanges();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{guid}")]
        public void Delete(string guid)
        {
        }
    }
}
