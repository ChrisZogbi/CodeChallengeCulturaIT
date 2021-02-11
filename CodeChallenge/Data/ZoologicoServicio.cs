using CodeChallenge.Data.Model;
using System.Collections.Generic;

namespace CodeChallenge.Data
{
    public class ZoologicoServicio
    {
        public List<Animal> _animales;
        public ZoologicoServicio()
        {
            _animales = new List<Animal>();
        }
        public List<string> TiposAnimales => new List<string>() { "Carnívoro", "Hervíboro" };

        public void AgregarAnimal(Animal animal)
        {
            _animales.Add(animal);
        }
    }
}
