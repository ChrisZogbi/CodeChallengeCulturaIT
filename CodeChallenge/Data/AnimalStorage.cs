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

        public Task AgregarAnimal(Animal animal)
        {
            Animales.Add(animal);

            return Task.CompletedTask;
        }

        public Task<List<Animal>> ObtenerAnimales()
        {
            return Task.FromResult(Animales);
        }

        public Task AgregarAnimales(List<Animal> animales)
        {
            Animales.AddRange(animales);

            return Task.CompletedTask;
        }
    }
}
