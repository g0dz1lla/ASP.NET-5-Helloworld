using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication20.ViewModels.Message
{
    public class MessageViewModel
    {
        [Required]
        public Guid Guid { get; set; }
        public string Text { get; set; }
        public int? HoursToDelete { get; set; }
        public string PasswordHash { get; set; }
    }
}
