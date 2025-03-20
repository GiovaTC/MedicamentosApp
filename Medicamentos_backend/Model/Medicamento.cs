namespace Medicamentos_backend.Model
{
    public class Medicamento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public DateTime FechaFabricacion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string Imagen { get; set; }

    }
}
