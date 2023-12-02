using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySql.Data.MySqlClient;
using Protótipo_Projeto.Dados;
using Protótipo_Projeto.Models;

namespace Protótipo_Projeto.Controllers
{
    public class ProdutosController : Controller
    {
        public IActionResult Produtos()
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
                produto.Categoria.Id = Convert.ToInt32(dr["CategoriaId"]);
                produto.Categoria.Nome = Listas.categorias.FirstOrDefault(ct => ct.Id == produto.Categoria.Id).Nome;

                Listas.produtos.Add(produto);
            }
            return View(Listas.produtos);
        }

        [HttpGet]
        public IActionResult Adicionar()
        {
            List<SelectListItem> Categoria = new List<SelectListItem>();

            Categoria = Listas.categorias.Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() }).ToList();

            ViewBag.categorias = Categoria;

            return View();
        }

        [HttpPost]
        public IActionResult Adicionar(Produto produto)
        {
            string conexao = Conexao.Conecta();
            MySqlConnection con = new();
            con.ConnectionString = conexao;

            MySqlCommand cn = con.CreateCommand();

            cn.CommandText = $"insert into tb_produtos(Nome, ValorUnitario, Estoque, CategoriaId)values(@Nome, @Val, @Estoque, @Cat)";

            cn.Parameters.Add("Nome", MySqlDbType.VarChar).Value = produto.Nome;
            cn.Parameters.Add("Val", MySqlDbType.Decimal).Value = produto.ValorUnitario;
            cn.Parameters.Add("Estoque", MySqlDbType.Int32).Value = produto.Estoque;
            cn.Parameters.Add("Cat", MySqlDbType.Int32).Value = Convert.ToInt32(produto.Categoria.Id);

            con.Open();

            cn.Connection = con;

            //Ocorre erro no ExecuteNonQuery
            cn.ExecuteNonQuery();

            return RedirectToAction("Produtos");
        }
    }
}