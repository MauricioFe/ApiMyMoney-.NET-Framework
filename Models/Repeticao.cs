using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiMyMoney.Models
{
    public class Repeticao
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Periodo { get; set; }
        public int NumParcelas { get; set; }
        public int NumOcorrencias { get; set; }
    }
}