namespace AppFloraClick.Models
{
<<<<<<< HEAD
    public class Agendamento
    {
    }
=======
    using System;

        namespace AppFloraClick.Models
        {
            public class Agendamento
            {
                public int id_age { get; set; }
                public string nome_cli_age { get; set; } = "";
                public string telefone_age { get; set; } = "";
                public string tipo_data_age { get; set; } = "";
                public DateTime data_age { get; set; } = DateTime.Today;
                public string observacao_age { get; set; } = "";
            }
        }
    
>>>>>>> af8df8294761df01dfb084930662131ae61a3df8
}

