using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CursoNetCore.Models;

namespace CursoNetCore.Data
{
	public class ApplicationDbContext :DbContext
	{
		
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}


		public DbSet<Usuario> Usuario { get; set; }



	}
}
