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
            List<Jovem> jovens = new();

            MySqlConnection con = new();

            con.ConnectionString = Conexao.conecta();

            con.Open();

            try
            {
                MySqlCommand cm = con.CreateCommand();

                cm.CommandText = "select * from tb_cadastros";

                cm.Connection = con;

                MySqlDataReader dr;
                dr = cm.ExecuteReader();

                while (dr.Read())
                {
                    Jovem jovem = new();
                    jovem.Local = new();

                    jovem.Id = Convert.ToInt32(dr["id"]);
                    jovem.Nome = Convert.ToString(dr["nome"]);
                    jovem.Email = Convert.ToString(dr["email"]);
                    jovem.Telefone = Convert.ToString(dr["fone"]);
                    jovem.DataNascimento = Convert.ToDateTime(dr["nascimento"]);
                    jovem.Local.Rua = Convert.ToString(dr["rua"]);
                    jovem.Local.Numero = Convert.ToInt32(dr["numero"]);
                    jovem.Local.Bairro = Convert.ToString(dr["bairro"]);
                    jovem.Local.Cidade = Convert.ToString(dr["cidade"]);
                    jovem.Local.Estado = Convert.ToString(dr["estado"]);
                    jovem.Responsavel = Convert.ToString(dr["responsavel"]);
                    jovem.FoneResponsavel = Convert.ToString(dr["foneResponsavel"]);
                    jovem.Senha = Convert.ToString(dr["senha"]);

                    jovens.Add(jovem);
                }
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return jovens;
        }

        public void deletar(Jovem jovem)
        {
            throw new NotImplementedException();
        }

        public bool editar(Jovem jovem)
        {
            MySqlConnection con = new();

            con.ConnectionString = Conexao.conecta();

            con.Open();

            try
            {
                MySqlCommand cm = con.CreateCommand();

                cm.CommandText = "update tb_cadastros set nome = @nome, email = @email, fone = @fone, nascimento = @nascimento, rua = @rua, numero = @numero, bairro = @bairro, cidade = @cidade, estado = @estado, responsavel = @responsavel, foneResponsavel = @foneResponsavel, senha = @senha where id = @id";

                cm.Parameters.Add("id", MySqlDbType.Int32).Value = jovem.Id;
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

                MySqlDataReader dr;
                dr = cm.ExecuteReader();
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }

            Listas.cadastros = consultar();

            Usuario.logado = jovem;

            return true;
        }
    }
}
