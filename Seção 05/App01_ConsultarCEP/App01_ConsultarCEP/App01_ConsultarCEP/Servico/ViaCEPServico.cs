using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App01_ConsultarCEP.Servico.Modelo;
using Newtonsoft.Json;

namespace App01_ConsultarCEP.Servico
{
    class ViaCEPServico
    {
        private static string enderecoURLSemCEP = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string enderecoURLComCEP = string.Format(enderecoURLSemCEP, cep);
            WebClient wc = new WebClient();
            string enderecoRetornado = wc.DownloadString(enderecoURLComCEP);
            Endereco endereco = JsonConvert.DeserializeObject<Endereco>(enderecoRetornado);
            if (endereco.CEP == null)
                return null;
            else
                return endereco;
        }
    }
}
