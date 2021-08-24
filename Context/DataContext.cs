using CRUD.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Context
{
    public class DataContext : DbContext
    {

        public DbSet<Tarefa> Tarefas { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarefa>(x =>
            {
                x.HasKey(y => y.Id);
                x.Property(y => y.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Tarefa>().ToTable("Tarefas");
            modelBuilder.Entity<Tarefa>().Property(x => x.Id);
            modelBuilder.Entity<Tarefa>().Property(x => x.Nome).HasMaxLength(100).HasColumnType("varchar(100)");
            modelBuilder.Entity<Tarefa>().Property(x => x.Descricao).HasMaxLength(100).HasColumnType("varchar(100)");
            modelBuilder.Entity<Tarefa>().Property(x => x.Data).HasColumnType("datetime");
        }
    }
}
