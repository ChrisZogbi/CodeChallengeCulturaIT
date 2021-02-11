namespace CodeChallenge.Data.Model
{
    public class Animal
    {
        public string Tipo { get; set; }
        public string Especie { get; set; }
        public int Edad { get; set; }
        public string LugarOrigen { get; set; }
        public double Peso { get; set; }
        public double Porcentaje { get; set; }
        public double Kilos { get; set; }

        public double CalcularAlimento()
        {
            var total = 0D;
            if (Tipo == "Carnivoro")
            {
                total = total + 2 * (Peso + Kilos);
            }
            else if (Tipo == "Herbiboro")
            {
                total = total + Peso * Porcentaje;
            }
            return total;
        }

    }
}