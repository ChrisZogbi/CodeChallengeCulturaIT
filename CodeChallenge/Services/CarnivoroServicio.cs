using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeChallenge.Data.Model;
using CodeChallenge.Services.Interfaces;
using CodeChallenge.Services.Model;

namespace CodeChallenge.Services
{
    public class CarnivoroServicio : ICarnivoroServicio
    {
        public async Task<double> CalcularAlimento(double peso, double porcentaje, int dias = 1)
        {
            return await Task.FromResult((peso * porcentaje) * dias);
        }

        public async Task<double> CalcularAlimentoMensual(List<Animal> carnivoros)
        {
            double alimentoTotal = 0;
            int monthDays = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month);

            carnivoros.ForEach(async (c) =>
            {
                alimentoTotal += await CalcularAlimento(c.Peso, c.Porcentaje, monthDays);
            });

            return await Task.FromResult(alimentoTotal);
        }
    }
}
