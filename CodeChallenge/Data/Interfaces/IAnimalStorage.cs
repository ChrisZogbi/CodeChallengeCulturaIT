using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeChallenge.Data.Model;

namespace CodeChallenge.Data.Interfaces
{
    public interface IAnimalStorage
    {
        Task AgregarAnimal(Animal animal);

        Task<List<Animal>> ObtenerAnimales();

        Task AgregarAnimales(List<Animal> animales);
    }
}
