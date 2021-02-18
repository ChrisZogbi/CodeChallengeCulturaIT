using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeChallenge.Data.Model;

namespace CodeChallenge.Data
{
    public class AnimalStorage
    {
        private List<Animal> Animales { get; set; }

        public AnimalStorage()
        {
            Animales = new List<Animal>();
        }

        public async Task AgregarAnimal(Animal animal)
        {
            Animales.Add(animal);

            await Task.CompletedTask;
        }

        public async Task<List<Animal>> ObtenerAnimales()
        {
            return await Task.FromResult(Animales);
        }

        public async Task AgregarAnimales(List<Animal> animales)
        {
            Animales.AddRange(animales);

            await Task.CompletedTask;
        }
    }
}
