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
    public class TipoMovimentacaoController : ApiController
    {

        List<TipoMovimentacao> tipoMovimentacaoList = new List<TipoMovimentacao>();
        SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AppMyMoney;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataTable dt;
        TipoMovimentacao tipoMovimentacao;

        [HttpGet]
        public List<TipoMovimentacao> GetTipoMovimentacaos()
        {
            cmd = new SqlCommand("Select id, descricao from tipoMovimentacao", conn);
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();

            try
            {
                conn.Open();
                adapter.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    tipoMovimentacao = new TipoMovimentacao();
                    tipoMovimentacao.Id = Convert.ToInt32(item["id"]);
                    tipoMovimentacao.Descricao = item["descricao"].ToString();
                    tipoMovimentacaoList.Add(tipoMovimentacao);
                }
                return tipoMovimentacaoList;
            }
            catch (Exception e)
            {

                _ = e.StackTrace;
                return null;
            }
            finally
            {
                conn.Close();
            }

        }

        [HttpGet]
        public TipoMovimentacao GetTipoMovimentacaoById(int id)
        {
            cmd = new SqlCommand("Select id, descricao from tipoMovimentacao where id = " + id + "", conn);
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            try
            {
                conn.Open();
                adapter.Fill(dt);
                tipoMovimentacao = new TipoMovimentacao();
                foreach (DataRow item in dt.Rows)
                {
                    tipoMovimentacao.Id = Convert.ToInt32(item["id"]);
                    tipoMovimentacao.Descricao = item["descricao"].ToString();
                }
                return tipoMovimentacao;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }

        }


        [HttpPost]
        public void PostTipoMovimentacao(TipoMovimentacao tipoMovimentacao)
        {
            cmd = new SqlCommand("Insert Into TipoMovimentacao Values('" + tipoMovimentacao.Descricao + "')", conn);
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
        public void PutTipoMovimentacao(TipoMovimentacao tipoMovimentacao, int id)
        {
            cmd = new SqlCommand("Update TipoMovimentacao set descricao = '" + tipoMovimentacao.Descricao + "' where id = " + id, conn);
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
        public void DeleteTipoMovimentacao(int id)
        {
            cmd = new SqlCommand("Delete From TipoMovimentacao where id = " + id, conn);
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
