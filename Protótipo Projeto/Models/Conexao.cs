namespace Protótipo_Projeto.Models
{
    public class Conexao
    {
        public static string Conecta()
        {
            //A string de conexão pode precisar de mudanças dependendo do nome do server,
            //usuário e senha do banco de dados local.

            string conexao = @"server=localhost;uid=root;pwd=123456;database=projeto";

            return conexao;
        }
    }
}
