using EtecGru.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EtecGru
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : ContentPage
    {
        public Master()
        {
            InitializeComponent();
        }

        private async void BtnSecretaria_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false;
            await App.MasterD.Detail.Navigation.PushAsync(new Secretaria());
        }

        private async void BtnContato_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false;            
            await App.MasterD.Detail.Navigation.PushAsync(new Contato());
        }

        private async void BtnAdm_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false;
            await App.MasterD.Detail.Navigation.PushAsync(new Administracao());
        }
    }
}