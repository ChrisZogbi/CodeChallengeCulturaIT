using CodeChallenge.Data.Model;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallengeTest
{
    public class Tests
    {
        private List<Animal> _animales;

        [SetUp]
        public void Setup()
        {
            _animales = new List<Animal>();
        }

        [Test]
        public void CalcularAlimentoSinAnimales()
        {
            var result = _animales.Sum(a => a.CalcularAlimento());
            Assert.AreEqual(result, 0);
        }

        [Test]
        public void CalcularAlimentoSoloCarnivoros()
        {
            _animales.AddRange(MockFactoryCarnivoros());
            var result = _animales.Sum(a => a.CalcularAlimento());
            Assert.AreEqual(result, 22.5);
        }

        [Test]
        public void CalcularAlimentoSoloHerviboros()
        {
            _animales.AddRange(MockFactoryHerivboros());
            var result = _animales.Sum(a => a.CalcularAlimento());
            Assert.AreEqual(result, 185);
        }

        [Test]
        public void CalcularAlimentoTodos()
        {
            _animales.AddRange(MockFactoryTodos());
            var result = _animales.Sum(a => a.CalcularAlimento());
            Assert.AreEqual(result, 207.5);
        }

        #region Mock Factory
        private List<Animal> MockFactoryCarnivoros()
        {
            return new List<Animal>() {
                new Animal{
                    Tipo = "Carnívoro",
                    Peso = 100,
                    Porcentaje = 0.05
                },
                new Animal{
                    Tipo = "Carnívoro",
                    Peso = 80,
                    Porcentaje = 0.1
                },
                new Animal{
                    Tipo = "Carnívoro",
                    Peso = 95,
                    Porcentaje = 0.1
                }
            };
        }

        private List<Animal> MockFactoryHerivboros()
        {
            return new List<Animal>() {
                new Animal{
                    Tipo = "Hervíboro",
                    Peso = 30,
                    Kilos = 10
                },
                new Animal{
                    Tipo = "Hervíboro",
                    Peso = 50,
                    Kilos = 15
                }
            };
        }

        private List<Animal> MockFactoryTodos()
        {
            return new List<Animal>() {
                new Animal{
                    Tipo = "Carnívoro",
                    Peso = 100,
                    Porcentaje = 0.05
                },
                new Animal{
                    Tipo = "Carnívoro",
                    Peso = 80,
                    Porcentaje = 0.1
                },
                new Animal{
                    Tipo = "Carnívoro",
                    Peso = 95,
                    Porcentaje = 0.1
                },
                new Animal{
                    Tipo = "Hervíboro",
                    Peso = 30,
                    Kilos = 10
                },
                new Animal{
                    Tipo = "Hervíboro",
                    Peso = 50,
                    Kilos = 15
                }
            };
        }
        #endregion
    }
}