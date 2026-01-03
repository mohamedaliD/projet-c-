namespace Affichage.Models
{
    public class Classe
    {
        public string Nom { get; set; } = "";

        public Classe(string nom)
        {
            Nom = nom;
        }

        public override string ToString()
        {
            return Nom;
        }
    }
}