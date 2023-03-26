using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alura.LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Alura.LeilaoOnline.WebApp.Dados.EFCore
{
    public class LeilaoDaoComEFCore : ILeilaoDao
    {
        AppDbContext _context;

        public LeilaoDaoComEFCore()
        {
            _context = new AppDbContext();
        }

        public Leilao BuscarPorId(int id)
        {
            return _context.Leiloes.Find(id);
        }

        public IEnumerable<Leilao> BuscarTodos() => _context.Leiloes.Include(l => l.Categoria);

        public void Incluir(Leilao obj)
        {
            _context.Leiloes.Add(obj);
            _context.SaveChanges();
        }

        public void Alterar(Leilao obj)
        {
            _context.Leiloes.Update(obj);
            _context.SaveChanges();
        }

        public void Excluir(Leilao leilao)
        {
            _context.Leiloes.Remove(leilao);
            _context.SaveChanges();
        }
    }
}
