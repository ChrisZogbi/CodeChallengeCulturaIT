using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeChallenge.Data.Model;
using CodeChallenge.Services.Interfaces;
using CodeChallenge.Services.Model;

namespace CodeChallenge.Services
{
    public class HerbiboroServicio : IHerbiboroServicio
    {
        public async Task<double> CalcularAlimento(double peso, double kilos, int dias = 1)
        {
            return await Task.FromResult(((2 * peso) + kilos) * dias);
        }

        public async Task<double> CalcularAlimentoMensual(List<Animal> herbiboros)
        {
            double alimentoTotal = 0;
            int monthDays = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month);

            herbiboros.ForEach(async (c) =>
            {
                alimentoTotal += await CalcularAlimento(c.Peso, c.Kilos, monthDays);
            });

            return await Task.FromResult(alimentoTotal);
        }
    }
}
