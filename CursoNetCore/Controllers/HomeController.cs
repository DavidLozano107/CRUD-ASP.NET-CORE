using CursoNetCore.Data;
using CursoNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CursoNetCore.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ApplicationDbContext _context;



		public HomeController(ILogger<HomeController> logger, ApplicationDbContext _context)
		{
			_logger = logger;
			this._context = _context;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			return View(await _context.Usuario.ToListAsync());
		}

		[HttpGet]
		public IActionResult CreateUsuario()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Usuario usuario)
		{
			if (ModelState.IsValid)
			{
				_context.Usuario.Add(usuario);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}

			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int? id)
		{
			if(id == null) {return NotFound();}

			var usuario = await _context.Usuario.FindAsync(id);

			if(usuario == null) { return NotFound(); }

			return View(usuario);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Usuario usuario)
		{
			if (ModelState.IsValid)
			{
				_context.Update(usuario);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			
			return View(usuario); 

		}

		[HttpGet()]
		public async Task<IActionResult> Details(int? id)
		{
			if(id == null) { return NotFound(); }

			//Buscamos al usuario
			var usuario = await _context.Usuario.FindAsync(id);

			if(usuario == null) { return NotFound();}

			return View(usuario);
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null) { return BadRequest();}
			
			//Busca a el usuario
			var usuario = await _context.Usuario.FindAsync(id);

			//Valida si el usuario existe
			if(usuario == null) { return NotFound();}

	
			return View(usuario);

		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteRegistro(int? id)
		{
			//Valida si el Id no sea null
			if(id != null)
			{
				//Busca a el usuario
				var usuario = await _context.Usuario.FindAsync(id);

				//Valida si el usuario existe
				if (usuario != null)
				{
					//Si el usuario existe entonces lo eliminamos
					_context.Usuario.Remove(usuario);
					await _context.SaveChangesAsync();
					return RedirectToAction(nameof(Index));
				}

				return NotFound();
			}

			return BadRequest();
		}





		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
