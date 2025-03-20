using Medicamentos_backend.Model;
using Medicamentos_backend.Repository;

namespace Medicamentos_backend.Service
{
    public class MedicamentoServicio
    {
        private readonly MedicamentoRepositorio _repositorio;
        public MedicamentoServicio()
        {
            _repositorio = new MedicamentoRepositorio();
        }

        public List<Medicamento> ObtenerMedicamentos() => _repositorio.ObtenerMedicamentos();
        public void AgregarMedicamento(Medicamento medicamento) => _repositorio.AgregarMedicamento(medicamento);
        public void ActualizarMedicamento(Medicamento medicamento) => _repositorio.ActualizarMedicamento(medicamento);
        public void EliminarMedicamento(int id) => _repositorio.EliminarMedicamento(id);
    }
}
