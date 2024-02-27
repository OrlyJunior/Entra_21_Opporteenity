using MySql.Data.MySqlClient;
using ProjetoE21.Dados;
using ProjetoE21.Interfaces;
using ProjetoE21.Models;

namespace ProjetoE21.Dao
{
    public class DaoEmprego : ICrud<Emprego>
    {
        public bool adicionar(Emprego emprego)
        {
            MySqlConnection con = new();

            con.ConnectionString = Conexao.conecta();

            con.Open();

            try
            {
                MySqlCommand cm = con.CreateCommand();

                cm.CommandText = @"insert into tb_empregos(descricao, empresaNome, empresaId, estado, cidade, bairro, rua, numero, horaInicio, horaTermino, salario, diasTrabalhados)values(@descricao, @contratante, @empresaId, @estado, @cidade, @bairro, @rua, @numero, @inicio, @fim, @salario, @diasT)";

                cm.Parameters.Add("descricao", MySqlDbType.VarChar).Value = emprego.Descricao;
                cm.Parameters.Add("contratante", MySqlDbType.VarChar).Value = emprego.Empresa.Nome;
                cm.Parameters.Add("empresaId", MySqlDbType.Int32).Value = emprego.Empresa.Id;
                cm.Parameters.Add("estado", MySqlDbType.VarChar).Value = emprego.Local.Estado;
                cm.Parameters.Add("cidade", MySqlDbType.VarChar).Value = emprego.Local.Cidade;
                cm.Parameters.Add("bairro", MySqlDbType.VarChar).Value = emprego.Local.Bairro;
                cm.Parameters.Add("rua", MySqlDbType.VarChar).Value = emprego.Local.Rua;
                cm.Parameters.Add("numero", MySqlDbType.Int32).Value = emprego.Local.Numero;
                cm.Parameters.Add("inicio", MySqlDbType.VarChar).Value = Convert.ToString(emprego.HoraDeInicio.TimeOfDay);
                cm.Parameters.Add("fim", MySqlDbType.VarChar).Value = Convert.ToString(emprego.HoraDeFim.TimeOfDay);
                cm.Parameters.Add("salario", MySqlDbType.Decimal).Value = emprego.Salario;
                cm.Parameters.Add("diasT", MySqlDbType.Int32).Value = emprego.DiasTrabalhados;

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
            List<Emprego> empregos = new();

            MySqlConnection con = new();
            con.ConnectionString = Conexao.conecta();

            con.Open();

            try
            {
                MySqlCommand cm = con.CreateCommand();

                cm.CommandText = @"select * from tb_empregos";

                cm.Connection = con;

                MySqlDataReader dr;
                dr = cm.ExecuteReader();

                while (dr.Read())
                {
                    Emprego empre = new();

                    empre.Id = Convert.ToInt32(dr["id"]);
                    empre.Descricao = Convert.ToString(dr["descricao"]);

                    empre.Empresa = new();
                    empre.Local = new();

                    empre.Empresa.Nome = Convert.ToString(dr["empresaNome"]);
                    empre.Empresa.Id = Convert.ToInt32(dr["empresaId"]);
                    empre.HoraDeInicio = Convert.ToDateTime(dr["horaInicio"]);
                    empre.HoraDeFim = Convert.ToDateTime(dr["horaTermino"]);
                    empre.Salario = Convert.ToDecimal(dr["salario"]);
                    empre.DiasTrabalhados = Convert.ToInt32(dr["diasTrabalhados"]);
                    empre.Local.Estado = Convert.ToString(dr["estado"]);
                    empre.Local.Cidade = Convert.ToString(dr["cidade"]);
                    empre.Local.Rua = Convert.ToString(dr["rua"]);
                    empre.Local.Bairro = Convert.ToString(dr["bairro"]);
                    empre.Local.Numero = Convert.ToInt32(dr["numero"]);

                    empregos.Add(empre);
                }
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return empregos;
        }

        public List<Emprego> consultarEmp()
        {
            List<Emprego> empregos = new();

            MySqlConnection con = new();
            con.ConnectionString = Conexao.conecta();

            con.Open();

            try
            {
                MySqlCommand cm = con.CreateCommand();

                cm.CommandText = @"select * from tb_empregos";

                cm.Connection = con;

                MySqlDataReader dr;
                dr = cm.ExecuteReader();

                while (dr.Read())
                {
                    if (Convert.ToInt32(dr["empresaId"]) == Usuario.LogadoE.Id)
                    {
                        Emprego empre = new();

                        empre.Id = Convert.ToInt32(dr["id"]);
                        empre.Descricao = Convert.ToString(dr["descricao"]);

                        empre.Empresa = new();
                        empre.Local = new();

                        empre.Empresa.Nome = Convert.ToString(dr["empresaNome"]);
                        empre.Empresa.Id = Convert.ToInt32(dr["empresaId"]);
                        empre.HoraDeInicio = Convert.ToDateTime(dr["horaInicio"]);
                        empre.HoraDeFim = Convert.ToDateTime(dr["horaTermino"]);
                        empre.Salario = Convert.ToDecimal(dr["salario"]);
                        empre.DiasTrabalhados = Convert.ToInt32(dr["diasTrabalhados"]);
                        empre.Local.Estado = Convert.ToString(dr["estado"]);
                        empre.Local.Cidade = Convert.ToString(dr["cidade"]);
                        empre.Local.Rua = Convert.ToString(dr["rua"]);
                        empre.Local.Bairro = Convert.ToString(dr["bairro"]);
                        empre.Local.Numero = Convert.ToInt32(dr["numero"]);

                        empregos.Add(empre);
                    }
                }
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return empregos;
        }

        public void deletar(Emprego emprego)
        {
            MySqlConnection con = new();
            con.ConnectionString = Conexao.conecta();

            con.Open();

            try
            {
                MySqlCommand cm = con.CreateCommand();

                cm.CommandText = @"delete from tb_empregos where id = @id";

                cm.Parameters.Add("id", MySqlDbType.Int32).Value = emprego.Id;

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

        public bool editar(Emprego emprego)
        {
            MySqlConnection con = new();
            con.ConnectionString = Conexao.conecta();

            con.Open();

            try
            {
                MySqlCommand cm = con.CreateCommand();

                cm.CommandText = @"update tb_empregos set descricao = @descricao, empresaNome = @nome, estado = @estado, cidade = @cidade, bairro = @bairro, numero = @numero, rua = @rua, horaInicio = @horaI, horaTermino = @horaT, salario = @salario, diasTrabalhados = @diasT where id = @id";

                cm.Parameters.Add("id", MySqlDbType.Int32).Value = emprego.Id;
                cm.Parameters.Add("descricao", MySqlDbType.VarChar).Value = emprego.Descricao;
                cm.Parameters.Add("nome", MySqlDbType.VarChar).Value = emprego.Empresa.Nome;
                cm.Parameters.Add("estado", MySqlDbType.VarChar).Value = emprego.Local.Estado;
                cm.Parameters.Add("cidade", MySqlDbType.VarChar).Value = emprego.Local.Cidade;
                cm.Parameters.Add("rua", MySqlDbType.VarChar).Value = emprego.Local.Rua;
                cm.Parameters.Add("numero", MySqlDbType.Int32).Value = emprego.Local.Numero;
                cm.Parameters.Add("bairro", MySqlDbType.VarChar).Value = emprego.Local.Bairro;
                cm.Parameters.Add("horaI", MySqlDbType.VarChar).Value = Convert.ToString(emprego.HoraDeInicio.TimeOfDay);
                cm.Parameters.Add("horaT", MySqlDbType.VarChar).Value = Convert.ToString(emprego.HoraDeFim.TimeOfDay);
                cm.Parameters.Add("salario", MySqlDbType.Decimal).Value = emprego.Salario;
                cm.Parameters.Add("diasT", MySqlDbType.Int32).Value = emprego.DiasTrabalhados;

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

            return true;
        }
    }
}
