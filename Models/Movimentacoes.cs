using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiMyMoney.Models
{
    public class Movimentacoes
    {
        public int Id { get; set; }
        public string  Descricao { get; set; }
        public double Valor { get; set; }
        public DateTime Data { get; set; }
        public string Observacoes { get; set; }
        public int Categoria_id { get; set; }
        public int TipoMovimentacao_id { get; set; }
        public int Repeticao_id { get; set; }
        public int Confirmado { get; set; }
    }
}