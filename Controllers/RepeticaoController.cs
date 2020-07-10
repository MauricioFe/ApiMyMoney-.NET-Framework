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
    public class RepeticaoController : ApiController
    {
        List<Repeticao> repeticaoList = new List<Repeticao>();
        SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AppMyMoney;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataTable dt;
        Repeticao repeticao;



        [HttpGet]
        public List<Repeticao> GetRepeticao()
        {
            cmd = new SqlCommand("Select * From Repeticao", conn);
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            try
            {
                conn.Open();
                adapter.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    repeticao = new Repeticao();
                    repeticao.Id = Convert.ToInt32(item["id"]);
                    repeticao.Descricao = item["descricao"].ToString();
                    repeticao.Periodo = item["periodo"].ToString();
                    repeticao.NumOcorrencias = Convert.ToInt32(item["numOcorrencias"]);
                    repeticao.NumParcelas = Convert.ToInt32(item["numParcelas"]);

                    repeticaoList.Add(repeticao);
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
            return repeticaoList;
        }
        [HttpGet]
        public Repeticao GetRepeticaoById(int id)
        {
            cmd = new SqlCommand("Select * From Repeticao where id = " + id, conn);
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            try
            {
                conn.Open();
                adapter.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    repeticao = new Repeticao();
                    repeticao.Id = Convert.ToInt32(item["id"]);
                    repeticao.Descricao = item["descricao"].ToString();
                    repeticao.Periodo = item["periodo"].ToString();
                    repeticao.NumOcorrencias = Convert.ToInt32(item["numOcorrencias"]);
                    repeticao.NumParcelas = Convert.ToInt32(item["numParcelas"]);
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
            return repeticao;
        }

        [HttpPost]
        public void PostRepeticao(Repeticao repeticao)
        {
            cmd = new SqlCommand("insert into Repeticao values('" + repeticao.Descricao + "','" + repeticao.Periodo +
                "'," + repeticao.NumParcelas + "," + repeticao.NumOcorrencias + ")", conn);
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
        public void PutRepeticao(Repeticao repeticao, int id)
        {
            cmd = new SqlCommand("Update Repeticao set descricao = '" + repeticao.Descricao + "', periodo = '" + repeticao.Periodo +
                "', numParcelas = " + repeticao.NumParcelas + ", numOcorrencias =" + repeticao.NumOcorrencias + " where id = "+ id, conn);
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
        public void DeleteRepeticao(int id)
        {
            cmd = new SqlCommand("Delete From Repeticao where id = " + id, conn);
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
