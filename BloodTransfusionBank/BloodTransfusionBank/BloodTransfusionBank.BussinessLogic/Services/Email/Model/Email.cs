using System;
using System.Collections.Generic;
using System.Text;

namespace BloodTransfusionBank.BussinessLogic.Services.Email
{
    public class Email
    {
        public string To { get; set; }
        public string Cc { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
    }
}
