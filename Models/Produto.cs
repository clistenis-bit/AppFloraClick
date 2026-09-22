namespace AppFloraClick.Models
{
    public class CadastroProduto
    {  
        public class Produto
        {
            public int id_pro { get; set; }
            public string nome_pro { get; set; }
            public decimal preco_pro { get; set; }
            public string categoria_pro { get; set; }
            public string descricao_pro { get; set; }
            public int quantidade_pro { get; set; }
        }
    }
}

