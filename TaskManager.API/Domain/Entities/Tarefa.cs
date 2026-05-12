namespace TaskManager.API.Domain.Entities
{
    public class Tarefa
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime? DataConclusao { get; private set; }
        public string Descricao { get; private set; }
        public bool Concluida { get; private set; }


        public void Concluir()
        {
            if (Concluida)
                throw new InvalidOperationException("A tarefa já foi concluida!");
            Concluida = true;
            DataConclusao = DateTime.UtcNow;
        }

        public Tarefa(string nome, string descricao)
        {
            Nome = nome;
            DataCriacao = DateTime.UtcNow;
            Descricao = descricao;
            Concluida = false;
            DataConclusao = null;
        }

        public void Editar(string nome, string descricao)
        {
            if (string.IsNullOrEmpty(nome)) throw new ArgumentException("Nome não pode ser vazio.");
            if (string.IsNullOrEmpty(descricao)) throw new ArgumentException("Descrição não pode ser vazia.");

            Nome = nome;
            Descricao = descricao;
        }
    }

    

}
