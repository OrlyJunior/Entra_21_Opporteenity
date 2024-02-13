using MySql.Data.MySqlClient;
using ProjetoE21.Dados;
using ProjetoE21.Interfaces;
using ProjetoE21.Models;

namespace ProjetoE21.Dao
{
    public class DaoFavoritos : ICrud<Emprego>
    {
        public bool adicionar(Emprego emprego)
        {
            MySqlConnection con = new();

            con.ConnectionString = Conexao.conecta();

            con.Open();

            try
            {
                MySqlCommand cm = con.CreateCommand();

                cm.CommandText = "insert into tb_favoritos(idUser, idVaga)values(@idUser, @idVaga)";

                cm.Parameters.Add("idUser", MySqlDbType.Int32).Value = Usuario.LogadoJ.Id;
                cm.Parameters.Add("idVaga", MySqlDbType.Int32).Value = emprego.Id;

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

        public List<Emprego> consultar()
        {
            List<int> idFavoritos = new();

            List<Emprego> favoritos = new();

            MySqlConnection con = new();

            con.ConnectionString = Conexao.conecta();

            con.Open();

            try
            {
                MySqlCommand cm = con.CreateCommand();

                cm.CommandText = "select idVaga from tb_favoritos where idUser = @idUser";

                cm.Parameters.Add("idUser", MySqlDbType.Int32).Value = Usuario.LogadoJ.Id;

                cm.Connection = con;

                MySqlDataReader dr;
                dr = cm.ExecuteReader();

                while (dr.Read())
                {
                    int favorito = Convert.ToInt32(dr["idVaga"]);

                    idFavoritos.Add(favorito);
                }

                dr.Close();

                con.Close();

                con.Open();

                foreach (int i in idFavoritos)
                {
                    MySqlCommand cn = con.CreateCommand();

                    cn.CommandText = "select * from tb_empregos where id = @id";

                    cn.Parameters.Add("id", MySqlDbType.Int32).Value = i;

                    cn.Connection = con;

                    MySqlDataReader reader;
                    reader = cn.ExecuteReader();

                    while (reader.Read())
                    {
                        Emprego empre = new();

                        empre.Id = Convert.ToInt32(reader["id"]);
                        empre.Descricao = Convert.ToString(reader["descricao"]);

                        empre.Empresa = new();
                        empre.Local = new();

                        empre.Empresa.Nome = Convert.ToString(reader["empresaNome"]);
                        empre.HoraDeInicio = Convert.ToDateTime(reader["horaInicio"]);
                        empre.HoraDeFim = Convert.ToDateTime(reader["horaTermino"]);
                        empre.Salario = Convert.ToDecimal(reader["salario"]);
                        empre.DiasTrabalhados = Convert.ToInt32(reader["diasTrabalhados"]);
                        empre.Local.Estado = Convert.ToString(reader["estado"]);
                        empre.Local.Cidade = Convert.ToString(reader["cidade"]);
                        empre.Local.Rua = Convert.ToString(reader["rua"]);
                        empre.Local.Bairro = Convert.ToString(reader["bairro"]);
                        empre.Local.Numero = Convert.ToInt32(reader["numero"]);

                        favoritos.Add(empre);
                    }

                    reader.Close();
                }
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return favoritos;
        }

        public void deletar(Emprego emprego)
        {
            MySqlConnection con = new();

            con.ConnectionString = Conexao.conecta();

            con.Open();

            try
            {
                MySqlCommand cm = con.CreateCommand();

                cm.CommandText = "delete from tb_favoritos where idUser = @idUser and idVaga = @idVaga";

                cm.Parameters.Add("idUser", MySqlDbType.Int32).Value = Usuario.LogadoJ.Id;
                cm.Parameters.Add("idVaga", MySqlDbType.Int32).Value = emprego.Id;

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
        }

        public bool editar(Emprego t)
        {
            throw new NotImplementedException();
        }
    }
}
