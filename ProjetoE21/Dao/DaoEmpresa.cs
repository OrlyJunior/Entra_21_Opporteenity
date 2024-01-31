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

                cm.CommandText = "insert into tb_empresas(nome, email, fone, estado, rua, numero, bairro, cidade, cnpj, senha)values(@nome, @email, @fone, @estado, @rua, @numero, @bairro, @cidade, @cnpj, @senha)";

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
            List<Empresa> empresas = new();

            MySqlConnection con = new();

            con.ConnectionString = Conexao.conecta();

            con.Open();

            try
            {
                MySqlCommand cm = con.CreateCommand();

                cm.CommandText = "select * from tb_empresas";

                cm.Connection = con;

                MySqlDataReader dr;
                dr = cm.ExecuteReader();

                while (dr.Read())
                {
                    Empresa empresa = new();
                    empresa.Local = new();

                    empresa.Id = Convert.ToInt32(dr["id"]);
                    empresa.Nome = Convert.ToString(dr["nome"]);
                    empresa.Email = Convert.ToString(dr["email"]);
                    empresa.Telefone = Convert.ToString(dr["fone"]);
                    empresa.Local.Rua = Convert.ToString(dr["rua"]);
                    empresa.Local.Numero = Convert.ToInt32(dr["numero"]);
                    empresa.Local.Bairro = Convert.ToString(dr["bairro"]);
                    empresa.Local.Cidade = Convert.ToString(dr["cidade"]);
                    empresa.Local.Estado = Convert.ToString(dr["estado"]);
                    empresa.Cnpj = Convert.ToString(dr["cnpj"]);
                    empresa.Senha = Convert.ToString(dr["senha"]);

                    empresas.Add(empresa);
                }
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return empresas;
        }

        public void deletar(Empresa t)
        {
            throw new NotImplementedException();
        }

        public bool editar(Empresa empresa)
        {
            MySqlConnection con = new();

            con.ConnectionString = Conexao.conecta();

            con.Open();

            try
            {
                MySqlCommand cm = con.CreateCommand();

                cm.CommandText = "update tb_empresas set nome = @nome, email = @email, fone = @fone, rua = @rua, numero = @numero, bairro = @bairro, cidade = @cidade, estado = @estado, cnpj = @cnpj, senha = @senha where id = @id";

                cm.Parameters.Add("id", MySqlDbType.Int32).Value = empresa.Id;
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

            Listas.cadastrosE = consultar();

            Usuario.LogadoE = empresa;

            return true;
        }
    }
}
