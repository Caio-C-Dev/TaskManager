namespace TaskManager.API.Application.UseCases.ListarTarefas
{
    public class ListarTarefasResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Concluida { get; set; }

    }
}
