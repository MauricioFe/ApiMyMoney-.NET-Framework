using ApiMyMoney.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiMyMoney.Controllers
{
    public class CategoriaController : ApiController
    {
        List<Categoria> categorias = new List<Categoria>();
        SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AppMyMoney;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataTable dt;
        Categoria categoria;

        [HttpGet]
        public List<Categoria> GetCategorias()
        {
            cmd = new SqlCommand("Select id, descricao from categoria", conn);
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();

            try
            {
                conn.Open();
                adapter.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    categoria = new Categoria();
                    categoria.Id = Convert.ToInt32(item["id"]);
                    categoria.Descricao = item["descricao"].ToString();
                    categorias.Add(categoria);
                }
                return categorias;
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
        public Categoria GetCategoriaById(int id)
        {
            cmd = new SqlCommand("Select id, descricao from categoria where id = " + id + "", conn);
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            try
            {
                conn.Open();
                adapter.Fill(dt);
                categoria = new Categoria();
                foreach (DataRow item in dt.Rows)
                {
                    categoria.Id = Convert.ToInt32(item["id"]);
                    categoria.Descricao = item["descricao"].ToString();
                }
                return categoria;
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
        public void PostCategoria(Categoria categoria)
        {
            cmd = new SqlCommand("Insert Into Categoria Values('" + categoria.Descricao+ "')", conn);
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
        public void PutCategoria(Categoria categoria, int id)
        {
            cmd = new SqlCommand("Update Categoria set descricao = '" + categoria.Descricao + "' where id = "+id, conn);
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
        public void DeleteCategoria(int id)
        {
            cmd = new SqlCommand("Delete From Categoria where id = " + id, conn);
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
