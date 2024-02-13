using ProjetoE21.Dados;

namespace ProjetoE21.Ordenacao
{
    public class OrdenaJovens
    {
        public bool Pesquisa(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                Listas.cadastrosJ = Listas.cadastrosJ.Where(s => s.Nome.Contains(searchString)).ToList();
            }

            return true;
        }
    }
}
