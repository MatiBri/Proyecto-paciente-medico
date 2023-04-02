using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPProgramacion
{
    public partial class Form1 : Form
    {
        int cc = 0;
        double ac = 0;
        double ap = 0;
        double acardio = 0;
        double aclinico = 0;
        double at = 0;
        int cclinico = 0;
        int cp = 0;
        int ccardio = 0;
        int ct = 0;
        double cm = 0;
        int cniños = 0;
        double apami = 0;
        int cpami = 0;
        bool nonNumberEntered = false;
        public Form1()

        {
            InitializeComponent();
        }
        public void habilitar(bool x)
        {
            txtApellido.Enabled = !x;
            txtApellidoM.Enabled = !x;
            txtDni.Enabled = !x;
            txtDNIM.Enabled = !x;
            txtMatricula.Enabled = !x;
            txtNombre.Enabled = !x;
            txtNombreM.Enabled = !x;
            txtTelefono.Enabled = !x;
            txtTelefonoM.Enabled = !x;
            cboEspecialidad.Enabled = !x;
            cboObraSocial.Enabled = !x;
            dtpFechaNacimiento.Enabled = !x;
            dtpFM.Enabled = !x;
            dtpConsulta.Enabled = !x;
            rbt1vez.Enabled = !x;
            rbtF.Enabled = !x;
            rbtFM.Enabled = !x;
            rbtM.Enabled = !x;
            rbtMM.Enabled = !x;
            rbtPaciente.Enabled = !x;
            btnCancelar.Enabled = !x;
            btnEditar.Enabled = x;
            btnEliminar.Enabled = !x;
            btnNuevo.Enabled = x;
            btnRegistrar.Enabled = !x;
            btnSalir.Enabled = x;
        }
        private void limpiar()
        {
            txtApellido.Clear();
            txtApellidoM.Clear();
            txtDni.Clear();
            txtDNIM.Clear();
            txtMatricula.Clear();
            txtNombre.Clear();
            txtNombreM.Clear();
            txtTelefono.Clear();
            txtTelefonoM.Clear();
            dtpFechaNacimiento.Value = DateTime.Today;
            dtpFM.Value = DateTime.Today;
            dtpConsulta.Value = DateTime.Today;
            rbt1vez.Checked = false;
            rbtF.Checked = false;
            rbtFM.Checked = false;
            rbtM.Checked = false;
            rbtMM.Checked = false;
            rbtPaciente.Checked = false;
        }
        private bool validar()
        {
            if (txtApellido.Text == "" || txtApellidoM.Text == "" || txtDni.Text == "" || txtDNIM.Text == "" || txtMatricula.Text == "" || txtNombre.Text == "" || txtNombreM.Text == ""
                || txtTelefono.Text == "" || txtTelefonoM.Text == "" || cboEspecialidad.SelectedIndex == -1 || cboObraSocial.SelectedIndex == -1)
            {
                MessageBox.Show("Debe completar todos los campos primero.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                txtNombre.Focus();
                return false;
            }
            else
                return true;
        }        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            limpiar();
            habilitar(true);
            btnEliminar.Enabled = true;

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea abandonar la aplicación?", "SALIR", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
            habilitar(false);
            btnEliminar.Enabled = false;
            btnEditar.Enabled = false;
            btnSalir.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
            habilitar(true);
            btnEditar.Enabled = true;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            habilitar(true);
            Consulta c = new Consulta();
            Paciente p = new Paciente();
            Médico m = new Médico();
            // Consulta
            c.pFecha = dtpConsulta.Value;
            c.pConsulta = rbt1vez.Checked;
            // Paciente
            p.pNombre = txtNombre.Text;
            p.pApellido = txtApellido.Text;
            p.pSexo = rbtF.Checked;
            p.pDni = Convert.ToInt32(txtDni.Text);
            p.pTelefono = Convert.ToInt32(txtTelefono.Text);
            p.pObraSocial = cboObraSocial.SelectedIndex + 1;
            p.pFechaNac = dtpFechaNacimiento.Value;
            // Medico
            m.pNombre = txtNombreM.Text;
            m.pApellido = txtApellidoM.Text;
            m.pDni = Convert.ToInt32(txtDNIM.Text);
            m.pTelefono = Convert.ToInt32(txtTelefonoM.Text);
            m.pSexo = rbtFM.Checked;
            m.pMatricula = Convert.ToInt32(txtMatricula.Text);
            m.pEspecialidad = cboEspecialidad.SelectedIndex + 1;
            m.pFechaNac = dtpFM.Value;
            //Comprobaciones
            validar();
            {
                if (txtDni.Text == txtDNIM.Text)
                    MessageBox.Show("El DNI ingresado no es correcto.", "Error DNI", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtDni.Focus();
            }
            //Cantidad y monto consultas  
            if (p.pObraSocial == +1)
            {
                c.pMonto = 750;
            }
            else
                     if (p.pObraSocial == +2)
            {
                c.pMonto = 250;
            }
            else
                  if (p.pObraSocial == +3)
            {
                c.pMonto = 100;
            }
            else
            {
                c.pMonto = 300;

            }
            {
                if (rbt1vez.Checked == true)
                    c.pMonto = (c.pMonto + 5 * c.pMonto / 100);
            }
            cc++;
            ac = ac + c.pMonto;
            lblCantidadConsultas.Text = cc.ToString();
            lblMontoConsultas.Text = "$" + ac.ToString();
            // promedio de monto de consulta por especialidad
            if (m.pEspecialidad == +1)
            {
                ap += c.pMonto;
                cp++;
                lblPediatra.Text = "$" + Math.Round((ap / cp), 2).ToString();
            }
            else
                if (m.pEspecialidad == +2)

            {
                cclinico++;
                aclinico += c.pMonto;
                lblClinica.Text = "$" + Math.Round((aclinico / cclinico), 2).ToString();
            }
            else
                if (m.pEspecialidad == +3)
            {
                ct++;
                at += c.pMonto;
                lblTraumatologia.Text = "$" + Math.Round((at / ct), 2).ToString();
            }
            else
            {
                ccardio++;
                acardio += c.pMonto;
                lblCardiologia.Text = "$" + Math.Round((acardio / ccardio), 2).ToString();
            }
            //mujer mayor de 70 con consulta mas cara
            {
                if (cc == 1 && p.pFechaNac.Year <= 1948 && p.pSexo == false)
                    cm = c.pMonto;
                else
                 if (c.pMonto > cm && p.pFechaNac.Year <= 1948 && p.pSexo == false)
                    cm = c.pMonto;
                lblMujer.Text = p.toStringPaciente();
            }
            //menores de 16 que se atienden en forma particular con medico que no sea pediatra
            {
                if (p.pFechaNac.Year <= 2002 && p.pObraSocial == +1 && m.pEspecialidad != +2)
                {
                    cniños++;
                    lblNiños.Text = cniños.ToString();
                }
            }
            // promedio de conultas por PAMI
            {
                if (p.pObraSocial == +3)
                {
                    apami += c.pMonto;
                    cpami++;
                    lblPamiCantidad.Text = "%" + (cpami * 100 / cc).ToString();
                    lblPamiPorcentaje.Text = "%" + Math.Round((apami * 100 / ac), 2).ToString();
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            habilitar(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Borrando datos del paciente... ¿Desea continuar?", "BORRAR", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                limpiar();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtTelefono_KeyDown(object sender, KeyEventArgs e)
        {
            {
                {
                    // Initialize the flag to false.
                    nonNumberEntered = false;

                    // Determine whether the keystroke is a number from the top of the keyboard.
                    if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
                    {
                        // Determine whether the keystroke is a number from the keypad.
                        if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                        {
                            // Determine whether the keystroke is a backspace.
                            if (e.KeyCode != Keys.Back)
                            {
                                // A non-numerical keystroke was pressed.
                                // Set the flag to true and evaluate in KeyPress event.
                                nonNumberEntered = true;
                            }
                        }
                    }
                    //If shift key was pressed, it's not a number.
                    if (Control.ModifierKeys == Keys.Shift)
                    {
                        nonNumberEntered = true;
                    }
                    if (Control.ModifierKeys== Keys.Alt)
                        {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            {

                // Check for the flag being set in the KeyDown event.
                if (nonNumberEntered == true)
                {
                    // Stop the character from being entered into the control since it is non-numerical.
                    e.Handled = true;
                }

            }
        }

        private void txtDni_KeyDown(object sender, KeyEventArgs e)
        {
            {
                nonNumberEntered = false;

                if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
                {
                    if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                    {
                        if (e.KeyCode != Keys.Back)
                        {
                            nonNumberEntered = true;
                        }
                    }
                }
                if (Control.ModifierKeys == Keys.Shift)
                {
                    nonNumberEntered = true;
                }
                if (Control.ModifierKeys == Keys.Alt)
                {
                    nonNumberEntered = true;
                }
            }
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                if (nonNumberEntered == true)
                {
                    e.Handled = true;
                }

            }
        }

        private void txtDNIM_KeyDown(object sender, KeyEventArgs e)
        {
            {
                nonNumberEntered = false;

                if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
                {
                    if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                    {
                        if (e.KeyCode != Keys.Back)
                        {
                            nonNumberEntered = true;
                        }
                        if (Control.ModifierKeys == Keys.Alt)
                        {
                            nonNumberEntered = true;
                        }
                    }
                }
                if (Control.ModifierKeys == Keys.Shift)
                {
                    nonNumberEntered = true;
                }
            }
        }

        private void txtDNIM_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                if (nonNumberEntered == true)
                {
                    e.Handled = true;
                }

            }
        }

        private void txtTelefonoM_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                if (nonNumberEntered == true)
                {
                    e.Handled = true;
                }

            }
        }

        private void txtTelefonoM_KeyDown(object sender, KeyEventArgs e)
        {
            {
                nonNumberEntered = false;

                if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
                {
                    if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                    {
                        if (e.KeyCode != Keys.Back)
                        {
                            nonNumberEntered = true;
                        }
                    }
                }
                if (Control.ModifierKeys == Keys.Shift)
                {
                    nonNumberEntered = true;
                }
                if (Control.ModifierKeys == Keys.Alt)
                {
                    nonNumberEntered = true;
                }
            }
        }

        private void txtMatricula_KeyDown(object sender, KeyEventArgs e)
        {
            {
                nonNumberEntered = false;

                if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
                {
                    if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                    {
                        if (e.KeyCode != Keys.Back)
                        {
                            nonNumberEntered = true;
                        }
                         if (Control.ModifierKeys== Keys.Alt)
                        {
                        nonNumberEntered = true;
                    }
                    }
                }
                if (Control.ModifierKeys == Keys.Shift)
                {
                    nonNumberEntered = true;
                }
                if (Control.ModifierKeys == Keys.Alt)
                {
                    nonNumberEntered = true;
                }
            }
        }

        private void txtMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                if (nonNumberEntered == true)
                {
                    e.Handled = true;
                }

            }
        }
    }
}
