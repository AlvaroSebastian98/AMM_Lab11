using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator.Views
{
    public partial class Calculadora : ContentPage
    {
        public Calculadora()
        {
            InitializeComponent();
            this.BindingContext = new OperacionesViewModel();
        }
    }
}
