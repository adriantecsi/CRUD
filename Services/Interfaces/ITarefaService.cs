using CRUD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Services.Interfaces
{
    public interface ITarefaService
    {
        public Task AdicionarTarefasAsync();

        public IEnumerable<Tarefa> BuscarTodas();

        public Tarefa BuscarPorId(int id);
    }
}
