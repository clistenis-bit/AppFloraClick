using AppFloraClick.Configs;
using AppFloraClick.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace AppFloraClick.DAO
{
    public class AgendamentoDataDAO
    {
        public void Inserir(AgendamentoData agendamento)
        {
            using (MySqlConnection conexao = Conexao.Conectar())
            {
                conexao.Open();

                string sql = @"
                    INSERT INTO Agendamento_data
                    (
                        nome_cli_age,
                        telefone_age,
                        tipo_data_age,
                        data_age,
                        observacao_age
                    )
                    VALUES
                    (
                        @nome,
                        @telefone,
                        @tipo,
                        @data,
                        @observacao
                    )";

                using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue(
                        "@nome",
                        agendamento.nome_cli_age
                    );

                    comando.Parameters.AddWithValue(
                        "@telefone",
                        agendamento.telefone_age
                    );

                    comando.Parameters.AddWithValue(
                        "@tipo",
                        agendamento.tipo_data_age
                    );

                    comando.Parameters.AddWithValue(
                        "@data",
                        agendamento.data_age
                    );

                    comando.Parameters.AddWithValue(
                        "@observacao",
                        agendamento.observacao_age
                    );

                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<AgendamentoData> Listar()
        {
            List<AgendamentoData> lista = new();

            using (MySqlConnection conexao = Conexao.Conectar())
            {
                conexao.Open();

                string sql = @"
                    SELECT
                        id_age,
                        nome_cli_age,
                        telefone_age,
                        tipo_data_age,
                        data_age,
                        observacao_age
                    FROM Agendamento_data
                    ORDER BY id_age DESC";

                using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                using (MySqlDataReader leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        AgendamentoData agendamento = new()
                        {
                            id_age = Convert.ToInt32(leitor["id_age"]),
                            nome_cli_age = leitor["nome_cli_age"]?.ToString() ?? "",
                            telefone_age = leitor["telefone_age"]?.ToString() ?? "",
                            tipo_data_age = leitor["tipo_data_age"]?.ToString() ?? "",
                            observacao_age = leitor["observacao_age"]?.ToString() ?? ""
                        };

                        if (leitor["data_age"] != DBNull.Value)
                        {
                            agendamento.data_age =
                                Convert.ToDateTime(leitor["data_age"]);
                        }

                        lista.Add(agendamento);
                    }
                }
            }

            return lista;
        }

        public void Excluir(int id)
        {
            using (MySqlConnection conexao = Conexao.Conectar())
            {
                conexao.Open();

                string sql =
                    "DELETE FROM Agendamento_data WHERE id_age = @id";

                using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@id", id);

                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}