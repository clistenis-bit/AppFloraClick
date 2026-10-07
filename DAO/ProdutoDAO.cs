using AppFloraClick.Configs;
using AppFloraClick.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace AppFloraClick.DAO
{
    public class ProdutoDAO
    {
        public void Inserir(Produto produto)
        {
            using (MySqlConnection conexao = Conexao.Conectar())
            {
                conexao.Open();

                string sql = @"
                    INSERT INTO Cadastro_produto
                    (
                        nome_pro,
                        categoria_pro,
                        descricao_pro,
                        preco_pro,
                        quantidade_pro
                    )
                    VALUES
                    (
                        @nome,
                        @categoria,
                        @descricao,
                        @preco,
                        @quantidade
                    )
                ";

                using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@nome", produto.nome_pro);
                    comando.Parameters.AddWithValue("@categoria", produto.categoria_pro);
                    comando.Parameters.AddWithValue("@descricao", produto.descricao_pro);
                    comando.Parameters.AddWithValue("@preco", produto.preco_pro);
                    comando.Parameters.AddWithValue("@quantidade", produto.quantidade_pro);

                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<Produto> Listar()
        {
            List<Produto> produtos = new List<Produto>();

            using (MySqlConnection conexao = Conexao.Conectar())
            {
                conexao.Open();

                string sql = @"
                    SELECT
                        id_pro,
                        nome_pro,
                        categoria_pro,
                        descricao_pro,
                        preco_pro,
                        quantidade_pro
                    FROM Cadastro_produto
                    ORDER BY id_pro DESC
                ";

                using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                using (MySqlDataReader leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        produtos.Add(new Produto
                        {
                            id_pro = Convert.ToInt32(leitor["id_pro"]),
                            nome_pro = leitor["nome_pro"]?.ToString() ?? "",
                            categoria_pro = leitor["categoria_pro"]?.ToString() ?? "",
                            descricao_pro = leitor["descricao_pro"]?.ToString() ?? "",
                            preco_pro = Convert.ToDecimal(leitor["preco_pro"]),
                            quantidade_pro = Convert.ToInt32(leitor["quantidade_pro"])
                        });
                    }
                }
            }

            return produtos;
        }

        public void Excluir(int id)
        {
            using (MySqlConnection conexao = Conexao.Conectar())
            {
                conexao.Open();

                string sql =
                    "DELETE FROM Cadastro_produto WHERE id_pro = @id";

                using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}