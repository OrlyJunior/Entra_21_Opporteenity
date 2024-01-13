using ProjetoE21.Interfaces;
using ProjetoE21.Models;
using MySql.Data.MySqlClient;
using ProjetoE21.Dados;

namespace ProjetoE21.Dao
{
    public class DaoCadastro : ICrud<Jovem>
    {
        public bool adicionar(Jovem jovem)
        {
            MySqlConnection con = new();

            con.ConnectionString = Conexao.conecta();

            con.Open();

            try
            {
                MySqlCommand cm = con.CreateCommand();

                cm.CommandText = "insert into tb_cadastros(nome, email, fone, nascimento, estado, rua, numero, bairro, cidade, responsavel, foneResponsavel, senha)values(@nome, @email, @fone, @nascimento, @estado, @rua, @numero, @bairro, @cidade, @responsavel, @foneResponsavel, @senha)";

                cm.Parameters.Add("nome", MySqlDbType.VarChar).Value = jovem.Nome;
                cm.Parameters.Add("email", MySqlDbType.VarChar).Value = jovem.Email;
                cm.Parameters.Add("fone", MySqlDbType.VarChar).Value = jovem.Telefone;
                cm.Parameters.Add("nascimento", MySqlDbType.DateTime).Value = jovem.DataNascimento;
                cm.Parameters.Add("estado", MySqlDbType.VarChar).Value = jovem.Local.Estado;
                cm.Parameters.Add("rua", MySqlDbType.VarChar).Value = jovem.Local.Rua;
                cm.Parameters.Add("numero", MySqlDbType.Int32).Value = jovem.Local.Numero;
                cm.Parameters.Add("bairro", MySqlDbType.VarChar).Value = jovem.Local.Bairro;
                cm.Parameters.Add("cidade", MySqlDbType.VarChar).Value = jovem.Local.Cidade;
                cm.Parameters.Add("responsavel", MySqlDbType.VarChar).Value = jovem.Responsavel;
                cm.Parameters.Add("foneResponsavel", MySqlDbType.VarChar).Value = jovem.FoneResponsavel;
                cm.Parameters.Add("senha", MySqlDbType.VarChar).Value = jovem.Senha;

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

        public List<Jovem> consultar()
        {
            throw new NotImplementedException();
        }

        public void deletar(Jovem jovem)
        {
            throw new NotImplementedException();
        }

        public bool editar(Jovem jovem)
        {
            throw new NotImplementedException();
        }
    }
}
