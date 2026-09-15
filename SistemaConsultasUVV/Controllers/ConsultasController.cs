using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaConsultasUVV.Data;
using SistemaConsultasUVV.Models;

namespace SistemaConsultasUVV.Controllers
{
    [Authorize]
    public class ConsultasController : Controller
    {
        private readonly AppDbContext _context;

        public ConsultasController(AppDbContext context)
        {
            _context = context;
        }

        // LISTAR CONSULTAS
        public async Task<IActionResult> Index()
        {
            int usuarioId = ObterUsuarioId();

            var consultas = await _context.Consultas
                .Where(c => c.UsuarioId == usuarioId)
                .OrderBy(c => c.DataHora)
                .ToListAsync();

            return View(consultas);
        }

        // ABRIR TELA DE CRIAÇÃO
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // SALVAR NOVA CONSULTA
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Consulta consulta)
        {
            if (!ModelState.IsValid)
            {
                return View(consulta);
            }

            consulta.UsuarioId = ObterUsuarioId();

            _context.Consultas.Add(consulta);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // ABRIR TELA DE EDIÇÃO
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            int usuarioId = ObterUsuarioId();

            var consulta = await _context.Consultas
                .FirstOrDefaultAsync(
                    c => c.Id == id &&
                         c.UsuarioId == usuarioId);

            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // SALVAR ALTERAÇÃO
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            Consulta consulta)
        {
            if (id != consulta.Id)
            {
                return NotFound();
            }

            int usuarioId = ObterUsuarioId();

            var consultaBanco = await _context.Consultas
                .FirstOrDefaultAsync(
                    c => c.Id == id &&
                         c.UsuarioId == usuarioId);

            if (consultaBanco == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(consulta);
            }

            consultaBanco.Especialidade = consulta.Especialidade;
            consultaBanco.DataHora = consulta.DataHora;
            consultaBanco.Descricao = consulta.Descricao;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // ABRIR TELA DE EXCLUSÃO
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            int usuarioId = ObterUsuarioId();

            var consulta = await _context.Consultas
                .FirstOrDefaultAsync(
                    c => c.Id == id &&
                         c.UsuarioId == usuarioId);

            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // CONFIRMAR EXCLUSÃO
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            int usuarioId = ObterUsuarioId();

            var consulta = await _context.Consultas
                .FirstOrDefaultAsync(
                    c => c.Id == id &&
                         c.UsuarioId == usuarioId);

            if (consulta == null)
            {
                return NotFound();
            }

            _context.Consultas.Remove(consulta);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // PEGAR ID DO USUÁRIO LOGADO
        private int ObterUsuarioId()
        {
            return int.Parse(
                User.FindFirstValue(
                    ClaimTypes.NameIdentifier)!);
        }
    }
}