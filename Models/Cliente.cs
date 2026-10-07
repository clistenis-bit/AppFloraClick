using System;

namespace AppFloraClick.Models
{
    public class Cliente
    {
        public int id_cli { get; set; }

        public string nome_cli { get; set; } = "";

        public string email_cli { get; set; } = "";

        public string telefone_cli { get; set; } = "";

        public string cpf_cli { get; set; } = "";

        public DateTime data_nas_cli { get; set; }
    }
}