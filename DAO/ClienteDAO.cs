using AppFloraClick.Configs;
using AppFloraClick.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace AppFloraClick.DAO
{
    public class ClienteDAO
    {
        public int Inserir(Cliente cliente)
        {
            using (MySqlConnection conexao = Conexao.Conectar())
            {
                conexao.Open();

                string sql = @"
                    INSERT INTO Cadastro_cliente
                    (
                        nome_cli,
                        email_cli,
                        telefone_cli,
                        cpf_cli,
                        data_nas_cli
                    )
                    VALUES
                    (
                        @nome,
                        @email,
                        @telefone,
                        @cpf,
                        @data
                    );

                    SELECT LAST_INSERT_ID();
                ";

                using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@nome", cliente.nome_cli);
                    comando.Parameters.AddWithValue("@email", cliente.email_cli);
                    comando.Parameters.AddWithValue("@telefone", cliente.telefone_cli);
                    comando.Parameters.AddWithValue("@cpf", cliente.cpf_cli);
                    comando.Parameters.AddWithValue("@data", cliente.data_nas_cli);

                    return Convert.ToInt32(comando.ExecuteScalar());
                }
            }
        }

        public List<Cliente> Listar()
        {
            List<Cliente> clientes = new List<Cliente>();

            using (MySqlConnection conexao = Conexao.Conectar())
            {
                conexao.Open();

                string sql = @"
                    SELECT
                        id_cli,
                        nome_cli,
                        email_cli,
                        telefone_cli,
                        cpf_cli,
                        data_nas_cli
                    FROM Cadastro_cliente
                    ORDER BY id_cli DESC
                ";

                using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                using (MySqlDataReader leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        Cliente cliente = new Cliente
                        {
                            id_cli = Convert.ToInt32(leitor["id_cli"]),
                            nome_cli = leitor["nome_cli"]?.ToString() ?? "",
                            email_cli = leitor["email_cli"]?.ToString() ?? "",
                            telefone_cli = leitor["telefone_cli"]?.ToString() ?? "",
                            cpf_cli = leitor["cpf_cli"]?.ToString() ?? ""
                        };

                        if (leitor["data_nas_cli"] != DBNull.Value)
                        {
                            cliente.data_nas_cli =
                                Convert.ToDateTime(leitor["data_nas_cli"]);
                        }

                        clientes.Add(cliente);
                    }
                }
            }

            return clientes;
        }

        public Cliente? BuscarPorEmailCpf(string email, string cpf)
        {
            using (MySqlConnection conexao = Conexao.Conectar())
            {
                conexao.Open();

                string sql = @"
                    SELECT
                        id_cli,
                        nome_cli,
                        email_cli,
                        telefone_cli,
                        cpf_cli,
                        data_nas_cli
                    FROM Cadastro_cliente
                    WHERE email_cli = @email
                    AND cpf_cli = @cpf
                    LIMIT 1
                ";

                using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@email", email);
                    comando.Parameters.AddWithValue("@cpf", cpf);

                    using (MySqlDataReader leitor = comando.ExecuteReader())
                    {
                        if (leitor.Read())
                        {
                            Cliente cliente = new Cliente
                            {
                                id_cli = Convert.ToInt32(leitor["id_cli"]),
                                nome_cli = leitor["nome_cli"]?.ToString() ?? "",
                                email_cli = leitor["email_cli"]?.ToString() ?? "",
                                telefone_cli = leitor["telefone_cli"]?.ToString() ?? "",
                                cpf_cli = leitor["cpf_cli"]?.ToString() ?? ""
                            };

                            if (leitor["data_nas_cli"] != DBNull.Value)
                            {
                                cliente.data_nas_cli =
                                    Convert.ToDateTime(leitor["data_nas_cli"]);
                            }

                            return cliente;
                        }
                    }
                }
            }

            return null;
        }

        public void Excluir(int id)
        {
            using (MySqlConnection conexao = Conexao.Conectar())
            {
                conexao.Open();

                string sql =
                    "DELETE FROM Cadastro_cliente WHERE id_cli = @id";

                using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}