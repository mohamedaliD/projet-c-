using System.Collections.Generic;

namespace Affichage.Models
{
    public class Race
    {
        public string Nom { get; set; } = "";
        
        public List<Classe> ClassesAccessibles { get; set; } = new List<Classe>();

        public int BonusForce { get; set; }
        public int BonusAgilite { get; set; }
        public int BonusIntel { get; set; }
        public int BonusVigueur { get; set; }

        public Race(string nom, int bForce, int bAgi, int bIntel, int bVig)
        {
            Nom = nom;
            BonusForce = bForce;
            BonusAgilite = bAgi;
            BonusIntel = bIntel;
            BonusVigueur = bVig;
        }

        public override string ToString()
        {
            return Nom;
        }
    }
}