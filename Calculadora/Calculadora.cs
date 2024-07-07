using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Calculadora : Form
    {
        string operadorSeleccionado; //Variable global.
        int valorAcumulado; //Persiste en memoria y no es olvidado cuando termine el método.
        public Calculadora()
        {
            InitializeComponent();
        }

        private void NumeroAccion_Click(object sender, EventArgs e) //De esta forma centralizamos el riesgo y la lógica a este simple metodo.
        {
            Button boton = (Button)sender;
            int botonValor = int.Parse(boton.Text);        //Acumulamos el valor del boton con el actual, parseamos para usar enteros.
            int valorActual = int.Parse(txtValue.Text);              
            valorActual = valorActual * 10 + botonValor;   

            txtValue.Text = valorActual.ToString();
        }

        private void OperadorAccion_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operadorSeleccionado = button.Text;
            valorAcumulado = int.Parse(txtValue.Text);
            txtValue.Text = "0";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtValue.Text = "0";
            valorAcumulado = 0;                        //Por las dudas, hacemos limpieza de variables globales.
            operadorSeleccionado = string.Empty;
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            int segundoValorAcumulado = int.Parse(txtValue.Text);
            int result = 0;

            switch (operadorSeleccionado)
            {
                case "+":
                    result = valorAcumulado + segundoValorAcumulado;
                    break;
                case "-":
                    result = valorAcumulado - segundoValorAcumulado;
                    break;
                case "*":
                    result = valorAcumulado * segundoValorAcumulado;
                    break;
                case "/":
                    // Asegurarse de que el divisor no sea cero
                    if (segundoValorAcumulado != 0)
                        result = valorAcumulado / segundoValorAcumulado;
                    else
                    {
                        MessageBox.Show("Error: No se puede dividir por cero.");
                        return;
                    }
                    break;
            }

            txtValue.Text = result.ToString();
        }
    }
}
