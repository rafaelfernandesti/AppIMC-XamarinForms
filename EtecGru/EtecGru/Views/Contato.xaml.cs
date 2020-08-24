using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EtecGru.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Contato : ContentPage
    {
        public Contato()
        {
            InitializeComponent();
        }

        private async void btnEnviarMensagem_Clicked(object sender, EventArgs e)
        {
            var mensagem = entryMensagem.Text;
            var email = entryEmail.Text;
            var nome = entryNome.Text;
            //DisplayAlert("Mensagem enviada!", mensagem, "OK");
            await Email.ComposeAsync("Mensagem de " + nome + ". Responder para: " + email, mensagem,"rafa.fernan10@gmail.com");
        }

        private async void btnSite_Clicked(object sender, EventArgs e)
        {
            await Browser.OpenAsync("http://etecguarulhos.com.br", BrowserLaunchMode.SystemPreferred);
        }

        private void btnLigar_Clicked(object sender, EventArgs e)
        {
            string number = "+551120872544";
            PhoneDialer.Open(number);
        }
    }
}