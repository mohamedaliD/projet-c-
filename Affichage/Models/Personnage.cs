namespace Affichage.Models
{
    public class Personnage
    {
        public string Nom { get; set; } = "";
        
        public Race? RaceInfo { get; set; } 
        public Classe? ClasseInfo { get; set; }

        public int Force { get; set; }
        public int Agilite { get; set; }
        public int Intel { get; set; }
        public int Vigueur { get; set; }
    }
}