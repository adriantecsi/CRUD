using CRUD.Entities;
using CRUD.Repository.Interfaces;
using CRUD.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Services
{
    public class TarefaService : ITarefaService
    {

        private ITarefaRepository _tarefaRepository;

        public TarefaService(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task AdicionarTarefasAsync()
        {
            var listaTarefa = new List<Tarefa>();

            var tarefa = new Tarefa()
            {
                Nome = "Estudar",
                Descricao = "kit Noob",
                Data = DateTime.Now
            };

            var tarefa1 = new Tarefa()
            {
                Nome = "Estudar",
                Descricao = "Adriano Noob",
                Data = DateTime.Now
            };

            var tarefa2 = new Tarefa()
            {
                Nome = "Estudar",
                Descricao = "Kaeru Foda",
                Data = DateTime.Now
            };

            listaTarefa.Add(tarefa);
            listaTarefa.Add(tarefa1);
            listaTarefa.Add(tarefa2);

            await _tarefaRepository.AdicionarTarefas(listaTarefa);

        }

        public Tarefa BuscarPorId(int id)
        {
            return _tarefaRepository.BuscarPorId(id);
        }

        public IEnumerable<Tarefa> BuscarTodas()
        {
            var retorno = _tarefaRepository.BuscarTodas();

            return retorno;
        }
    }
}
