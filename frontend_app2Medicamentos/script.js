document.addEventListener("DOMContentLoaded", () => {
    const form = document.getElementById("medicamentoForm");
    const lista = document.getElementById("medicamentosList");

    form.addEventListener("submit", async (event) => {
        event.preventDefault();
        const medicamento = {
            nombre: document.getElementById("nombre").value,
            tipo: document.getElementById("tipo").value,
            fechaFabricacion: document.getElementById("fechaFabricacion").value,
            fechaVencimiento: document.getElementById("fechaVencimiento").value,
            imagen: document.getElementById("imagen").value
        };
        await fetch("http://localhost:5000/api/medicamentos", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(medicamento)
        });
        cargarMedicamentos();
        form.reset();
    });

    async function cargarMedicamentos() {
        const response = await fetch("http://localhost:5000/api/medicamentos");
        const medicamentos = await response.json();
        lista.innerHTML = "";
        medicamentos.forEach(m => {
            const li = document.createElement("li");
            li.innerHTML = `${m.nombre} - ${m.tipo} - ${m.fechaFabricacion} - ${m.fechaVencimiento} <button onclick="eliminarMedicamento(${m.id})">Eliminar</button>`;
            lista.appendChild(li);
        });
    }

    window.eliminarMedicamento = async (id) => {
        await fetch(`http://localhost:5000/api/medicamentos/${id}`, { method: "DELETE" });
        cargarMedicamentos();
    };

    cargarMedicamentos();
});
