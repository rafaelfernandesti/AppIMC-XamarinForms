using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//using Xamarin.Forms.OpenWhatsApp;

namespace App4_GuiaDev.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Contato : ContentPage
    {
        public Contato()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Launcher.OpenAsync("tel:+551120872544");
            }catch(Exception ex)
            {
                DisplayAlert("Erro", "Deu ruim! "+ex.Message, "OK");
            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            try
            {
                await Launcher.OpenAsync("mailto:etecguarulhos@gmail.com");
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", "Deu ruim! " + ex.Message, "OK");
            }
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            try
            {
                //Xamarin.Forms.OpenWhatsApp.Chat.Open();
                await Launcher.OpenAsync("whatsapp://send?phone=+551120872544"); 
            }
            catch(Exception ex)
            {
                DisplayAlert("Erro", "Deu ruim! " + ex.Message, "OK");
            }
        }
    }
}