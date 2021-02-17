using System;
using System.Collections.Generic;
using CodeChallenge.Data;
using CodeChallenge.Data.Model;

namespace CodeChallenge.Services.Model
{
    public class AnimalModel
    {
        public Animal Animal { get; set; }
        public TipoAnimal Tipo { get; set; }
        public double ConsumoCorriente { get; set; }

        public AnimalModel()
        {
            Animal = new Animal();
        }
    }
}
