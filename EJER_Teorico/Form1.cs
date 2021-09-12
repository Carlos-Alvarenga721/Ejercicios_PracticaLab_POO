using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EJER_Teorico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //aqui ocupo el boton Calcular para hacer todas las operaciones
        private void btncalcular_Click(object sender, EventArgs e)
        {
            bool Punto1 = false, Punto2 = false;
            double num1, num2, num3, num4,sumatoria=0,Mayor,Menor;
            double[] Numeros = new double[4];
            num1 = Convert.ToDouble(txbnum1.Text);
            num2 = Convert.ToDouble(txbnum2.Text);
            num3 = Convert.ToDouble(txbnum3.Text);
            num4 = Convert.ToDouble(txbnum4.Text);
            Numeros[0] = num1;
            Numeros[1] = num2;
            Numeros[2] = num3;
            Numeros[3] = num4;

            //PRIMERA CONDICION
            //Indicar que los numeros tienen que ser mayores a 0 y no deben repetirse
            if (num1 > 0 && num2 > 0 && num3 > 0 && num4 > 0)
            {
                if (num1 != num2 && num1 != num3 && num1 != num4 && num2 != num3 && num2 != num4 && num3 != num4)
                {
                    Punto1 = true;
                    sumatoria = num1 + num2 + num3 + num4;
                }
                else
                {
                    MessageBox.Show("Los numeros no pueden repetirse, Digitar correctamente");                  
                }

            }
            else            
                MessageBox.Show("El numero debe ser positivo y mayor que cero, Digitar correctamente");

            //SEGUNDA CONDICION
            //La sumatoria de los 4 numeros no puede exceder el numero 200 ni ser igual a dicho numero
            if (Punto1 == true)
            {
                if(sumatoria >= 200)
                {
                    MessageBox.Show("No se puede seguir porque la sumatoria es igual a 200 o mayor a este numero, porfavor digitar nuevamente los numeros");
                    txbnum1.Clear();
                    txbnum2.Clear();
                    txbnum3.Clear();
                    txbnum4.Clear();

                }
                else
                {
                    Punto2 = true;
                }
            }

            //TERCERA Y CUARTA CONDICION
            //Aqui aplico la tercera y cuarta condicion del ejercicio, utilice una funcion
            //para que me diera quien de los 4 numeros era el mayor y el menor
            //Los numeros digitados en los textbox, Cambian en pantalla segun se cumpla las condiciones
            if (Punto2 == true)
            {
                Mayor = ObtMayorMenor(Numeros, 4);
                Menor = ObtMayorMenor(Numeros, 1);

                if(Menor > 10)
                {                  
                        if (Convert.ToDouble(txbnum1.Text)==Mayor)                    
                           txbnum1.Text = (Mayor+10).ToString();                  
                        if (Convert.ToDouble(txbnum2.Text) == Mayor)
                            txbnum2.Text = (Mayor+10).ToString();
                       if (Convert.ToDouble(txbnum3.Text) == Mayor)
                            txbnum3.Text = (Mayor+10).ToString();
                       if (Convert.ToDouble(txbnum4.Text) == Mayor)
                            txbnum4.Text = (Mayor+10).ToString();
                             Mayor = Mayor + 10;
                    MessageBox.Show($"El mayor numero es {Mayor}, mientras que el menor numero es {Menor}".ToString(), "Calculo de Condicion");
                }             
                if (Mayor < 50)
                {
                    if (Convert.ToDouble(txbnum1.Text) == Menor)
                        txbnum1.Text = (Menor - 5).ToString();
                    if (Convert.ToDouble(txbnum2.Text) == Menor)
                        txbnum2.Text = (Menor - 5).ToString();
                    if (Convert.ToDouble(txbnum3.Text) == Menor)
                        txbnum3.Text = (Menor -5 ).ToString();
                    if (Convert.ToDouble(txbnum4.Text) == Menor)
                        txbnum4.Text = (Menor - 5).ToString();
                    Menor = Menor -5;
                }
                MessageBox.Show($"El mayor numero es {Mayor}, mientras que el menor numero es {Menor}".ToString(), "Respuesta Final");
            }              
        }

        //Boton para salir del programa
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Funcion que me ayuda a obtener el mayor y menor de los 4 datos digitados
        //Utilizamos el metodo de la burbuja para hacer el codigo mas corto y ordenado
        public double ObtMayorMenor(double[] PNumArreglo,int MayorMenor)
        {
            double valor, aux;
            int I=0,j;
            for (I = 0; I < 3; I++)
            {
             for (j = I; j < 3; j++)
                {
                    if (PNumArreglo[I] > PNumArreglo[j+1])
                    {
                        aux = PNumArreglo[j];
                        PNumArreglo[j] = PNumArreglo[j+1];
                        PNumArreglo[j + 1] = aux;
                    }
                }
            }
            if (MayorMenor == 1)
            {
                valor = PNumArreglo[0];
            }
            else
                valor = PNumArreglo[3];
            return valor;
        }
    }
}
