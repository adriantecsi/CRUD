using CRUD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Repository.Interfaces
{
    public interface ITarefaRepository
    {
        public Task AdicionarTarefas(List<Tarefa> tarefas);

        public IEnumerable<Tarefa> BuscarTodas();

        public Tarefa BuscarPorId(int id);
    }
}
