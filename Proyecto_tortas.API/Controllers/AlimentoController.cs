using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_tortas.API.Models;

namespace Proyecto_tortas.API.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class AlimentoController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public AlimentoController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<List<Alimento>> getAllAlimentos()
        {
            List<Alimento> alimentos = new List<Alimento>();
            alimentos = await context.Alimentos.ToListAsync();
            return alimentos;
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Alimento>> getAlimento(int id)
        {
            var alimentos = new Alimento();
            alimentos = await context.Alimentos.FirstOrDefaultAsync(x => x.Id == id);
            if (alimentos == null)
            {
                return NotFound();
            }
            
                return alimentos;
            
                
        }

        [HttpPost]
        public async Task<ActionResult<int>> postAlimento(Alimento alimento)
        {
            context.Add(alimento);
            await context.SaveChangesAsync();
            return alimento.Id;
        }

        


        


    }
}
