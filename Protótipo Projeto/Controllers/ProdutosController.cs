using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySql.Data.MySqlClient;
using Protótipo_Projeto.Dados;
using Protótipo_Projeto.Models;

namespace Protótipo_Projeto.Controllers
{
    public class ProdutosController : Controller
    {
        public void produtosAdd()
        {
            Listas.produtos.Clear();

            string conexao = Conexao.Conecta();
            MySqlConnection con = new();
            con.ConnectionString = conexao;

            con.Open();

            MySqlCommand cn = new();

            cn.CommandText = $"select * from tb_produtos";

            cn.Connection = con;

            MySqlDataReader dr;
            dr = cn.ExecuteReader();

            while (dr.Read())
            {
                Produto produto = new();

                produto.Id = Convert.ToInt32(dr["Id"]);
                produto.Nome = Convert.ToString(dr["Nome"]);
                produto.ValorUnitario = Convert.ToDecimal(dr["ValorUnitario"]);
                produto.Estoque = Convert.ToInt32(dr["Estoque"]);
                produto.IdCateg = Convert.ToInt32(dr["CategoriaId"]);

                Console.WriteLine(produto.IdCateg);

                produto.NomeCateg = Listas.categorias.FirstOrDefault(ct => ct.Id == produto.IdCateg).Nome;

                Listas.produtos.Add(produto);
            }
        }
        public void categorias()
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

            con.Close();
        }
        public IActionResult Produtos()
        {
            categorias();
            produtosAdd();

            return View(Listas.produtos);
        }

        [HttpGet]
        public IActionResult Adicionar()
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

            con.Close();

            List<SelectListItem> Categoria = new List<SelectListItem>();

            Categoria = Listas.categorias.Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() }).ToList();

            ViewBag.cat = Categoria;

            foreach (var i in Categoria)
            {
                Console.WriteLine("\n" + Convert.ToInt32(i.Value));
            }

            return View();
        }

        [HttpPost]
        public IActionResult Adicionar(Produto produto)
        {
            string conexao = Conexao.Conecta();
            MySqlConnection con = new();
            con.ConnectionString = conexao;

            con.Open();

            MySqlCommand cn = con.CreateCommand();

            cn.CommandText = $"insert into tb_produtos(Nome, ValorUnitario, Estoque, CategoriaId)values(@Nome, @Val, @Estoque, @Cat)";

            cn.Parameters.Add("Nome", MySqlDbType.VarChar).Value = produto.Nome;
            cn.Parameters.Add("Val", MySqlDbType.Decimal).Value = produto.ValorUnitario;
            cn.Parameters.Add("Estoque", MySqlDbType.Int32).Value = produto.Estoque;
            cn.Parameters.Add("Cat", MySqlDbType.Int32).Value = produto.IdCateg;

            Console.WriteLine(produto.IdCateg);

            cn.Connection = con;

            cn.ExecuteNonQuery();

            return RedirectToAction("Produtos");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Produto produto = Listas.produtos.FirstOrDefault(pr => pr.Id == id);

            return View(produto);
        }

        [HttpPost]
        public IActionResult Delete(Produto produto)
        {
            Produto prod = Listas.produtos.FirstOrDefault(pr => pr.Id == produto.Id);

            string conexao = Conexao.Conecta();
            MySqlConnection con = new();
            con.ConnectionString = conexao;

            con.Open();

            MySqlCommand cn = con.CreateCommand();

            cn.CommandText = $"delete from tb_produtos where Id = @id";

            cn.Parameters.Add("id", MySqlDbType.Int32).Value = prod.Id;

            cn.Connection = con;

            MySqlDataReader dr;
            dr = cn.ExecuteReader();

            return RedirectToAction("Produtos");
        }
    }
}