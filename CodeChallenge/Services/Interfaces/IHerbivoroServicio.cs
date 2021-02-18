using System;
using System.Threading.Tasks;
using CodeChallenge.Services.Model;
using CodeChallenge.Data.Model;
using System.Collections.Generic;

namespace CodeChallenge.Services.Interfaces
{
    public interface IHerbivoroServicio
    {
        Task<double> CalcularAlimento(double peso, double kilos, int dias = 1);
        Task<double> CalcularAlimentoMensual(List<Animal> herbiboros);
    }
}
