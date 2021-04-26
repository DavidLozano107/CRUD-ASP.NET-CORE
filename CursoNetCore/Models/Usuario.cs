using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CursoNetCore.Models
{
	public class Usuario
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage ="El nombre es obligatorio")]
		public string Nombre { get; set; }
		
		[Required(ErrorMessage = "El Teléfono es obligatorio")]
		[Display(Name ="Teléfono")]
		public string Telefeno { get; set; }
		
		[Required(ErrorMessage ="El nombre es obligatorio")]
		public string Celular { get; set; }

		[Required(ErrorMessage ="El email es obligatorio")]
		[Display(Name ="Correo Electronico")]
		public string Enail { get; set; }

	}
}
