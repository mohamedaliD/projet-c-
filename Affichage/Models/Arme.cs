namespace Affichage.Models
{
    public class Arme : Item
    {
        public int ValeurDegats { get; set; }

        public Arme(string nom, Rarete rarete, int degats)
        {
            Nom = nom;
            
            NiveauRarete = rarete;
            ValeurDegats = degats;
        }
    }
}