using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecdetTeste.Models;

namespace TecdetTeste.Data
{
    class SqlPassagemRepo : IPassagemRepo
    {
        private readonly PassagemContext _context;
        public SqlPassagemRepo(PassagemContext context)
        {
            _context = context;
        }

        public bool saveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void createPassagem(Passagem passagem)
        {
            if (passagem == null)
            {
                throw new ArgumentNullException(nameof(passagem));
            }
            _context.Passagens.Add(passagem);
        }

        public Passagem getPassagemById(int id)
        {
            return _context.Passagens.FirstOrDefault(p => p.Id == id);
        }
    }
}
