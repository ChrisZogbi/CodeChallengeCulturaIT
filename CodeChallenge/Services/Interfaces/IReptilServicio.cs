using System;
using System.Threading.Tasks;
using CodeChallenge.Services.Model;
using CodeChallenge.Data.Model;
using System.Collections.Generic;

namespace CodeChallenge.Services.Interfaces
{
    public interface IReptilServicio
    {
        Task<double> CalcularAlimento(double peso, double porcentaje, int cambioPiel, int dias = 1);
        Task<double> CalcularAlimentoMensual(List<Animal> reptiles);
    }
}
