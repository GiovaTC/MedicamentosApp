using Medicamentos_backend.Model;
using MySqlConnector;

namespace Medicamentos_backend.Repository
{
    public class MedicamentoRepositorio
    {
        private readonly string _connectionString = "Server=localhost;Database=farmacia;User=giovanny;Password=tapiero";

        // obtener medicamentos
        public List<Medicamento> ObtenerMedicamentos()
        {
            var medicamentos = new List<Medicamento>();
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            using var command = new MySqlCommand("SELECT * FROM medicamentos", connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                medicamentos.Add(new Medicamento
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Nombre = reader["nombre"].ToString(),
                    Tipo = reader["tipo"].ToString(),
                    FechaFabricacion = Convert.ToDateTime(reader["fecha_fabricacion"]),
                    FechaVencimiento = Convert.ToDateTime(reader["fecha_vencimiento"]),
                    Imagen = reader["imagen"].ToString()
                });
            }
            return medicamentos;
        }

        // agregar medicamentos
        public void AgregarMedicamento(Medicamento medicamento)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            using var command = new MySqlCommand("INSERT INTO medicamentos (nombre, tipo, fecha_fabricacion, fecha_vencimiento, imagen) VALUES (@nombre, @tipo, @fechaFabricacion, @fechaVencimiento, @imagen)", connection);
            command.Parameters.AddWithValue("@nombre", medicamento.Nombre);
            command.Parameters.AddWithValue("@tipo", medicamento.Tipo);
            command.Parameters.AddWithValue("@fechaFabricacion", medicamento.FechaFabricacion);
            command.Parameters.AddWithValue("@fechaVencimiento", medicamento.FechaVencimiento);
            command.Parameters.AddWithValue("@imagen", medicamento.Imagen);
            command.ExecuteNonQuery();
        }


        // actualizar medicamentos
        public void ActualizarMedicamento(Medicamento medicamento)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            using var command = new MySqlCommand("UPDATE medicamentos SET nombre = @nombre, tipo = @tipo, fecha_fabricacion = @fechaFabricacion, fecha_vencimiento = @fechaVencimiento, imagen = @imagen WHERE id = @id ", connection);
            command.Parameters.AddWithValue("@id", medicamento.Id);
            command.Parameters.AddWithValue("@nombre", medicamento.Nombre);
            command.Parameters.AddWithValue("@tipo", medicamento.Tipo);
            command.Parameters.AddWithValue("@fechaFabricacion", medicamento.FechaFabricacion);
            command.Parameters.AddWithValue("@fechaVencimiento", medicamento.FechaVencimiento);
            command.Parameters.AddWithValue("@imagen", medicamento.Imagen);
            command.ExecuteNonQuery();
        }

        // eliminar medicamentos
        public void EliminarMedicamento(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            using var command = new MySqlCommand("DELETE FROM medicamentos WHERE id = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }
    }
}
