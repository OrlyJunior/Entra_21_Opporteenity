namespace ProjetoE21.Dados
{
    public class ConexaoJovem
    {
        public static string conectaJovem(string banco)
        {
            string conecta = @$"Server=localhost;Database={banco};Uid=root;Pwd=1234561";

            return conecta;
        }
    }
}
