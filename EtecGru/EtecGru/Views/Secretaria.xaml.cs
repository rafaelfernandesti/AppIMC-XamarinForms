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
    public partial class Secretaria : ContentPage
    {
        bool temDeclaracao;
        bool temHistorico;
        bool temSptrans;
        bool temEmtu;
        public bool TemDeclaracao {
            get {
                return temDeclaracao;
            } set
            {
                temDeclaracao = value;
            }
        }
        public bool TemHistorico
        {
            get
            {
                return temHistorico;
            }
            set
            {
                temHistorico = value;
            }
        }
        public bool TemSptrans
        {
            get
            {
                return temSptrans;
            }
            set
            {
                temSptrans = value;
            }
        }
        public bool TemEmtu
        {
            get
            {
                return temEmtu;
            }
            set
            {
                temEmtu = value;
            }
        }
        public Secretaria()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        private async void btnEnviarPedido_Clicked(object sender, EventArgs e)
        {
            string nome = entNome.Text;
            string email = entEmail.Text;
            string turma = entTurma.Text;
            string dadosPessoais = "Nome: "+ nome + " Email: " + email + " Turma: " + turma+"\n";
            string detalhes = entDetalhes.Text;
            string mensagem = dadosPessoais + @"Você está solicitando os seguintes documentos: " +
                (temDeclaracao ? " DECLARAÇÃO; " : "") +
                (temEmtu ? " EMTU; " : "") +
                (temSptrans ? " SPTRANS; " : "") +
                (temHistorico ? " HISTÓRICO; " : "") +
                "com os detalhes a seguir: " + detalhes;
            ;
            DisplayAlert("Solicitação em andamento...", mensagem, "OK");
            Email.ComposeAsync("Solicitação - Secretaria", mensagem, "e295acad@cps.sp.gov.br");
        }

        private void switchDeclaracao_Tapped(object sender, EventArgs e)
        {
            
        }

        private void switchSptrans_Tapped(object sender, EventArgs e)
        {

        }

        private void switchEmtu_Tapped(object sender, EventArgs e)
        {

        }

        private void switchHistorico_Tapped(object sender, EventArgs e)
        {

        }
    }
}