using ApiMyMoney.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiMyMoney.Controllers
{
    public class UsuarioController : ApiController
    {
        List<Usuario> usuarioList = new List<Usuario>();
        SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AppMyMoney;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataTable dt;
        Usuario usuario;

        [HttpGet]
        public List<Usuario> GetUsuarios()
        {
            cmd = new SqlCommand("Select nome, email from Usuario", conn);
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            try
            {
                conn.Open();
                adapter.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    usuario = new Usuario();
                    usuario.Nome = item["nome"].ToString();
                    usuario.Email = item["email"].ToString();
                    usuarioList.Add(usuario);
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
            return usuarioList;
        }

        [HttpGet]
        public Usuario GetUsuarioById(int id)
        {
            cmd = new SqlCommand("Select nome, email from Usuario where id =" + id, conn);
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            try
            {
                conn.Open();
                adapter.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    usuario = new Usuario();
                    usuario.Nome = item["nome"].ToString();
                    usuario.Email = item["email"].ToString();
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
            return usuario;
        }



        [HttpPost]
        public void PostUsuario([FromBody] Usuario usuario)
        {
            cmd = new SqlCommand("Insert into Usuario Values('" + usuario.Nome + "', '" + usuario.Email + "', '" + usuario.Senha + "')", conn);

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
        public void PutUsuario([FromBody]  Usuario usuario, int id)
        {
            cmd = new SqlCommand("Update Usuario set nome = '" + usuario.Nome + "', email = '" + usuario.Email + "', senha = '" + usuario.Senha + "' where id = "+ id, conn);
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
        public void DeleteUsuario(int id)
        {
            cmd = new SqlCommand("Delete From Usuario  where id = " + id, conn);

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
