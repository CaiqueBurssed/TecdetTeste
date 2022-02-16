using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using TecdetTeste.Data;
using TecdetTeste.Models;

namespace TecdetTeste
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //deserializarPassagem();
            deserializarListaDePassagens();
        }

        //Deserializar uma única passagem.
        private static void deserializarPassagem()
        {
            try
            {
                Passagem passagem = null;
                using (StreamReader file = new StreamReader(@"C:\Users\User\Desktop\Tecdet\TecdetTeste\Dados\08002fluxo_21012020153212363_2.json"))
                {
                    string jsonString = file.ReadToEnd();
                    passagem = JsonConvert.DeserializeObject<Passagem>(jsonString);
                }
                Console.WriteLine(string.Format(" Placa: {0} \n Data: {1} \n Hora: {2} \n Equipamento: {3} \n Faixa: {4}", passagem.Placa, passagem.Data.ToString("dd/MM/yyyy"), passagem.Hora.ToString("T"), passagem.Equipamento, passagem.Faixa));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        //Deserializar todas as passagens.
        private static void deserializarListaDePassagens()
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(@"C:\Users\User\Desktop\Tecdet\TecdetTeste\Dados");

                int contador = 0;
                Passagem passagemDeserializada = null;
                foreach (var arquivo in di.GetFiles())
                {
                    using (StreamReader file = new StreamReader(arquivo.FullName))
                    {
                        Console.WriteLine(file.ReadToEnd());
                        passagemDeserializada = JsonConvert.DeserializeObject<Passagem>(file.ReadToEnd());
                        var context = new PassagemContext();

                        var passagem = new Passagem()
                        {
                            Placa = passagemDeserializada.Placa,
                            Data = passagemDeserializada.Data,
                            Hora = passagemDeserializada.Hora,
                            Equipamento = passagemDeserializada.Equipamento,
                            Faixa = passagemDeserializada.Faixa
                        };

                        context.Passagens.Add(passagem);
                        context.SaveChanges();
                    }
                    contador++;
                }
                Console.WriteLine(contador + " objetos Jsons foram importados com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

    }
}
