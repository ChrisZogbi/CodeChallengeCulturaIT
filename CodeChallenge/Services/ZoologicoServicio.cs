using CodeChallenge.Data;
using CodeChallenge.Data.Model;
using CodeChallenge.Services.Interfaces;
using CodeChallenge.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallenge.Services
{
    public class ZoologicoServicio : IZoologicoServicio
    {
        private List<Animal> _animales;
        private readonly ICarnivoroServicio _carnivoroServicio;
        private readonly IHerbiboroServicio _herbiboroServicio;
        private readonly IReptilServicio _reptilServicio;

        public ZoologicoServicio(ICarnivoroServicio carnivoroServicio, IHerbiboroServicio herbiboroServicio, IReptilServicio reptilServicio)
        {
            _animales = new List<Animal>();
            _carnivoroServicio = carnivoroServicio;
            _herbiboroServicio = herbiboroServicio;
            _reptilServicio = reptilServicio;
        }
        public List<TipoAnimal> TiposAnimales => new List<TipoAnimal>() { TipoAnimal.Carnivoro, TipoAnimal.Herbiboro, TipoAnimal.Reptil };

        public async Task AgregarAnimal(AnimalModel animalModel)
        {
            _animales.Add(animalModel.Animal);

            await Task.CompletedTask;
        }

        private async Task<double> CalcularAlimentoPorTipo(Animal animal, int dias)
        {
            switch ((TipoAnimal)animal.Tipo)
            {
                case TipoAnimal.Carnivoro:
                    return await _carnivoroServicio.CalcularAlimento(animal.Peso, animal.Porcentaje, dias);

                case TipoAnimal.Herbiboro:
                    return await _herbiboroServicio.CalcularAlimento(animal.Peso, animal.Kilos, dias);

                case TipoAnimal.Reptil:
                    return await _reptilServicio.CalcularAlimento(animal.Peso, animal.Porcentaje, animal.CambioPiel, dias);

                default:
                    return 0D;
            }
        }

        public async Task<Dictionary<int, string>> ObtenerTipoAnimales()
        {
            Dictionary<int, string> tipoAnimales = new Dictionary<int, string>();

            TiposAnimales.ForEach(ta => tipoAnimales.Add((int)ta, ta.ToString()));

            return await Task.FromResult(tipoAnimales);
        }

        public async Task<List<AnimalModel>> ObtenerTodos()
        {
            List<AnimalModel> lAnimalModel = new List<AnimalModel>();

            _animales.ForEach(async (a) => lAnimalModel.Add(
                new AnimalModel
                {
                    Tipo = (TipoAnimal)a.Tipo,
                    Animal = a,
                    ConsumoCorriente = await CalcularConsumoDelCorriente(a)
                }));

            return await Task.FromResult(lAnimalModel);
        }

        public async Task<double> ProyectarConsumoTotalDelCorriente()
        {
            double consumoTotal = 0D;

            DateTime today = DateTime.Today;

            int diasMes = DateTime.DaysInMonth(today.Year, today.Month);

            _animales.ForEach(async (a) => consumoTotal += await CalcularAlimentoPorTipo(a, diasMes));

            return await Task.FromResult(consumoTotal);
        }

        private async Task<double> CalcularConsumoDelCorriente(Animal animal)
        {
            int diaMes = DateTime.Today.Day;

            double consumoCorriente = await CalcularAlimentoPorTipo(animal, diaMes);

            return await Task.FromResult(consumoCorriente);
        }

        public async Task<Dictionary<string, string>> ObtenerConsumoMensualPorTipoAlimento()
        {
            Dictionary<string, string> CantidadPorAlimento = new Dictionary<string, string>();

            var carnivoros = _animales.Where(a => (TipoAnimal)a.Tipo == TipoAnimal.Carnivoro).ToList();
            var herbiboros = _animales.Where(a => (TipoAnimal)a.Tipo == TipoAnimal.Herbiboro).ToList();
            var reptiles = _animales.Where(a => (TipoAnimal)a.Tipo == TipoAnimal.Reptil).ToList();

            //Lo divido por 2 ya que supuse que el enunciado decia que el el mismo porcentaje para el total de hierba y carne.
            // En caso de ser el mismo porcentaje para cada tipo (carne hierba) en ese caso se multiplica el valor.
            double cantidadCarneReptiles = await _reptilServicio.CalcularAlimentoMensual(reptiles) / 2;
            double cantidadHierbaReptiles = await _reptilServicio.CalcularAlimentoMensual(reptiles) / 2;

            double cantidadCarneCarnivoros = await _carnivoroServicio.CalcularAlimentoMensual(carnivoros);
            double cantidadHierbaHerbiboros = await _herbiboroServicio.CalcularAlimentoMensual(herbiboros);

            CantidadPorAlimento.Add(TipoAlimento.Carne.ToString(), (cantidadCarneCarnivoros + cantidadCarneReptiles).ToString());
            CantidadPorAlimento.Add(TipoAlimento.Hierba.ToString(), (cantidadHierbaHerbiboros + cantidadHierbaReptiles).ToString());

            return await Task.FromResult(CantidadPorAlimento);
        }
    }
}
