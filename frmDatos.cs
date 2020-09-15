using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions; //Regex

namespace Validaciones
{
    public partial class frmDatos : Form
    {
        string patternPass;
        string patternMail; 
        public frmDatos()
        {
            InitializeComponent();
            //Validar que la contraseña ingresada es correcta. Para esto necesito un string input y un string pattern
            //Mi pattern establece que la contraseña tenga al menos 1 letra mayúscula, 1 minúscula, 1 número y que su extensión sea entre 8 y 16 caracteres.
            //Mini resumen de lo que significan estas expresiones regulares 
            //^ y $ son mis anclas (Anchors specify a position in the string where a match must occur)
            //(?= subexpression ) es mi grouping construct
            //* y {n,m} son los quantifiers aquí utilizo:
            //* Matches the previous element zero or more times, acá también se podría utilizar el quantifier +
            //{n,m} Matches the previous element at least n times, but no more than m times
            //. [n-m] y \d son character classes
            //El . es como mi wildcard
            //[character_group] Matches any single character in character_group.By default, the match is case-sensitive.
            //\d Matches any decimal digit.
            //IR PROBANDO MI PATTERN en https://regex101.com/)
            patternPass = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)\S{8,16}$";
            patternMail = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Usted está a punto de salir. ¿Está seguro?", "SALIR", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.Letras(e);
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.Letras(e);
        }

        private void txtPromedio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.NumerosDecimales(e);
        }

        private void frmDatos_Load(object sender, EventArgs e)
        {
        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.NumerosEnteros(e);
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            if (Regex.IsMatch(txtPass.Text, patternPass)==false)
            {
                MessageBox.Show("La contraseña no es válida. Debe contener al menos una letra mayúscula, una mínuscula y un número. Su extensión debe ser de 8 a 16 caracteres", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            if (Regex.IsMatch(txtMail.Text, patternMail) == false)
            {
                MessageBox.Show("El mail ingresado no es válido", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (Regex.IsMatch(txtPass.Text, patternPass) && Regex.IsMatch(txtMail.Text, patternMail))
            {
                MessageBox.Show("Usuario ingresado con éxito", "AVISO", MessageBoxButtons.OK);
                txtNombre.Clear();
                txtApellido.Clear();
                txtEdad.Clear();
                txtPass.Clear();
                txtMail.Clear();
                txtPromedio.Clear();
            }
        }

        private void txtMail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Regex.IsMatch(txtMail.Text, patternMail))
            {
                picMail.Visible = true;
                if (e.KeyChar == Convert.ToChar(Keys.Back))
                {
                    picMail.Visible = false;
                }
            }
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Regex.IsMatch(txtPass.Text, patternPass))
            {
                picPass.Visible = true;
                if (e.KeyChar == Convert.ToChar(Keys.Back))
                {
                    picPass.Visible = false;
                }
            }
        }
    }
}
