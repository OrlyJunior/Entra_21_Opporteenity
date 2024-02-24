using MMLib.Extensions;
using ProjetoE21.Dados;
using ProjetoE21.Models;
using System.Globalization;
using System.Text;

namespace ProjetoE21.Ordenacao
{
    public class OrdenaJovens
    {
        public bool Pesquisa(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                Listas.cadastrosJ = Listas.cadastrosJ.Where(s => s.Nome.ToLower().RemoveDiacritics().Contains(searchString.ToLower().RemoveDiacritics())).ToList();
            }

            return true;
        }
    }
}
