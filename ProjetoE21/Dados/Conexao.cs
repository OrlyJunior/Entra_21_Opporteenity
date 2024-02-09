namespace ProjetoE21.Dados
{
    public class Conexao
    {
        public static string conecta()
        {
            string conecta = @"Server=localhost;Database=e21;Uid=root;Pwd=admin";

            return conecta;
        }
    }
}