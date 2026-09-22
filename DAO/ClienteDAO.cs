using AppFloraClick.Configs;
using AppFloraClick.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace AppFloraClick.DAO
{
    public class ClienteDAO
    {
        public void Inserir(Cliente cliente)
        {
            using (MySqlConnection conexao = Conexao.Conectar())
            {
                conexao.Open();

                string sql = "INSERT INTO Cliente (nome_cli, telefone_cli, email_cli, endereco_cli) VALUES (@nome, @telefone, @email, @endereco)";

                MySqlCommand comando = new MySqlCommand(sql, conexao);

                comando.Parameters.AddWithValue("@nome", cliente.nome_cli);
                comando.Parameters.AddWithValue("@telefone", cliente.telefone_cli);
                comando.Parameters.AddWithValue("@email", cliente.email_cli);
                comando.Parameters.AddWithValue("@endereco", cliente.endereco_cli);

                comando.ExecuteNonQuery();
            }
        }

        public List<Cliente> Listar()
        {
            List<Cliente> clientes = new List<Cliente>();

            using (MySqlConnection conexao = Conexao.Conectar())
            {
                conexao.Open();

                string sql = "SELECT * FROM Cliente";

                MySqlCommand comando = new MySqlCommand(sql, conexao);

                MySqlDataReader leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    Cliente cliente = new Cliente();

                    cliente.id_cli = Convert.ToInt32(leitor["id_cli"]);
                    cliente.nome_cli = leitor["nome_cli"].ToString() ?? "";
                    cliente.telefone_cli = leitor["telefone_cli"].ToString() ?? "";
                    cliente.email_cli = leitor["email_cli"].ToString() ?? "";
                    cliente.endereco_cli = leitor["endereco_cli"].ToString() ?? "";

                    clientes.Add(cliente);
                }
            }

            return clientes;
        }

        public void Excluir(int id)
        {
            using (MySqlConnection conexao = Conexao.Conectar())
            {
                conexao.Open();

                string sql = "DELETE FROM Cliente WHERE id_cli = @id";

                MySqlCommand comando = new MySqlCommand(sql, conexao);

                comando.Parameters.AddWithValue("@id", id);

                comando.ExecuteNonQuery();
            }
        }
    }
}