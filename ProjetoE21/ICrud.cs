namespace ProjetoE21
{
    public interface ICrud<T>
    {
        public List<T> consultar();
        public bool adicionar(T t);
        public bool editar(T t);
        public void deletar(T t);
    }
}