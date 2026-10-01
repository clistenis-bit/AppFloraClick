using AppFloraClick.Configs;
using AppFloraClick.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace AppFloraClick.DAO
{
    public class AgendamentoDataDAO
    {
        public void Inserir(Agendamento agendamento)
        {
            using (MySqlConnection conexao = Conexao.Conectar())
            {
                conexao.Open();

                string sql = "INSERT INTO Agendamento_data (nome_cli_age, telefone_age, tipo_data_age, data_age, observacao_age) VALUES (@nome, @telefone, @tipo, @data, @observacao)";

                MySqlCommand comando = new MySqlCommand(sql, conexao);

                comando.Parameters.AddWithValue("@nome", agendamento.nome_cli_age);
                comando.Parameters.AddWithValue("@telefone", agendamento.telefone_age);
                comando.Parameters.AddWithValue("@tipo", agendamento.tipo_data_age);
                comando.Parameters.AddWithValue("@data", agendamento.data_age);
                comando.Parameters.AddWithValue("@observacao", agendamento.observacao_age);

                comando.ExecuteNonQuery();
            }
        }

        public List<Agendamento> Listar()
        {
            List<Agendamento> agendamentos = new List<Agendamento>();

            using (MySqlConnection conexao = Conexao.Conectar())
            {
                conexao.Open();

                string sql = "SELECT * FROM Agendamento_data";

                MySqlCommand comando = new MySqlCommand(sql, conexao);

                MySqlDataReader leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    Agendamento agendamento = new Agendamento();

                    agendamento.id_age = Convert.ToInt32(leitor["id_age"]);
                    agendamento.nome_cli_age = leitor["nome_cli_age"].ToString() ?? "";
                    agendamento.telefone_age = leitor["telefone_age"].ToString() ?? "";
                    agendamento.tipo_data_age = leitor["tipo_data_age"].ToString() ?? "";
                    agendamento.data_age = Convert.ToDateTime(leitor["data_age"]);
                    agendamento.observacao_age = leitor["observacao_age"].ToString() ?? "";

                    agendamentos.Add(agendamento);
                }
            }

            return agendamentos;
        }

        public void Excluir(int id)
        {
            using (MySqlConnection conexao = Conexao.Conectar())
            {
                conexao.Open();

                string sql = "DELETE FROM Agendamento_data WHERE id_age = @id";

                MySqlCommand comando = new MySqlCommand(sql, conexao);

                comando.Parameters.AddWithValue("@id", id);

                comando.ExecuteNonQuery();
            }
        }
    }
}