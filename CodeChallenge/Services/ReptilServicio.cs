using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeChallenge.Data.Model;
using CodeChallenge.Services.Interfaces;
using CodeChallenge.Services.Model;

namespace CodeChallenge.Services
{
    public class ReptilServicio : IReptilServicio
    {
        private int DiasSinAlimentacionCambioDePiel = 3;

        public async Task<double> CalcularAlimento(double peso, double porcentaje, int cambioPiel, int dias = 1)
        {
            double alimentoTotal = 0;

            // Lo divido por 7 porque es semanal el enunciado
            double cantidadAlimentoDiario = (peso * porcentaje) / 7;

            int contador = 1;

            for (int i = 1; i <= dias; i++)
            {
                alimentoTotal += cantidadAlimentoDiario;

                if (contador == cambioPiel)
                {
                    i += DiasSinAlimentacionCambioDePiel;
                    contador = 1;
                    continue;
                }

                contador++;
            }

            return await Task.FromResult(alimentoTotal);
        }

        public async Task<double> CalcularAlimentoMensual(List<Animal> reptiles)
        {
            double alimentoTotal = 0;
            int monthDays = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month);

            reptiles.ForEach(async (c) =>
            {
                alimentoTotal += await CalcularAlimento(c.Peso, c.Porcentaje, c.CambioPiel, monthDays);
            });

            return await Task.FromResult(alimentoTotal);
        }
    }
}