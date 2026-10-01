using MySql.Data.MySqlClient;

namespace AppFloraClick.Configs
{
    public class Conexao
    {
        public static MySqlConnection Conectar()
        {
            string conexao = "Server=localhost;Port=3306;Database=floraclick_bd;User=root;Password=;";

            return new MySqlConnection(conexao);
        }
    }
}