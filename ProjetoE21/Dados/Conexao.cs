namespace ProjetoE21.Dados
{
    public class Conexao
    {
        public static string conecta()
        {
            string conecta = @"Server=monorail.proxy.rlwy.net; Port=34074; Uid=root; Pwd=ca5C33h5c2gAE2eC4-dgcdeCdBfBe5c6; Database=railway";
            
            string conecta2 = Environment.GetEnvironmentVariable("DATABASE_URL") ?? conecta;

            return conecta2;
        }
    }
}