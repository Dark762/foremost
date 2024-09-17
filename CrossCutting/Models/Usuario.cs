﻿using System.Threading;

namespace CrossCutting.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }  
        public string? Apellido { get; set; } 
        public string? Correo { get; set; }  
        public string? Telefono { get; set; }
        public DateTime? Created_At { get; set; }  
        public DateTime? Updated_At { get; set; }

        // Navigation property for related Tareas
        public ICollection<Tarea> Tareas { get; set; }
    }
}
