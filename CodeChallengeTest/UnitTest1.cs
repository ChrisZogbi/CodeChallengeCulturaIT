using CodeChallenge.Data.Model;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using CodeChallenge.Data;
using CodeChallenge.Services;

namespace CodeChallengeTest
{
    public class Tests
    {
        private ReptilServicio reptilServicio;
        private CarnivoroServicio carnivoroServicio;
        private HerbivoroServicio herbivoroServicio;
        private ZoologicoServicio zoologicoServicio;
        private AnimalStorage animalStorage;


        public Tests()
        {
        }

        [SetUp]
        public void Setup()
        {
            reptilServicio = new ReptilServicio();
            carnivoroServicio = new CarnivoroServicio();
            herbivoroServicio = new HerbivoroServicio();
            animalStorage = new AnimalStorage();
            zoologicoServicio = new ZoologicoServicio(carnivoroServicio, herbivoroServicio, reptilServicio);

        }

        [Test]
        public void CalcularAlimentoCarnivoroDiario()
        {
            var carnivoro = new Animal
            {
                Peso = 200,
                Porcentaje = 0.25
            };
            var result = carnivoroServicio.CalcularAlimento(carnivoro.Peso, carnivoro.Porcentaje);
            Assert.AreEqual(result.Result, 50);
        }

        [Test]
        public void CalcularAlimentoCarnivoroXDias()
        {
            var carnivoro = new Animal
            {
                Peso = 500,
                Porcentaje = 0.1
            };

            int cantidadDias = 15;

            var result = carnivoroServicio.CalcularAlimento(carnivoro.Peso, carnivoro.Porcentaje, cantidadDias);
            Assert.AreEqual(result.Result, 750);
        }

        [Test]
        public void CalcularAlimentoCarnivorosMensual()
        {
            var result = carnivoroServicio.CalcularAlimentoMensual(MockFactoryCarnivoros());
            Assert.AreEqual(result.Result, 21840);
        }

        [Test]
        public void CalcularAlimentoHerbiboroDiario()
        {
            var herbiboro = new Animal
            {
                Peso = 30,
                Kilos = 10
            };
            var result = herbivoroServicio.CalcularAlimento(herbiboro.Peso, herbiboro.Kilos);
            Assert.AreEqual(result.Result, 70);
        }

        [Test]
        public void CalcularAlimentoHerbiboroXDias()
        {
            var herbiboro = new Animal
            {
                Peso = 1000,
                Kilos = 400
            };

            int cantidadDias = 10; //Se puede cambiar el numero. El resultado se debe ajustar

            var result = herbivoroServicio.CalcularAlimento(herbiboro.Peso, herbiboro.Kilos, cantidadDias);
            Assert.AreEqual(result.Result, 24000);
        }

        [Test]
        public void CalcularAlimentoHerbiborosMensual()
        {
            var result = herbivoroServicio.CalcularAlimentoMensual(MockFactoryHerivboros());
            Assert.AreEqual(result.Result, 5180);
        }

        [Test]
        public void CalcularAlimentoReptilDiario()
        {
            var reptil = MockFactoryReptiles().First();

            var result = reptilServicio.CalcularAlimento(reptil.Peso, reptil.Porcentaje, reptil.CambioPiel);
            Assert.AreEqual(result.Result, 10);
        }

        [Test]
        public void CalcularAlimentoReptilXDias()
        {
            var reptil = MockFactoryReptiles().Last();

            int cantidadDias = 18; //Se puede cambiar el numero. El resultado se debe ajustar

            var result = reptilServicio.CalcularAlimento(reptil.Peso, reptil.Porcentaje, reptil.CambioPiel, cantidadDias);
            Assert.AreEqual(result.Result, 90);
        }

        [Test]
        public void CalcularAlimentoReptilMensual()
        {
            var result = reptilServicio.CalcularAlimentoMensual(MockFactoryReptiles());
            Assert.AreEqual(result.Result, 2540);
        }

        #region Mock Factory
        private List<Animal> MockFactoryReptiles()
        {
            return new List<Animal>() {
                new Animal{
                    Tipo = (int)TipoAnimal.Reptil,
                    Peso = 100,
                    Porcentaje = 0.7,
                    CambioPiel = 5
                },
                new Animal{
                    Tipo = (int)TipoAnimal.Reptil,
                    Peso = 1400,
                    Porcentaje = 0.5,
                    CambioPiel = 9
                },
                new Animal{
                    Tipo = (int)TipoAnimal.Reptil,
                    Peso = 280,
                    Porcentaje = 0.25,
                    CambioPiel = 3
                }
            };
        }

        private List<Animal> MockFactoryHerivboros()
        {
            return new List<Animal>() {
                new Animal{
                    Tipo = (int)TipoAnimal.Herbivoro,
                    Peso = 30,
                    Kilos = 10
                },
                new Animal{
                    Tipo = (int)TipoAnimal.Herbivoro,
                    Peso = 50,
                    Kilos = 15
                }

            };
        }

        private List<Animal> MockFactoryCarnivoros()
        {
            return new List<Animal>() {
                new Animal{
                    Tipo = (int)TipoAnimal.Carnivoro,
                    Peso = 100,
                    Porcentaje = 0.3
                },
                new Animal{
                    Tipo = (int)TipoAnimal.Herbivoro,
                    Peso = 1500,
                    Porcentaje = 0.5
                }

            };
        }

        private List<Animal> MockFactoryTodos()
        {
            return new List<Animal>() {
                new Animal{
                    Tipo = (int)TipoAnimal.Carnivoro,
                    Peso = 100,
                    Porcentaje = 0.05
                },//140
                new Animal{
                    Tipo = (int)TipoAnimal.Carnivoro,
                    Peso = 80,
                    Porcentaje = 0.1
                },//224
                new Animal{
                    Tipo = (int)TipoAnimal.Herbivoro,
                    Peso = 30,
                    Kilos = 10
                },//1960
                new Animal{
                    Tipo = (int)TipoAnimal.Herbivoro,
                    Peso = 50,
                    Kilos = 15
                },//3220
               new Animal
               {
                    Tipo = (int)TipoAnimal.Reptil,
                    Peso = 50,
                    Porcentaje = 0.7,
                    CambioPiel = 5
               } //95
            };
        }
        #endregion
    }
}