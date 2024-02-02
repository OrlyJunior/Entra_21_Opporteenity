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
            throw new NotImplementedException();
        }

        public void deletar(Emprego t)
        {
            throw new NotImplementedException();
        }

        public bool editar(Emprego t)
        {
            throw new NotImplementedException();
        }
    }
}
