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

                string sql = "INSERT INTO Contato_vendedor (nome_vend_con, telefone_vend_con, email_vend_con, mensagem_con) VALUES (@nome, @telefone, @email, @mensagem)";

                MySqlCommand comando = new MySqlCommand(sql, conexao);

                comando.Parameters.AddWithValue("@nome", contato.nome_vend_con);
                comando.Parameters.AddWithValue("@telefone", contato.telefone_vend_con);
                comando.Parameters.AddWithValue("@email", contato.email_vend_con);
                comando.Parameters.AddWithValue("@mensagem", contato.mensagem_con);

                comando.ExecuteNonQuery();
            }
        }

        public List<ContatoVendedor> Listar()
        {
            List<ContatoVendedor> contatos = new List<ContatoVendedor>();

            using (MySqlConnection conexao = Conexao.Conectar())
            {
                conexao.Open();

                string sql = "SELECT * FROM Contato_vendedor";

                MySqlCommand comando = new MySqlCommand(sql, conexao);

                MySqlDataReader leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    ContatoVendedor contato = new ContatoVendedor();

                    contato.id_con = Convert.ToInt32(leitor["id_con"]);
                    contato.nome_vend_con = leitor["nome_vend_con"].ToString() ?? "";
                    contato.telefone_vend_con = leitor["telefone_vend_con"].ToString() ?? "";
                    contato.email_vend_con = leitor["email_vend_con"].ToString() ?? "";
                    contato.mensagem_con = leitor["mensagem_con"].ToString() ?? "";

                    contatos.Add(contato);
                }
            }

            return contatos;
        }

        public void Excluir(int id)
        {
            using (MySqlConnection conexao = Conexao.Conectar())
            {
                conexao.Open();

                string sql = "DELETE FROM Contato_vendedor WHERE id_con = @id";

                MySqlCommand comando = new MySqlCommand(sql, conexao);

                comando.Parameters.AddWithValue("@id", id);

                comando.ExecuteNonQuery();
            }
        }
    }
}