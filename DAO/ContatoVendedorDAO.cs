using AppFloraClick.Configs;
using AppFloraClick.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace AppFloraClick.DAO
{
    public class ContatoVendedorDAO
    {
        public void Inserir(ContatoVendedor contato)
        {
            using (MySqlConnection conexao = Conexao.Conectar())
            {
                conexao.Open();

                string sql = @"
                    INSERT INTO Contato_vendedor
                    (
                        assunto_con,
                        Mensagem_con
                    )
                    VALUES
                    (
                        @assunto,
                        @mensagem
                    )
                ";

                using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@assunto", contato.assunto_con);
                    comando.Parameters.AddWithValue("@mensagem", contato.Mensagem_con);

                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<ContatoVendedor> Listar()
        {
            List<ContatoVendedor> lista = new List<ContatoVendedor>();

            using (MySqlConnection conexao = Conexao.Conectar())
            {
                conexao.Open();

                string sql = @"
                    SELECT
                        id_con,
                        assunto_con,
                        Mensagem_con
                    FROM Contato_vendedor
                    ORDER BY id_con DESC
                ";

                using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                using (MySqlDataReader leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        lista.Add(new ContatoVendedor
                        {
                            id_con = Convert.ToInt32(leitor["id_con"]),
                            assunto_con = leitor["assunto_con"]?.ToString() ?? "",
                            Mensagem_con = leitor["Mensagem_con"]?.ToString() ?? ""
                        });
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
                    "DELETE FROM Contato_vendedor WHERE id_con = @id";

                using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}