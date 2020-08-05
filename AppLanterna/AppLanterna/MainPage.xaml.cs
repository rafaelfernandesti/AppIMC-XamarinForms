using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using Plugin.Battery;
using Plugin.Battery.Abstractions;

namespace AppLanterna
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        bool lanterna_ligada = false;
        public MainPage()
        {
            InitializeComponent();

            btnOnOff.Source = ImageSource.FromResource("AppLanterna.Imagens.desligado.png");

            Carrega_Informacoes_Bateria();
        }

        private async void Carrega_Informacoes_Bateria()
        {
            try
            {
                if (CrossBattery.IsSupported)
                {
                    CrossBattery.Current.BatteryChanged -= Mudanca_Status_Bateria;
                    CrossBattery.Current.BatteryChanged += Mudanca_Status_Bateria;
                }
                else
                {
                    lbl_bateria_fraca.Text = "As informações sobre a bateria não estão disponíveis.";
                }
            }catch(Exception ex)
            {
                await DisplayAlert("Informações de bateria - Ocorreu um erro\n", ex.Message,"Certu!");
            }
        }

        private async void Mudanca_Status_Bateria(object sender, BatteryChangedEventArgs e)
        {
            try
            {
                lbl_porcentagem_restante.Text = e.RemainingChargePercent.ToString() + "%";

                if (e.IsLow)
                {
                    lbl_bateria_fraca.Text = "Atenção! Bateria fraca!";
                }
                else
                {
                    lbl_bateria_fraca.Text = "Níveis aceitáveis";
                    lbl_bateria_fraca.TextColor = Color.Aqua;
                }

                switch (e.Status)
                {
                    case BatteryStatus.Charging:
                        lbl_status.Text = "Carregando";
                        break;
                    case BatteryStatus.Discharging:
                        lbl_status.Text = "Descarregando";
                        break;
                    case BatteryStatus.Full:
                        lbl_status.Text = "Carregada";
                        break;
                    case BatteryStatus.NotCharging:
                        lbl_status.Text = "Sem carregar";
                        break;
                    default:
                        lbl_status.Text = "Desconhecido";
                        break;
                }

                switch (e.PowerSource)
                {
                    case PowerSource.Ac:
                        lbl_fonte_carregamento.Text = "Carregador";
                        break;
                    case PowerSource.Battery:
                        lbl_fonte_carregamento.Text = "Bateria";
                        break;
                    case PowerSource.Usb:
                        lbl_fonte_carregamento.Text = "USB";
                        break;
                    case PowerSource.Wireless:
                        lbl_fonte_carregamento.Text = "Sem fio";
                        break;
                    default:
                        lbl_fonte_carregamento.Text = "Desconhecido";
                        break;
                }
            }
            catch(Exception ex)
            {
                await DisplayAlert("Status - Ocorreu um erro\n", ex.Message, "Certu!");
            }
        }

        private async void btnOnOff_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!lanterna_ligada)
                {
                    lanterna_ligada = true;

                    btnOnOff.Source = ImageSource.FromResource("AppLanterna.Imagens.ligado.png");

                    Vibration.Vibrate(TimeSpan.FromSeconds(1));

                    await Flashlight.TurnOnAsync();
                }
                else
                {
                    lanterna_ligada = false;

                    btnOnOff.Source = ImageSource.FromResource("AppLanterna.Imagens.desligado.png");

                    Vibration.Vibrate(TimeSpan.FromSeconds(1));

                    await Flashlight.TurnOffAsync();
                }
            }catch(Exception ex)
            {
                await DisplayAlert("Botão - Ocorreu um erro\n", ex.Message, "Certu!");
            }
        }
    }
}
