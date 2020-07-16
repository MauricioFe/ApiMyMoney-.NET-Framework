using ApiMyMoney.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiMyMoney.Controllers
{
    public class MovimentacoesController : ApiController
    {
        List<Movimentacoes> movimentacaoList = new List<Movimentacoes>();
        SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AppMyMoney;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataTable dt;
        Movimentacoes movimentacao;



        [HttpGet]
        public List<Movimentacoes> GetMovimentacoes()
        {
            cmd = new SqlCommand("Select Movimentacao.id, Movimentacao.descricao, Movimentacao.valor, Movimentacao.data, Movimentacao.observacoes, Movimentacao.confirmado," +
                    " TipoMovimentacao.descricao as tipoMovimentacao, Categoria.descricao as categoria, Repeticao.descricao as repeticao, Usuario.nome as usuario" +
                    " From Movimentacao" +
                    " inner join TipoMovimentacao on tipoMovimentacao.id = Movimentacao.tipoMovimentacao_id" +
                    " inner join Categoria on categoria.id = movimentacao.categoria_id" +
                    " inner join Repeticao on repeticao.id = movimentacao.repeticao_id" +
                    " inner join Usuario on usuario.id = movimentacao.usuario_id", conn);
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            try
            {
                conn.Open();
                adapter.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    movimentacao = new Movimentacoes();
                    movimentacao.Id = Convert.ToInt32(item["id"]);
                    movimentacao.Descricao = item["descricao"].ToString();
                    movimentacao.Valor = Convert.ToDecimal(item["valor"]);
                    movimentacao.Data = Convert.ToDateTime(item["data"]);
                    movimentacao.Observacoes = item["observacoes"].ToString();
                    movimentacao.Categoria = item["categoria"].ToString();
                    movimentacao.TipoMovimentacao = item["tipoMovimentacao"].ToString();
                    movimentacao.Repeticao = item["repeticao"].ToString();
                    movimentacao.Usuario = item["usuario"].ToString();
                    movimentacao.Confirmado = Convert.ToInt32(item["confirmado"]);
                    movimentacaoList.Add(movimentacao);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return movimentacaoList;
        }
        [HttpGet]
        public Movimentacoes GetMovimentacoesById(int id)
        {
            cmd = new SqlCommand("Select Movimentacao.id, Movimentacao.descricao, Movimentacao.valor, Movimentacao.data, Movimentacao.observacoes, Movimentacao.confirmado," +
           " TipoMovimentacao.descricao as tipoMovimentacao, Categoria.descricao as categoria, Repeticao.descricao as repeticao, Usuario.nome as usuario" +
           " From Movimentacao" +
           " inner join TipoMovimentacao on tipoMovimentacao.id = Movimentacao.tipoMovimentacao_id" +
           " inner join Categoria on categoria.id = movimentacao.categoria_id" +
           " inner join Repeticao on repeticao.id = movimentacao.repeticao_id" +
           " inner join Usuario on usuario.id = movimentacao.usuario_id" +
           " where Movimentacao.id = " +id, conn);
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            try
            {
                conn.Open();
                adapter.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    movimentacao = new Movimentacoes();
                    movimentacao.Id = Convert.ToInt32(item["id"]);
                    movimentacao.Descricao = item["descricao"].ToString();
                    movimentacao.Valor = Convert.ToDecimal(item["valor"]);
                    movimentacao.Data = Convert.ToDateTime(item["data"]);
                    movimentacao.Observacoes = item["observacoes"].ToString();
                    movimentacao.Categoria = item["categoria"].ToString();
                    movimentacao.TipoMovimentacao = item["tipoMovimentacao"].ToString();
                    movimentacao.Repeticao = item["repeticao"].ToString();
                    movimentacao.Usuario = item["usuario"].ToString();
                    movimentacao.Confirmado = Convert.ToInt32(item["confirmado"]);
                    movimentacaoList.Add(movimentacao);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
            return movimentacao;
        }

        [HttpPost]
        public void PostMovimentacoes(Movimentacoes movimentacao)
        {
            cmd = new SqlCommand("insert into Movimentacao values('" + movimentacao.Descricao + "', " + movimentacao.Valor +
                ", '" + movimentacao.Data + "', '" + movimentacao.Observacoes + "', " + movimentacao.Categoria_id + ", " +
                movimentacao.TipoMovimentacao_id + ", " + movimentacao.Repeticao_id + ", " + movimentacao.Usuario_id + ", " + movimentacao.Confirmado + ")", conn);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
        }
        [HttpPut]
        public void PutMovimentacoes(Movimentacoes movimentacao, int id)
        {
            cmd = new SqlCommand("Update Movimentacao set descricao = '" + movimentacao.Descricao + "', valor =" + movimentacao.Valor +
                ", data = '" + movimentacao.Data + "', observacoes = '" + movimentacao.Observacoes + "', categoria_id = " + movimentacao.Categoria_id +
                ", tipoMovimentacao_id = " + movimentacao.TipoMovimentacao_id + ", repeticao_id = " + movimentacao.Repeticao_id + ", usuario_id = " + movimentacao.Usuario_id +
                ", confirmado = " + movimentacao.Confirmado + " where id = " + id, conn);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
        }
        [HttpDelete]
        public void DeleteMovimentacoes(int id)
        {
            cmd = new SqlCommand("Delete From Movimentacao where id = " + id, conn);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
