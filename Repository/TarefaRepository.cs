using CRUD.Context;
using CRUD.Entities;
using CRUD.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Repository
{
    public class TarefaRepository : ITarefaRepository
    {
        private DataContext _context;
        public TarefaRepository(DataContext context)
        {
            _context = context;
        }
        public async Task AdicionarTarefas(List<Tarefa> tarefas)
        {

            await _context.AddRangeAsync(tarefas);

            _context.SaveChanges();
        }

        public Tarefa BuscarPorId(int id)
        {
            return _context.Tarefas.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Tarefa> BuscarTodas()
        {
            return _context.Tarefas;
        }
    }
}
