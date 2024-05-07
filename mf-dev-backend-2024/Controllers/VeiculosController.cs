using mf_dev_backend_2024.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mf_dev_backend_2024.Controllers
{
    public class VeiculosController : Controller
    {
        private readonly AppDbContext _context;
        public VeiculosController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dados = await _context.Veiculos.ToListAsync();   //Pegou os Veiculos do DataBase e armazenou na variável
            return View(dados);   //Returno a visualizaçao relacionada aos dados
        }

        //-----------------CREATE---------------------------

        public IActionResult Create()    //Criar novos //Identifica automaticamente que é metodo GET
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Veiculo veiculo)   //Post para receber o preenchimento dos formularios
        {
            if (ModelState.IsValid)             //check o requirement
            {
                _context.Veiculos.Add(veiculo); //adiciona no db
                await _context.SaveChangesAsync();  //salva lá
                return RedirectToAction("Index");    //retorna pro padrão
            }

            return View(veiculo);     
        }

        //-----------------EDITAR---------------------------

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            

            var dados = await _context.Veiculos.FindAsync(id);

            if(dados ==null)
                return NotFound();
 
            return View(dados);
        }
        //Depois que retornou os dados e agora ele vai editar:

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Veiculo veiculo)
        {
            if (id != veiculo.Id)          
                return NotFound();

            if (ModelState.IsValid)             //check o requirement
            {
                _context.Veiculos.Update(veiculo); //adiciona no db
                await _context.SaveChangesAsync();  //salva lá
                return RedirectToAction("Index");    //retorna pro padrão
            }

            return View();
        }

        //-----------------DETAIS---------------------------

        public async Task<IActionResult> Details(int? id)
        {   
            if(id == null) 
                return NotFound();

            var dados = await _context.Veiculos.FindAsync(id);

             if(dados == null) 
                     return NotFound();

            return View(dados);
        }

        //-----------------Delete---------------------------

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Veiculos.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Veiculos.FindAsync(id);

            if (dados == null)
                return NotFound();

            _context.Veiculos.Remove(dados);
            await _context.SaveChangesAsync();


            return RedirectToAction("Index");
        }

    }
}
