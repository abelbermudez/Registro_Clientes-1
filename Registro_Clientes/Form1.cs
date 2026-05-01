using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Data.Entity;
using Registro_Clientes.Repository;
namespace Registro_Clientes
{
    public partial class Form1 : Form
    {
        // Campo 'repo' añadido para resolver CS0103.
        // Idealmente debe reemplazarse por el tipo real de su repositorio, p. ej. RepositorioClientes repo;
        private ClienteRepository repo = new ClienteRepository();  // ✅ Correcto

        public Form1()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
           
            CargarClientes();
        }

       
        private void CargarClientes()
        {
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = repo.ObtenerTodos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
             string.IsNullOrWhiteSpace(txtTelefono.Text) ||
             string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Cliente cliente = new Cliente
            {
                Nombre = txtNombre.Text,
                Telefono = txtTelefono.Text,
                Correo = txtCorreo.Text
            };

            repo.Guardar(cliente);
            CargarClientes();
            Limpiar();
            MessageBox.Show("Cliente guardado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow != null)
            {
                int id = (int)dgvClientes.CurrentRow.Cells["Id"].Value;
                DialogResult result = MessageBox.Show("¿Eliminar este cliente?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    repo.Eliminar(id);
                    CargarClientes();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un cliente para eliminar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Limpiar()
        {
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
        }
    }
}
