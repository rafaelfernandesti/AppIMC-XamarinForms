using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppIMC
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                double peso = Double.Parse(txt_peso.Text);
                double altura = Double.Parse(txt_altura.Text);

                double imc = peso / (altura * altura);

                string classificacao = "";

                if(imc < 17)
                {
                    classificacao = "Muito abaixo do peso";
                }else if(imc >=17 && imc < 18.5)
                {
                    classificacao = "Abaixo do peso";
                }else if(imc >=18.5 && imc < 25){
                    classificacao = "Peso normal";
                }
                else if(imc >=25 && imc < 30)
                {
                    classificacao = "Peso normal";
                }
                else if (imc >= 30 && imc < 35)
                {
                    classificacao = "Acima do peso";
                }
                else if (imc >= 30 && imc < 35)
                {
                    classificacao = "Obesidade I";
                }
                else if (imc >= 35 && imc < 40)
                {
                    classificacao = "Obesidade II";
                }else if(imc >= 40)
                {
                    classificacao = "Obesidade III (mórbida)";
                }
                lbl_resultado.Text = "Seu IMC é: "+ imc.ToString("0.00") +" e sua classificação é " + classificacao;
                lbl_resultado.HorizontalTextAlignment = TextAlignment.Center;
            }
            catch(Exception erro)
            {
                lbl_resultado.Text = "Desculpe, houve um erro no cálculo!";
            }
        }
    }
}
