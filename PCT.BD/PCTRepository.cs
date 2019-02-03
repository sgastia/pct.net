using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PCT.Dominio;

namespace PCT.BD
{
    public interface IPCTRepository
    {
        void Add(Concierto concierto);
        Task SaveChangesAsync();
        Task<List<Concierto>> Conciertos_ToListAsync();
        Task<Concierto> Conciertos_FindById(int? id);
        Task<Concierto> Conciertos_FindAsync(int id);
        void Update(Concierto concierto);
        void Remove(Concierto concierto);
        bool ConciertoExists(int id);
    }
    public class PCTRepository : IPCTRepository
    {
        private PCTContext _context;

        public PCTRepository(PCTContext context)
        {
            _context = context;
        }

        public void Add(Concierto concierto)
        {
            _context.Conciertos.Add(concierto);
        }

        public Task<List<Concierto>> Conciertos_ToListAsync()
        {
            return _context.Conciertos.ToListAsync();
        }

        public Task<Concierto> Conciertos_FindById(int? id)
        {
            return _context.Conciertos.FirstOrDefaultAsync(m => m.IdConcierto == id);
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public Task<Concierto> Conciertos_FindAsync(int id)
        {
            return _context.Conciertos.FindAsync(id);
        }

        public void Update(Concierto concierto)
        {
            _context.Conciertos.Update(concierto);
        }

        public void Remove(Concierto concierto)
        {
            _context.Conciertos.Remove(concierto);
        }

        public bool ConciertoExists(int id)
        {
            return _context.Conciertos.Any(e => e.IdConcierto == id);
        }
    }
}
