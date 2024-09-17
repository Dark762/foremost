namespace CrossCutting.Models
{
    public class Prioridad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        // Navigation property for related Tareas
        public ICollection<Tarea> Tareas { get; set; }
    }
}
