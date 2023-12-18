using ProjetoE21.Dados;
using ProjetoE21.Interfaces;
using ProjetoE21.Models;

namespace ProjetoE21.Ordenacao
{
    public class OrdenarEmpregos : IOrdenar
    {
        public bool Ordena(string sorter)
        {
            switch (sorter)
            {
                case "nome_desc":
                    Listas.empregos = Listas.empregos.OrderByDescending(n => n.Descricao).ToList();
                    break;
                case "nome":
                    Listas.empregos = Listas.empregos.OrderBy(n => n.Descricao).ToList();
                    break;
                default:
                    Listas.empregos = Listas.empregos.OrderBy(n => n.Id).ToList();
                    break;
            }

            return true;
        }

        public bool Pesquisa(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                Listas.empregos = Listas.empregos.Where(s => s.Descricao.Contains(searchString)).ToList();
            }

            return true;
        }

        public int? VerificaPg(string currentFilter, int? page)
        {
            throw new NotImplementedException();
        }
    }
}
