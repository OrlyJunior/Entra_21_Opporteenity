using ProjetoE21.Models;

namespace ProjetoE21.Interfaces
{
    public interface IOrdenar
    {
        public bool Ordena(string sorter);
        public bool Pesquisa(string searchString);
        public int? VerificaPg(string currentFilter, int? page);
    }
}
