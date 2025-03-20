using Medicamentos_backend.Model;
using Medicamentos_backend.Service;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace Medicamentos_backend.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/medicamentos")]
    [ApiController]
    public class MedicamentosController : ControllerBase
    {
        private readonly MedicamentoServicio _servicio;

        public MedicamentosController()
        {
            _servicio = new MedicamentoServicio();
        }

        [HttpGet]
        public IActionResult GetMedicamentos() => Ok(_servicio.ObtenerMedicamentos());

        [HttpPost]
        public IActionResult AgregarMedicamento([FromBody] Medicamento medicamento)
        {
            _servicio.AgregarMedicamento(medicamento);
            return Ok();
        }

        [HttpPut]
        public IActionResult ActualizarMedicamento([FromBody] Medicamento medicamento)
        {
            _servicio.ActualizarMedicamento(medicamento);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarMedicamento(int id)
        {
            _servicio.EliminarMedicamento(id);
            return Ok();
        }
    }
}
