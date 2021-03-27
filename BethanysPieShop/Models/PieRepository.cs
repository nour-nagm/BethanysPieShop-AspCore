using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly AppDbContext appDbContext;

        public PieRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public IEnumerable<Pie> AllPies => appDbContext.Pies.Include(c => c.Category); 
        public IEnumerable<Pie> PiesOfTheWeek => appDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
        public Pie GetPieById(int pieId) => appDbContext.Pies.FirstOrDefault(p => p.PieId == pieId);
    }
}