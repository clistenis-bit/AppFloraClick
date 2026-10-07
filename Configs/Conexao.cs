using MySql.Data.MySqlClient;

namespace AppFloraClick.Configs
{
    public class Conexao
    {
        public static MySqlConnection Conectar()
        {
            string conexao =
                "Server=localhost;" +
                "Port=3306;" +
                "Database=floraclick_bd;" +
                "Uid=root;" +
                "Pwd=;" +
                "SslMode=None;";

            return new MySqlConnection(conexao);
        }
    }
}