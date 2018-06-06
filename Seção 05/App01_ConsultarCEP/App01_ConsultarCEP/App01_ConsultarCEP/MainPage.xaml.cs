using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Servico.Modelo;
using App01_ConsultarCEP.Servico;

namespace App01_ConsultarCEP
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            buttonBuscarEndereco.Clicked += BuscarEndereco;
		}

        private void BuscarEndereco(object sender, EventArgs eventArgs)
        {
            string cep = entryCEP.Text.Trim();
            if (ValidarCEP(cep))
            {
                try
                {
                    Endereco endereco = ViaCEPServico.BuscarEnderecoViaCEP(cep);
                    if (endereco != null)
                        labelResultado.Text = String.Format("Endereço: {0} {1} {2}", endereco.Logradouro, endereco.Localidade, endereco.UF);
                    else
                        DisplayAlert("ERRO", "CEP inexistente na base de dados dos Correios", "OK");
                }
                catch (Exception e)
                {
                    DisplayAlert("ERRO CRÍTICO", e.Message, "OK");
                }
            }
        }

        private bool ValidarCEP(string cep)
        {
            if(cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP deve conter 8 caracteres numéricos", "OK");
                return false;
            }

            int novoCEP = 0;
            if(!int.TryParse(cep, out novoCEP))
            {
                DisplayAlert("ERRO", "CEP deve conter apenas caracteres numéricos", "OK");
                return false;
            }

            return true;

        }
    }
}
