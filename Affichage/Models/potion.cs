namespace Affichage.Models
{
    public class Potion : Item
    {
        public int PointsDeSoin { get; set; }
        public int PointsDeDegat { get; set; }
        public int DureeEffetSecondes { get; set; }

        public Potion(string nom, Rarete rarete, int soin, int degat, int duree)
        {
            Nom = nom;
            NiveauRarete = rarete;
            PointsDeSoin = soin;
            PointsDeDegat = degat;
            DureeEffetSecondes = duree;
        }
    }
}