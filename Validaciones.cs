using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; //Agrego esta librería

namespace Validaciones
{
    class Validaciones
    {

		public static void Letras(KeyPressEventArgs v)
        {
			if (v.KeyChar != Convert.ToChar(Keys.Back))
			{
				if (char.IsLetter(v.KeyChar))
                {
					v.Handled = false;
                }
				//Esto es para espacios , ; /
                //else if (char.IsSeparator(v.KeyChar))
                //{
                //    v.Handled = false;
                //}
				else if (v.KeyChar.ToString().Equals(" "))
				{
					v.Handled = false;
				}
				else
                {
					v.Handled = true;
					MessageBox.Show("Por favor ingrese solo letras", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        public static void NumerosDecimales(KeyPressEventArgs v)
        {
			//Si la letra que presiona es diferente al delete (Esto me va a permitir borrar)
			if (v.KeyChar != Convert.ToChar(Keys.Back)) //KeyPressEventArgs.KeyChar Property: Gets or sets the character corresponding to the key pressed.
			{
				if (char.IsDigit(v.KeyChar))
				{
					v.Handled = false;
				}
				//Cambiar por "." si el idioma del visual es inglés
				else if (v.KeyChar.ToString().Equals(","))
				{
					v.Handled = false;
				}
				else
				{
					v.Handled = true;
					MessageBox.Show("Por favor ingrese en este campo números. Si se trata de un número decimal utilice la coma y no el punto", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
		}

		public static void NumerosEnteros(KeyPressEventArgs v)
        {
			if(v.KeyChar != Convert.ToChar(Keys.Back))
            {
				if (char.IsDigit(v.KeyChar))
                {
					v.Handled = false;
                }
				else
                {
					MessageBox.Show("Por favor ingrese solo números", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
