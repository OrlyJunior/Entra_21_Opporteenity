using MySql.Data.MySqlClient;
using ProjetoE21.Dados;
using ProjetoE21.Interfaces;
using ProjetoE21.Models;

namespace ProjetoE21.Dao
{
    public class DaoCurriculo : ICrud<Curriculo>
    {
        public bool adicionar(Curriculo curriculo)
        {
            MySqlConnection con = new();

            con.ConnectionString = Conexao.conecta();

            con.Open();

            try
            {
                MySqlCommand cm = con.CreateCommand();

                cm.CommandText = "insert into tb_curriculos(nome, estado, rua, numero, bairro, cidade, telefone, email, redesocial, objetivo, escola, idiomas, cursos, experiencia)values(@nome, @estado, @rua, @numero, @bairro, @cidade, @telefone, @email, @redesocial, @objetivo, @escola, @idiomas, @cursos, @experiencia)";

                cm.Parameters.Add("nome", MySqlDbType.VarChar).Value = curriculo.Nome;
                cm.Parameters.Add("email", MySqlDbType.VarChar).Value = curriculo.Email;
                cm.Parameters.Add("telefone", MySqlDbType.VarChar).Value = curriculo.Telefone;
                cm.Parameters.Add("estado", MySqlDbType.VarChar).Value = curriculo.Local.Estado;
                cm.Parameters.Add("rua", MySqlDbType.VarChar).Value = curriculo.Local.Rua;
                cm.Parameters.Add("numero", MySqlDbType.Int32).Value = curriculo.Local.Numero;
                cm.Parameters.Add("bairro", MySqlDbType.VarChar).Value = curriculo.Local.Bairro;
                cm.Parameters.Add("cidade", MySqlDbType.VarChar).Value = curriculo.Local.Cidade;
                cm.Parameters.Add("redesocial", MySqlDbType.VarChar).Value = curriculo.RedeSocial;
                cm.Parameters.Add("objetivo", MySqlDbType.VarChar).Value = curriculo.Objetivo;
                cm.Parameters.Add("escola", MySqlDbType.VarChar).Value = curriculo.Escola;
                cm.Parameters.Add("idiomas", MySqlDbType.VarChar).Value = curriculo.Idiomas;
                cm.Parameters.Add("cursos", MySqlDbType.VarChar).Value = curriculo.Cursos;
                cm.Parameters.Add("experiencia", MySqlDbType.VarChar).Value = curriculo.Experiencia;

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

        public List<Curriculo> consultar()
        {
            List<Curriculo> curriculos = new();

            MySqlConnection con = new();
            con.ConnectionString = Conexao.conecta();

            con.Open();

            try
            {
                MySqlCommand cm = con.CreateCommand();

                cm.CommandText = @"select * from tb_curriculos";

                cm.Connection = con;

                MySqlDataReader dr;
                dr = cm.ExecuteReader();

                while (dr.Read())
                {
                    Curriculo curriculo = new();

                    curriculo.Id = Convert.ToInt32(dr["id"]);
                    curriculo.Nome = Convert.ToString(dr["nome"]);
                    
                    curriculo.Experiencia = Convert.ToString(dr["experiencia"]);
                    curriculo.Email = Convert.ToString(dr["email"]);

                    curriculo.Local = new();

                    curriculo.Local.Estado = Convert.ToString(dr["estado"]);
                    curriculo.Local.Cidade = Convert.ToString(dr["cidade"]);
                    curriculo.Local.Numero = Convert.ToInt32(dr["numero"]);
                    curriculo.Local.Rua = Convert.ToString(dr["rua"]);

                    curriculo.RedeSocial = Convert.ToString(dr["redesocial"]);
                    curriculo.Idiomas = Convert.ToString(dr["idiomas"]);
                    curriculo.Cursos = Convert.ToString(dr["cursos"]);
                    curriculo.Telefone = Convert.ToString(dr["telefone"]);
                    curriculo.Objetivo = Convert.ToString(dr["objetivo"]);

                    curriculos.Add(curriculo);
                }
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return curriculos;
        }

        public void deletar(Curriculo t)
        {
            throw new NotImplementedException();
        }

        public bool editar(Curriculo t)
        {
            throw new NotImplementedException();
        }

        public bool candidatar(int idCurriculo, int idEmprego)
        {
            return true;
        }
    }
}
