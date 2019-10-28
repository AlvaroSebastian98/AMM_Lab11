using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Ejercicio08.ViewModels
{
    public class OperacionesViewModel : ViewModelBase
    {

        #region Propiedades

        int currentState = 1;
        string mathOperator;
        double firstNumber, secondNumber;

        string valor;
        public string Valor
        {
            get { return valor; }
            set
            {
                if (valor != value)
                {
                    valor = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        public void OnSelectNumber(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string pressed = button.Text;

            if (Valor == "0"|| currentState < 0)
            {
                Valor = "";
                if (currentState < 0)
                    currentState *= -1;
            }

            Valor += pressed;

            double number;
            if (double.TryParse(Valor, out number))
            {
                Valor = number.ToString("N0");
                if (currentState == 1)
                {
                    firstNumber = number;
                }
                else
                {
                    secondNumber = number;
                }
            }
        }

        public void OnSelectOperator(object sender, EventArgs e)
        {
            currentState = -2;
            Button button = (Button)sender;
            string pressed = button.Text;
            mathOperator = pressed;
        }

        public void OnClear(object sender, EventArgs e)
        {
            firstNumber = 0;
            secondNumber = 0;
            currentState = 1;
            Valor = "0";
        }

        public void OnCalculate(object sender, EventArgs e)
        {
            if (currentState == 2)
            {
                var result = SimpleCalculator.Calculate(firstNumber, secondNumber, mathOperator);

                Valor = result.ToString();
                firstNumber = result;
                currentState = -1;
            }
        }       

    }
}