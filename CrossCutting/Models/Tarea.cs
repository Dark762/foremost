namespace CrossCutting.Models
{
    public class Tarea
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public bool Finalizado { get; set; }
        public bool Eliminado { get; set; }
        public string Tags { get; set; }
        public int IdPrioridad { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }

        // Navigation property to related entities
        public Usuario Usuario { get; set; }
        public Prioridad Prioridad { get; set; }
    }
}
