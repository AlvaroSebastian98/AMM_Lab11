using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Calculator.ViewModels
{
    public class CalculadoraViewModel : ViewModelBase
    {
        #region Propiedades
        int valor1;
        public int Valor1
        {
            get { return valor1; }
            set
            {
                if (valor1 != value)
                {
                    valor1 = value;
                    OnPropertyChanged();
                }
            }
        }

        int valor2;
        public int Valor2
        {
            get { return valor2; }
            set
            {
                if (valor2 != value)
                {
                    valor2 = value;
                    OnPropertyChanged();
                }
            }
        }

        int suma;
        public int Suma
        {
            get { return suma; }
            set
            {
                if (suma != value)
                {
                    suma = value;
                    OnPropertyChanged();
                }
            }
        }

        int resta;
        public int Resta
        {
            get { return resta; }
            set
            {
                if (resta != value)
                {
                    resta = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region Comandos 
        public ICommand Sumar { protected set; get; }

        public ICommand Restar { protected set; get; }

        #endregion

        #region Constructor

        public CalculadoraViewModel()
        {

            Sumar = new Command(() =>
            {
                Suma = Valor1 + Valor2;
            });

            Restar = new Command(() =>
            {
                Resta = Valor1 - Valor2;
            });

        }
        #endregion
    }
}
