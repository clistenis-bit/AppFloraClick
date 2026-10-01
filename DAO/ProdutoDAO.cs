using AppFloraClick.Configs;
using MySql.Data.MySqlClient;
using static AppFloraClick.Models.CadastroProduto;

namespace AppFloraClick.DAO
{
    public class ProdutoDAO
    {
        public class ProdutoDAO
        {
            // Cadastra um produto no banco de dados
            public void Inserir(Produto produto)
            {
                using (MySqlConnection conexao = Conexao.Conectar())
                {
                    conexao.Open();

                    string sql = "INSERT INTO Produto (nome_pro, preco_pro, categoria_pro, descricao_pro, quantidade_pro) VALUES (@nome, @preco, @categoria, @descricao, @quantidade)";

                    MySqlCommand comando = new MySqlCommand(sql, conexao);

                    comando.Parameters.AddWithValue("@nome", produto.nome_pro);
                    comando.Parameters.AddWithValue("@preco", produto.preco_pro);
                    comando.Parameters.AddWithValue("@categoria", produto.categoria_pro);
                    comando.Parameters.AddWithValue("@descricao", produto.descricao_pro);
                    comando.Parameters.AddWithValue("@quantidade", produto.quantidade_pro);

                    comando.ExecuteNonQuery();
                }
            }

            // Lista os produtos cadastrados
            public List<Produto> Listar()
            {
                List<Produto> produtos = new List<Produto>();

                using (MySqlConnection conexao = Conexao.Conectar())
                {
                    conexao.Open();

                    string sql = "SELECT * FROM Produto";

                    MySqlCommand comando = new MySqlCommand(sql, conexao);

                    MySqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Produto produto = new Produto();

                        produto.id_pro = Convert.ToInt32(leitor["id_pro"]);
                        produto.nome_pro = leitor["nome_pro"].ToString() ?? "";
                        produto.preco_pro = Convert.ToDecimal(leitor["preco_pro"]);
                        produto.categoria_pro = leitor["categoria_pro"].ToString() ?? "";
                        produto.descricao_pro = leitor["descricao_pro"].ToString() ?? "";
                        produto.quantidade_pro = Convert.ToInt32(leitor["quantidade_pro"]);

                        produtos.Add(produto);
                    }
                }

                return produtos;
            }

            // Exclui um produto pelo ID
            public void Excluir(int id)
            {
                using (MySqlConnection conexao = Conexao.Conectar())
                {
                    conexao.Open();

                    string sql = "DELETE FROM Produto WHERE id_pro = @id";

                    MySqlCommand comando = new MySqlCommand(sql, conexao);

                    comando.Parameters.AddWithValue("@id", id);

                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}

