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
    public partial class Administracao : ContentPage
    {
        public static Administracao AdmCurso { get; set; }
        public Administracao()
        {
            InitializeComponent();
            lblDescricaoAdm.Text = retornaDescricao();
            this.BindingContext = this;
        }

        public string retornaDescricao()
        {
            return "O TÉCNICO EM ADMINISTRAÇÃO é o profissional que adota postura ética na execução da rotina administrativa, na elaboração do planejamento da produção e materiais, recursos humanos, financeiros e mercadológicos. Realiza atividades de controles e auxilia nos processos de direção utilizando ferramentas da informática básica. Fomenta ideias e práticas empreendedoras. Desempenha suas atividades observando as normas de segurança, saúde e higiene do trabalho, bem como as de preservação ambiental.";
        }

        private async void BtnEstagios_Clicked(object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://www.nube.com.br/estudantes/vagas/busca-avancada", BrowserLaunchMode.SystemPreferred);
        }
    }
}