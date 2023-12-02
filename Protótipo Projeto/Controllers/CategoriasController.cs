using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Protótipo_Projeto.Models;
using Protótipo_Projeto.Dados;

namespace Protótipo_Projeto.Controllers
{
    public class CategoriasController : Controller
    {
        public IActionResult Categorias()
        {
            Listas.categorias.Clear();

            string conexao = Conexao.Conecta();
            MySqlConnection con = new();
            con.ConnectionString = conexao;

            con.Open();

            MySqlCommand cn = new();

            cn.CommandText = $"select * from tb_categorias";

            cn.Connection = con;

            MySqlDataReader dr;
            dr = cn.ExecuteReader();

            while (dr.Read())
            {
                Categoria categoria = new();

                categoria.Id = Convert.ToInt32(dr["IdCategoria"]);
                categoria.Nome = Convert.ToString(dr["NomeCategoria"]);

                Listas.categorias.Add(categoria);
            }

            return View(Listas.categorias);
        }

        [HttpGet]
        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Adicionar(Categoria categoria)
        {
            string conexao = Conexao.Conecta();
            MySqlConnection con = new();
            con.ConnectionString = conexao;

            MySqlCommand cn = con.CreateCommand();

            cn.CommandText = $"insert into tb_categorias(NomeCategoria)values(@Nome)";

            cn.Parameters.Add("Nome", MySqlDbType.VarChar).Value = categoria.Nome;

            con.Open();

            cn.Connection = con;

            cn.ExecuteNonQuery();

            return RedirectToAction("Categorias");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Categoria categoria = Listas.categorias.FirstOrDefault(ct => ct.Id == id);

            return View(categoria);
        }

        [HttpPost]
        public IActionResult Details(Categoria categoria)
        {
            return RedirectToAction("Categorias");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Categoria categoria = Listas.categorias.FirstOrDefault(ct => ct.Id == id);

            return View(categoria);
        }

        [HttpPost]
        public IActionResult Delete(Categoria categoria)
        {
            Categoria categ = Listas.categorias.FirstOrDefault(ct => ct.Id == categoria.Id);

            string conexao = Conexao.Conecta();
            MySqlConnection con = new();
            con.ConnectionString = conexao;

            MySqlCommand cn = con.CreateCommand();

            cn.CommandText = @"delete from tb_categorias where IdCategoria = @id";

            cn.Parameters.Add("id", MySqlDbType.Int32).Value = categ.Id;

            con.Open();

            cn.Connection = con;

            MySqlDataReader dr;
            dr = cn.ExecuteReader();

            return RedirectToAction("Categorias");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Categoria categoria = Listas.categorias.FirstOrDefault(ct => ct.Id == id);

            return View(categoria);
        }

        [HttpPost]
        public IActionResult Edit(Categoria categ)
        {
            Categoria categoria = Listas.categorias.FirstOrDefault(ct => ct.Id == categ.Id);

            categoria.Id = categ.Id;
            categoria.Nome = categ.Nome;

            string conexao = Conexao.Conecta();
            MySqlConnection con = new();
            con.ConnectionString = conexao;

            MySqlCommand cn = con.CreateCommand();

            cn.CommandText = @"update tb_categorias set NomeCategoria = @nome where id = @id";

            cn.Parameters.Add("nome", MySqlDbType.VarChar).Value = categoria.Nome;
            cn.Parameters.Add("id", MySqlDbType.Int32).Value = categoria.Id;

            con.Open();

            cn.Connection = con;

            MySqlDataReader dr;
            dr = cn.ExecuteReader();

            return RedirectToAction("Categorias");
        }
    }
}
