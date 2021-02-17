using CodeChallenge.Data;
using CodeChallenge.Data.Model;
using CodeChallenge.Services.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeChallenge.Services.Interfaces
{
    public interface IZoologicoServicio
    {
        Task AgregarAnimal(AnimalModel animal);

        Task<Dictionary<int, string>> ObtenerTipoAnimales();

        Task<List<AnimalModel>> ObtenerTodos();

        Task<double> ProyectarConsumoTotalDelCorriente();

        Task<Dictionary<string, string>> ObtenerConsumoMensualPorTipoAlimento();
    }
}
        