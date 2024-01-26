using MySql.Data.MySqlClient;
using ProjetoE21.Dados;
using ProjetoE21.Interfaces;
using ProjetoE21.Models;

namespace ProjetoE21.Dao
{
    public class DaoEmpresa : ICrud<Empresa>
    {
        public bool adicionar(Empresa empresa)
        {
            MySqlConnection con = new();

            con.ConnectionString = Conexao.conecta();

            con.Open();

            try
            {
                MySqlCommand cm = con.CreateCommand();

                cm.CommandText = "insert into tb_empresas(nome, email, telefone, estado, rua, numero, bairro, cidade, cnpj, senha)values(@nome, @email, @fone, @estado, @rua, @numero, @bairro, @cidade, @cnpj, @senha)";

                cm.Parameters.Add("nome", MySqlDbType.VarChar).Value = empresa.Nome;
                cm.Parameters.Add("email", MySqlDbType.VarChar).Value = empresa.Email;
                cm.Parameters.Add("fone", MySqlDbType.VarChar).Value = empresa.Telefone;
                cm.Parameters.Add("estado", MySqlDbType.VarChar).Value = empresa.Local.Estado;
                cm.Parameters.Add("rua", MySqlDbType.VarChar).Value = empresa.Local.Rua;
                cm.Parameters.Add("numero", MySqlDbType.Int32).Value = empresa.Local.Numero;
                cm.Parameters.Add("bairro", MySqlDbType.VarChar).Value = empresa.Local.Bairro;
                cm.Parameters.Add("cidade", MySqlDbType.VarChar).Value = empresa.Local.Cidade;
                cm.Parameters.Add("cnpj", MySqlDbType.VarChar).Value = empresa.Cnpj;
                cm.Parameters.Add("senha", MySqlDbType.VarChar).Value = empresa.Senha;

                cm.Connection = con;

                cm.ExecuteNonQuery();
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return true;
        }

        public List<Empresa> consultar()
        {
            throw new NotImplementedException();
        }

        public void deletar(Empresa t)
        {
            throw new NotImplementedException();
        }

        public bool editar(Empresa t)
        {
            throw new NotImplementedException();
        }
    }
}
