using MySql.Data.MySqlClient;
using ProjetoE21.Dados;
using ProjetoE21.Interfaces;
using ProjetoE21.Models;

namespace ProjetoE21.Dao
{
    public class DaoServico : ICrud<Servico>
    {
        public bool adicionar(Servico servico)
        {
            MySqlConnection con = new();
            con.ConnectionString = Conexao.conecta();

            con.Open();

            try
            {
                MySqlCommand cm = con.CreateCommand();

                cm.CommandText = @"insert into tb_servicos(descricao, contratanteNome, estado, cidade, bairro, rua, numero, data, valor, dia, hora, empresaId)values(@descricao, @contratante, @estado, @cidade, @bairro, @rua, @numero, @data, @valor, @dia, @hora, @empresaId)";

                cm.Parameters.Add("descricao", MySqlDbType.VarChar).Value = servico.Descricao;
                cm.Parameters.Add("contratante", MySqlDbType.VarChar).Value = servico.EmpresaS.Nome;
                cm.Parameters.Add("estado", MySqlDbType.VarChar).Value = servico.Local.Estado;
                cm.Parameters.Add("cidade", MySqlDbType.VarChar).Value = servico.Local.Cidade;
                cm.Parameters.Add("bairro", MySqlDbType.VarChar).Value = servico.Local.Bairro;
                cm.Parameters.Add("rua", MySqlDbType.VarChar).Value = servico.Local.Rua;
                cm.Parameters.Add("numero", MySqlDbType.VarChar).Value = servico.Local.Numero;
                cm.Parameters.Add("data", MySqlDbType.DateTime).Value = servico.Horario;
                cm.Parameters.Add("valor", MySqlDbType.Decimal).Value = servico.Pagamento;
                cm.Parameters.Add("dia", MySqlDbType.VarChar).Value = servico.Dia;
                cm.Parameters.Add("hora", MySqlDbType.VarChar).Value = servico.Hora;
                cm.Parameters.Add("empresaId", MySqlDbType.VarChar).Value = servico.EmpresaId;

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

        public List<Servico> consultar()
        {
            List<Servico> servicos = new();

            MySqlConnection con = new();
            con.ConnectionString = Conexao.conecta();

            con.Open();

            try
            {
                MySqlCommand cm = con.CreateCommand();

                cm.CommandText = @"select * from tb_servicos";

                cm.Connection = con;

                MySqlDataReader dr;
                dr = cm.ExecuteReader();

                while (dr.Read())
                {
                    Servico service = new Servico();

                    service.Id = Convert.ToInt32(dr["id"]);
                    service.Descricao = Convert.ToString(dr["descricao"]);

                    service.EmpresaS = new();
                    service.Local = new();

                    service.EmpresaS.Nome = Convert.ToString(dr["contratanteNome"]);
                    service.Horario = Convert.ToDateTime(dr["data"]);
                    service.Pagamento = Convert.ToDecimal(dr["valor"]);
                    service.Dia = Convert.ToString(dr["dia"]);
                    service.Hora = Convert.ToString(dr["hora"]);
                    service.Local.Estado = Convert.ToString(dr["estado"]);
                    service.Local.Cidade = Convert.ToString(dr["cidade"]);
                    service.Local.Bairro = Convert.ToString(dr["bairro"]);
                    service.Local.Rua = Convert.ToString(dr["rua"]);
                    service.Local.Numero = Convert.ToInt32(dr["numero"]);

                    service.EmpresaId = Convert.ToInt32(dr["empresaId"]);

                    servicos.Add(service);
                }
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return servicos;
        }

        public void deletar(Servico servico)
        {
            MySqlConnection con = new();
            con.ConnectionString = Conexao.conecta();

            con.Open();

            try
            {
                MySqlCommand cm = con.CreateCommand();

                cm.CommandText = @"delete from tb_servicos where id = @id";

                cm.Parameters.Add("id", MySqlDbType.Int32).Value = servico.Id;

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

        public bool editar(Servico servico)
        {
            MySqlConnection con = new();
            con.ConnectionString = Conexao.conecta();

            con.Open();

            try
            {
                MySqlCommand cm = con.CreateCommand();

                cm.CommandText = @"update tb_servicos set descricao = @descricao, contratanteNome = @nome, estado = @estado, cidade = @cidade, bairro = @bairro, rua = @rua, numero = @numero, data = @data, dia = @dia, hora = @hora, valor = @valor where id = @id";

                cm.Parameters.Add("id", MySqlDbType.Int32).Value = servico.Id;
                cm.Parameters.Add("descricao", MySqlDbType.VarChar).Value = servico.Descricao;
                cm.Parameters.Add("nome", MySqlDbType.VarChar).Value = servico.EmpresaS.Nome;
                cm.Parameters.Add("data", MySqlDbType.DateTime).Value = servico.Horario;
                cm.Parameters.Add("dia", MySqlDbType.VarChar).Value = servico.Dia;
                cm.Parameters.Add("hora", MySqlDbType.VarChar).Value = servico.Hora;
                cm.Parameters.Add("valor", MySqlDbType.Decimal).Value = servico.Pagamento;
                cm.Parameters.Add("estado", MySqlDbType.VarChar).Value = servico.Local.Estado;
                cm.Parameters.Add("cidade", MySqlDbType.VarChar).Value = servico.Local.Cidade;
                cm.Parameters.Add("bairro", MySqlDbType.VarChar).Value = servico.Local.Bairro;
                cm.Parameters.Add("rua", MySqlDbType.VarChar).Value = servico.Local.Rua;
                cm.Parameters.Add("numero", MySqlDbType.VarChar).Value = servico.Local.Numero;

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
