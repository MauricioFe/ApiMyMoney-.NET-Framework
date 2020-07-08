using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiMyMoney.Models
{
    public class ResetSenha
    {
        public int Id { get; set; }
        public string  Email { get; set; }
        public string Token { get; set; }
    }
}