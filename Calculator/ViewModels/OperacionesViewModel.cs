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

        #region Comandos 
        public ICommand OnSelectNumber { protected set; get; }

        public ICommand OnSelectOperator { protected set; get; }

        public ICommand OnClear { protected set; get; }

        public ICommand OnCalculate { protected set; get; }
        #endregion

        #region Constructor

        public OperacionesViewModel()
        {

            OnSelectNumber = new Command(() =>
            {
                Button button = (Button)sender;
                string pressed = button.Text;

                if (Valor == "0" || currentState < 0)
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
            });

            OnSelectOperator = new Command(() =>
            {
                currentState = -2;
                Button button = (Button)sender;
                string pressed = button.Text;
                mathOperator = pressed;
            });

            OnClear = new Command(() =>
            {
                firstNumber = 0;
                secondNumber = 0;
                currentState = 1;
                Valor = "0";
            });

            OnCalculate = new Command(() =>
            {
                if (currentState == 2)
                {
                    var result = SimpleCalculator.Calculate(firstNumber, secondNumber, mathOperator);

                    Valor = result.ToString();
                    firstNumber = result;
                    currentState = -1;
                }
            });

        }
        #endregion

    }
}