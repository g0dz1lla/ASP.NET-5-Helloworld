using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication20.ViewModels.HiddenMessage
{
    public class HiddenMessageViewModel
    {
        public Guid Guid { get; set; }
        public string PasswordHash { get; set; }
    }
}
