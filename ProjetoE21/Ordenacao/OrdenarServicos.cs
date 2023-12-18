using ProjetoE21.Dados;
using ProjetoE21.Interfaces;
using ProjetoE21.Models;

namespace ProjetoE21.Ordenacao
{
    public class OrdenarServicos : IOrdenar
    {
        public bool Ordena(string sorter)
        {
            switch (sorter)
            {
                case "nome_desc":
                    Listas.servicos = Listas.servicos.OrderByDescending(n => n.Descricao).ToList();
                    break;
                case "nome":
                    Listas.servicos = Listas.servicos.OrderBy(n => n.Descricao).ToList();
                    break;
                default:
                    Listas.servicos = Listas.servicos.OrderBy(n => n.Id).ToList();
                    break;
            }

            return true;
        }

        public bool Pesquisa(string searchString)
        {
            List<Servico> emp = new();

            if (!String.IsNullOrEmpty(searchString))
            {
                Listas.servicos = Listas.servicos.Where(s => s.Descricao.Contains(searchString)).ToList();
            }

            return true;
        }

        public int? VerificaPg(string currentFilter, int? page)
        {
            throw new NotImplementedException();
        }
    }
}
