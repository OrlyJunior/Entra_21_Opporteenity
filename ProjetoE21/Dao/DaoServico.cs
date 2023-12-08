﻿using ProjetoE21.Models;
using MySql.Data.MySqlClient;
using ProjetoE21.Dados;

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

                cm.CommandText = @"insert into tb_servicos(descricao, contratanteNome, data, valor, dia, hora)values(@descricao, @contratante, @data, @valor, @dia, @hora)";

                cm.Parameters.Add("descricao", MySqlDbType.VarChar).Value = servico.Descricao;
                cm.Parameters.Add("contratante", MySqlDbType.VarChar).Value = servico.EmpresaS.Nome;
                cm.Parameters.Add("data", MySqlDbType.DateTime).Value = servico.Horario;
                cm.Parameters.Add("valor", MySqlDbType.Decimal).Value = servico.Pagamento;
                cm.Parameters.Add("dia", MySqlDbType.VarChar).Value = servico.Dia;
                cm.Parameters.Add("hora", MySqlDbType.VarChar).Value = servico.Hora;

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

                    service.EmpresaS.Nome = Convert.ToString(dr["contratanteNome"]);
                    service.Horario = Convert.ToDateTime(dr["data"]);
                    service.Pagamento = Convert.ToDecimal(dr["valor"]);
                    service.Dia = Convert.ToString(dr["dia"]);
                    service.Hora = Convert.ToString(dr["hora"]);

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

        public void deletar(Servico t)
        {
            throw new NotImplementedException();
        }

        public bool editar(Servico t)
        {
            throw new NotImplementedException();
        }
    }
}
