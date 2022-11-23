using System;
using System.Windows.Forms;
using Dominio.Crud;
using Cannont.Atributos;

namespace Presentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        //Variables
        CPersona personas = new CPersona();
        AtributosPersons atributos = new AtributosPersons();
        bool edit = false;

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Normal) this.WindowState = FormWindowState.Maximized;
            else this.WindowState = FormWindowState.Normal;
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void getData()
        {
            CPersona personas = new CPersona();
            dgvDatos.DataSource = personas.Mostrar();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbSexo.SelectedIndex = 0;
            btnGuardar.Enabled = false;
            getData();
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            if (txtNombre.Text == "Nombre") txtNombre.Text = "";
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text == "") txtNombre.Text = "Nombre";
        }

        private void txtApellido_Enter(object sender, EventArgs e)
        {
            if (txtApellido.Text == "Apellido") txtApellido.Text = "";
        }

        private void txtApellido_Leave(object sender, EventArgs e)
        {
            if (txtApellido.Text == "") txtApellido.Text = "Apellido";
        }

        private void txtID_Enter(object sender, EventArgs e)
        {
            if (txtID.Text == "ID") txtID.Text = "";
        }

        private void txtID_Leave(object sender, EventArgs e)
        {
            if (txtID.Text == "") txtID.Text = "ID";
        }

        private void ClearTextBoxs()
        {
            txtID.Text = "ID";
            txtApellido.Text = "Apellido";
            txtNombre.Text = "Nombre";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            btnGuardar.Enabled = true;
            btnNuevo.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (edit == false)
            {
                //INSERTAR
                try
                {
                    atributos.Id = Convert.ToInt32(txtID.Text);
                    atributos.Nombre = txtNombre.Text;
                    atributos.Apellido = txtApellido.Text;
                    atributos.Sexo = cbSexo.Text;
                    personas.Insertar(atributos);
                    ClearTextBoxs();
                    getData();
                    btnGuardar.Enabled = false;
                    btnNuevo.Enabled = true;
                    MessageBox.Show("SE GUARDO UN REGISTRO DE FORMA EXITOSA", "INSERTADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"SE PRODUJO EL SIGUIENTE ERROR: {ex.ToString()}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (edit == true)
            {
                //ACTUALIZAR
                try
                {
                    atributos.Id = Convert.ToInt32(txtID.Text);
                    atributos.Nombre = txtNombre.Text;
                    atributos.Apellido = txtApellido.Text;
                    atributos.Sexo = cbSexo.Text;
                    personas.Modificar(atributos);
                    ClearTextBoxs();
                    getData();
                    btnGuardar.Enabled = false;
                    btnNuevo.Enabled = true;
                    txtID.Enabled = true;
                    edit = false;
                    MessageBox.Show("SE ACTUALIZÓ UN REGISTRO DE FORMA EXITOSA", "MODIFICADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"SE PRODUJO EL SIGUIENTE ERROR: {ex.ToString()}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                txtID.Enabled = false;
                btnNuevo.Enabled = false;
                btnGuardar.Enabled = true;
                edit = true;
                //CARGAR DATOS
                txtID.Text = dgvDatos.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = dgvDatos.CurrentRow.Cells[1].Value.ToString();
                txtApellido.Text = dgvDatos.CurrentRow.Cells[2].Value.ToString();
                cbSexo.Text = dgvDatos.CurrentRow.Cells[3].Value.ToString();
            }


        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "Buscar...") txtBuscar.Text = "";
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "")
            {
                txtBuscar.Text = "Buscar..";
                getData();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DialogResult dialog = new DialogResult();
                dialog = MessageBox.Show("¿DESEAS ELIMINAR ESTE REGISTRO?", "ELIMINAR", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes)
                {
                    try
                    {
                       atributos.Id = Convert.ToInt32(dgvDatos.CurrentRow.Cells[0].Value.ToString());
                        personas.Eliminar(atributos);
                        getData();
                        MessageBox.Show("REGISTRO ELIMINADO CORRECTAMENT","ELIMINADO",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"SE PRODUJO EL SIGUIENTE ERROR: {ex.ToString()}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                    }
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CPersona cPersona = new CPersona(); 
            dgvDatos.DataSource = cPersona.Buscar(txtBuscar.Text);
        }
    }
}
