using MySql.Data.MySqlClient;

namespace AppFloraClick.Configs
{
    public class Conexao
    {
        
            public static MySqlConnection Conectar()
            {
                string conexao = "server=localhost;database=floraclick_bd;user=root;password=;";
                return new MySqlConnection(conexao);
            }
        
    }

}


