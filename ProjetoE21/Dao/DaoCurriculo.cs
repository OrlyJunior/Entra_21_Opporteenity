using MySql.Data.MySqlClient;
using ProjetoE21.Dados;
using ProjetoE21.Interfaces;
using ProjetoE21.Models;
using System.Security.Cryptography;

namespace ProjetoE21.Dao
{
    public class DaoCurriculo : ICrud<Curriculo>
    {
        public bool adicionar(Curriculo curriculo)
        {
            if (curriculo.ValorIdioma1 > 0 && curriculo.ValorIdioma1 < 17)
            {
                curriculo.NivelIdioma1 = "A1";
            }
            else if (curriculo.ValorIdioma1 >= 17 && curriculo.ValorIdioma1 < 33)
            {
                curriculo.NivelIdioma1 = "A2";
            }
            else if (curriculo.ValorIdioma1 >= 33 && curriculo.ValorIdioma1 < 49)
            {
                curriculo.NivelIdioma1 = "B1";
            }
            else if (curriculo.ValorIdioma1 >= 49 && curriculo.ValorIdioma1 < 65)
            {
                curriculo.NivelIdioma1 = "B2";
            }
            else if (curriculo.ValorIdioma1 >= 65 && curriculo.ValorIdioma1 < 81)
            {
                curriculo.NivelIdioma1 = "C1";
            }
            else if (curriculo.ValorIdioma1 >= 81)
            {
                curriculo.NivelIdioma1 = "C2";
            }
            //
            if (curriculo.ValorIdioma2 > 0 && curriculo.ValorIdioma2 < 17)
            {
                curriculo.NivelIdioma2 = "A1";
            }
            else if (curriculo.ValorIdioma2 >= 17 && curriculo.ValorIdioma2 < 33)
            {
                curriculo.NivelIdioma2 = "A2";
            }
            else if (curriculo.ValorIdioma2 >= 33 && curriculo.ValorIdioma2 < 49)
            {
                curriculo.NivelIdioma2 = "B1";
            }
            else if (curriculo.ValorIdioma2 >= 49 && curriculo.ValorIdioma2 < 65)
            {
                curriculo.NivelIdioma2 = "B2";
            }
            else if (curriculo.ValorIdioma2 >= 65 && curriculo.ValorIdioma2 < 81)
            {
                curriculo.NivelIdioma2 = "C1";
            }
            else if (curriculo.ValorIdioma2 >= 81)
            {
                curriculo.NivelIdioma2 = "C2";
            }
            //
            if (curriculo.ValorIdioma3 > 0 && curriculo.ValorIdioma3 < 17)
            {
                curriculo.NivelIdioma3 = "A1";
            }
            else if (curriculo.ValorIdioma3 >= 17 && curriculo.ValorIdioma3 < 33)
            {
                curriculo.NivelIdioma3 = "A2";
            }
            else if (curriculo.ValorIdioma3 >= 33 && curriculo.ValorIdioma3 < 49)
            {
                curriculo.NivelIdioma3 = "B1";
            }
            else if (curriculo.ValorIdioma3 >= 49 && curriculo.ValorIdioma3 < 65)
            {
                curriculo.NivelIdioma3 = "B2";
            }
            else if (curriculo.ValorIdioma3 >= 65 && curriculo.ValorIdioma3 < 81)
            {
                curriculo.NivelIdioma3 = "C1";
            }
            else if (curriculo.ValorIdioma3 >= 81)
            {
                curriculo.NivelIdioma3 = "C2";
            }

            MySqlConnection con = new();

            con.ConnectionString = Conexao.conecta();

            con.Open();

            try
            {
                MySqlCommand cm = con.CreateCommand();

                cm.CommandText = "insert into tb_curriculos(nome, estado, rua, numero, bairro, cidade, telefone, email, objetivo, escola, escolaCidade, situacao, ensino, dataInicio, cursos, extraC1, extraC2, extraC3, extraC4, idioma1, idioma1Nivel, idioma1Valor, idioma2, idioma2Nivel, idioma2Valor, idioma3, idioma3Nivel, idioma3Valor, jovemId)values(@nome, @estado, @rua, @numero, @bairro, @cidade, @telefone, @email, @objetivo, @escola, @escolaCidade, @situacao, @ensino, @dataInicio, @cursos, @extraC1, @extraC2, @extraC3, @extraC4, @idioma1, @idioma1Nivel, @idioma1Valor, @idioma2, @idioma2Nivel, @idioma2Valor, @idioma3, @idioma3Nivel, @idioma3Valor, @jovemId)";

                cm.Parameters.Add("nome", MySqlDbType.VarChar).Value = curriculo.Nome;
                cm.Parameters.Add("email", MySqlDbType.VarChar).Value = curriculo.Email;
                cm.Parameters.Add("telefone", MySqlDbType.VarChar).Value = curriculo.Telefone;
                cm.Parameters.Add("estado", MySqlDbType.VarChar).Value = curriculo.Local.Estado;
                cm.Parameters.Add("rua", MySqlDbType.VarChar).Value = curriculo.Local.Rua;
                cm.Parameters.Add("numero", MySqlDbType.Int32).Value = curriculo.Local.Numero;
                cm.Parameters.Add("bairro", MySqlDbType.VarChar).Value = curriculo.Local.Bairro;
                cm.Parameters.Add("cidade", MySqlDbType.VarChar).Value = curriculo.Local.Cidade;
                cm.Parameters.Add("objetivo", MySqlDbType.VarChar).Value = curriculo.PerfilProfissional;

                cm.Parameters.Add("escola", MySqlDbType.VarChar).Value = curriculo.Escola;
                cm.Parameters.Add("dataInicio", MySqlDbType.DateTime).Value = curriculo.InicioEscola;
                cm.Parameters.Add("situacao", MySqlDbType.VarChar).Value = curriculo.Status;
                cm.Parameters.Add("escolaCidade", MySqlDbType.VarChar).Value = curriculo.EscolaCidade;
                cm.Parameters.Add("ensino", MySqlDbType.VarChar).Value = curriculo.Ensino;

                cm.Parameters.Add("idioma1", MySqlDbType.VarChar).Value = curriculo.Idioma1;
                cm.Parameters.Add("idioma1Nivel", MySqlDbType.VarChar).Value = curriculo.NivelIdioma1;
                cm.Parameters.Add("idioma1Valor", MySqlDbType.Int32).Value = curriculo.ValorIdioma1;

                cm.Parameters.Add("idioma2", MySqlDbType.VarChar).Value = curriculo.Idioma2;
                cm.Parameters.Add("idioma2Nivel", MySqlDbType.VarChar).Value = curriculo.NivelIdioma2;
                cm.Parameters.Add("idioma2Valor", MySqlDbType.Int32).Value = curriculo.ValorIdioma2;

                cm.Parameters.Add("idioma3", MySqlDbType.VarChar).Value = curriculo.Idioma3;
                cm.Parameters.Add("idioma3Nivel", MySqlDbType.VarChar).Value = curriculo.NivelIdioma3;
                cm.Parameters.Add("idioma3Valor", MySqlDbType.Int32).Value = curriculo.ValorIdioma3;

                cm.Parameters.Add("cursos", MySqlDbType.VarChar).Value = curriculo.Cursos;
                cm.Parameters.Add("extraC1", MySqlDbType.VarChar).Value = curriculo.Outros1;
                cm.Parameters.Add("extraC2", MySqlDbType.VarChar).Value = curriculo.Outros2;
                cm.Parameters.Add("extraC3", MySqlDbType.VarChar).Value = curriculo.Outros3;
                cm.Parameters.Add("extraC4", MySqlDbType.VarChar).Value = curriculo.Outros4;

                cm.Parameters.Add("jovemId", MySqlDbType.Int32).Value = Usuario.LogadoJ.Id;

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

                    curriculo.Email = Convert.ToString(dr["email"]);

                    curriculo.Local = new();

                    curriculo.Local.Estado = Convert.ToString(dr["estado"]);
                    curriculo.Local.Cidade = Convert.ToString(dr["cidade"]);
                    curriculo.Local.Bairro = Convert.ToString(dr["bairro"]);
                    curriculo.Local.Numero = Convert.ToInt32(dr["numero"]);
                    curriculo.Local.Rua = Convert.ToString(dr["rua"]);

                    curriculo.Escola = Convert.ToString(dr["escola"]);
                    curriculo.EscolaCidade = Convert.ToString(dr["escolaCidade"]);
                    curriculo.Status = Convert.ToString(dr["situacao"]);
                    curriculo.Ensino = Convert.ToString(dr["ensino"]);
                    curriculo.InicioEscola = Convert.ToDateTime(dr["dataInicio"]);

                    curriculo.Idioma1 = Convert.ToString(dr["idioma1"]);
                    curriculo.NivelIdioma1 = Convert.ToString(dr["idioma1nivel"]);
                    curriculo.ValorIdioma1 = Convert.ToInt32(dr["idioma1valor"]);

                    curriculo.Idioma2 = Convert.ToString(dr["idioma2"]);
                    curriculo.NivelIdioma2 = Convert.ToString(dr["idioma2nivel"]);

                    if (dr["idioma2valor"] == DBNull.Value)
                    {
                        curriculo.ValorIdioma2 = 0;
                    }
                    else
                    {
                        curriculo.ValorIdioma2 = Convert.ToInt32(dr["idioma2valor"]);
                    }
                    
                    curriculo.Idioma3 = Convert.ToString(dr["idioma3"]);
                    curriculo.NivelIdioma3 = Convert.ToString(dr["idioma3nivel"]);

                    if (dr["idioma3valor"] == DBNull.Value)
                    {
                        curriculo.ValorIdioma3 = 0;
                    }
                    else
                    {
                        curriculo.ValorIdioma3 = Convert.ToInt32(dr["idioma3valor"]);
                    }

                    curriculo.Cursos = Convert.ToString(dr["cursos"]);
                    curriculo.Outros1 = Convert.ToString(dr["extraC1"]);
                    curriculo.Outros2 = Convert.ToString(dr["extraC2"]);
                    curriculo.Outros3 = Convert.ToString(dr["extraC3"]);
                    curriculo.Outros4 = Convert.ToString(dr["extraC4"]);

                    curriculo.Telefone = Convert.ToString(dr["telefone"]);
                    curriculo.PerfilProfissional = Convert.ToString(dr["objetivo"]);
                    curriculo.JovemId = Convert.ToInt32(dr["jovemId"]);

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

        public bool editar(Curriculo curriculo)
        {
            MySqlConnection con = new();

            con.ConnectionString = Conexao.conecta();

            con.Open();

            try
            {
                MySqlCommand cm = con.CreateCommand();

                cm.CommandText = "update tb_curriculos set objetivo = @objetivo, escola = @escola, dataInicio = @dataInicio, situacao = @situacao, escolaCidade = @escolaCidade, ensino = @ensino, idioma1 = @idioma1, idioma1Nivel = @idioma1Nivel, idioma1Valor = @idioma1Valor, idioma2 = @idioma2, idioma2Nivel = @idioma2Nivel, idioma2Valor = @idioma2Valor, idioma3 = @idioma3, idioma3Nivel = @idioma3Nivel, idioma3Valor = @idioma3Valor, cursos = @cursos, extraC1 = @extraC1, extraC2 = @extraC2, extraC3 = @extraC3, extraC4 = @extraC4 where id = @id";

                cm.Parameters.Add("objetivo", MySqlDbType.VarChar).Value = curriculo.PerfilProfissional;

                cm.Parameters.Add("escola", MySqlDbType.VarChar).Value = curriculo.Escola;
                cm.Parameters.Add("dataInicio", MySqlDbType.DateTime).Value = curriculo.InicioEscola;
                cm.Parameters.Add("situacao", MySqlDbType.VarChar).Value = curriculo.Status;
                cm.Parameters.Add("escolaCidade", MySqlDbType.VarChar).Value = curriculo.EscolaCidade;
                cm.Parameters.Add("ensino", MySqlDbType.VarChar).Value = curriculo.Ensino;

                cm.Parameters.Add("idioma1", MySqlDbType.VarChar).Value = curriculo.Idioma1;
                cm.Parameters.Add("idioma1Nivel", MySqlDbType.VarChar).Value = curriculo.NivelIdioma1;
                cm.Parameters.Add("idioma1Valor", MySqlDbType.Int32).Value = curriculo.ValorIdioma1;

                cm.Parameters.Add("idioma2", MySqlDbType.VarChar).Value = curriculo.Idioma2;
                cm.Parameters.Add("idioma2Nivel", MySqlDbType.VarChar).Value = curriculo.NivelIdioma2;
                cm.Parameters.Add("idioma2Valor", MySqlDbType.Int32).Value = curriculo.ValorIdioma2;

                cm.Parameters.Add("idioma3", MySqlDbType.VarChar).Value = curriculo.Idioma3;
                cm.Parameters.Add("idioma3Nivel", MySqlDbType.VarChar).Value = curriculo.NivelIdioma3;
                cm.Parameters.Add("idioma3Valor", MySqlDbType.Int32).Value = curriculo.ValorIdioma3;

                cm.Parameters.Add("cursos", MySqlDbType.VarChar).Value = curriculo.Cursos;
                cm.Parameters.Add("extraC1", MySqlDbType.VarChar).Value = curriculo.Outros1;
                cm.Parameters.Add("extraC2", MySqlDbType.VarChar).Value = curriculo.Outros2;
                cm.Parameters.Add("extraC3", MySqlDbType.VarChar).Value = curriculo.Outros3;
                cm.Parameters.Add("extraC4", MySqlDbType.VarChar).Value = curriculo.Outros4;

                cm.Parameters.Add("id", MySqlDbType.Int32).Value = Usuario.LogadoJ.Curriculo.Id;
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

        public bool candidatar(int idEmprego)
        {
            MySqlConnection con = new();

            con.ConnectionString = Conexao.conecta();

            con.Open();

            try
            {
                MySqlCommand cm = con.CreateCommand();

                cm.CommandText = "insert into tb_curriculosEnviados(idCurriculo, idEmprego)values(@idCurriculo, @idEmprego)";

                cm.Parameters.Add("idCurriculo", MySqlDbType.Int32).Value = Usuario.LogadoJ.Curriculo.Id;

                cm.Parameters.Add("idEmprego", MySqlDbType.Int32).Value = idEmprego;

                cm.Connection = con;

                cm.ExecuteNonQuery();

                return true;
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        public List<Curriculo> consultarCandidatos(int id)
        {
            List<Curriculo> curriculos = new();

            List<int> curriculosId = new();

            MySqlConnection con = new();
            con.ConnectionString = Conexao.conecta();

            con.Open();

            try
            {
                MySqlCommand cm = con.CreateCommand();

                cm.CommandText = @"select idCurriculo from tb_curriculosEnviados where idEmprego = @idEmprego";

                cm.Parameters.Add("idEmprego", MySqlDbType.Int32).Value = id;

                cm.Connection = con;

                MySqlDataReader dr;
                dr = cm.ExecuteReader();

                while (dr.Read())
                {
                    curriculosId.Add(Convert.ToInt32(dr["idCurriculo"]));
                }

                dr.Close();

                con.Close();

                con.Open();

                foreach (int i in curriculosId)
                {
                    Console.WriteLine(i);

                    MySqlCommand cn = con.CreateCommand();

                    cn.CommandText = "select * from tb_curriculos where id = @id";

                    cn.Parameters.Add("id", MySqlDbType.Int32).Value = i;

                    cn.Connection = con;

                    MySqlDataReader reader;
                    reader = cn.ExecuteReader();

                    while (reader.Read())
                    {
                        Curriculo curriculo = new();

                        curriculo.Id = Convert.ToInt32(reader["id"]);
                        curriculo.Nome = Convert.ToString(reader["nome"]);

                        curriculo.Email = Convert.ToString(reader["email"]);

                        curriculo.Local = new();

                        curriculo.Local.Estado = Convert.ToString(reader["estado"]);
                        curriculo.Local.Cidade = Convert.ToString(reader["cidade"]);
                        curriculo.Local.Bairro = Convert.ToString(reader["bairro"]);
                        curriculo.Local.Numero = Convert.ToInt32(reader["numero"]);
                        curriculo.Local.Rua = Convert.ToString(reader["rua"]);

                        curriculo.Escola = Convert.ToString(reader["escola"]);
                        curriculo.EscolaCidade = Convert.ToString(reader["escolaCidade"]);
                        curriculo.Status = Convert.ToString(reader["situacao"]);
                        curriculo.Ensino = Convert.ToString(reader["ensino"]);
                        curriculo.InicioEscola = Convert.ToDateTime(reader["dataInicio"]);

                        curriculo.Idioma1 = Convert.ToString(reader["idioma1"]);
                        curriculo.NivelIdioma1 = Convert.ToString(reader["idioma1nivel"]);
                        curriculo.ValorIdioma1 = Convert.ToInt32(reader["idioma1valor"]);

                        curriculo.Idioma2 = Convert.ToString(reader["idioma2"]);
                        curriculo.NivelIdioma2 = Convert.ToString(reader["idioma2nivel"]);

                        if (reader["idioma2valor"] == DBNull.Value)
                        {
                            curriculo.ValorIdioma2 = 0;
                        }
                        else
                        {
                            curriculo.ValorIdioma2 = Convert.ToInt32(reader["idioma2valor"]);
                        }

                        curriculo.Idioma3 = Convert.ToString(reader["idioma3"]);
                        curriculo.NivelIdioma3 = Convert.ToString(reader["idioma3nivel"]);

                        if (reader["idioma3valor"] == DBNull.Value)
                        {
                            curriculo.ValorIdioma3 = 0;
                        }
                        else
                        {
                            curriculo.ValorIdioma3 = Convert.ToInt32(reader["idioma3valor"]);
                        }

                        curriculo.Cursos = Convert.ToString(reader["cursos"]);
                        curriculo.Outros1 = Convert.ToString(reader["extraC1"]);
                        curriculo.Outros2 = Convert.ToString(reader["extraC2"]);
                        curriculo.Outros3 = Convert.ToString(reader["extraC3"]);
                        curriculo.Outros4 = Convert.ToString(reader["extraC4"]);

                        curriculo.Telefone = Convert.ToString(reader["telefone"]);
                        curriculo.PerfilProfissional = Convert.ToString(reader["objetivo"]);
                        curriculo.JovemId = Convert.ToInt32(reader["jovemId"]);

                        curriculos.Add(curriculo);
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

            return curriculos;
        }
    }
}