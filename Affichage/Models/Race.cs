using System.Collections.Generic;

namespace Affichage.Models
{
    public class Race
    {
        public string Nom { get; set; }
        public int BonusForce { get; set; }
        public int BonusDexterite { get; set; }
        public int BonusIntelligence { get; set; }
        public List<Classe> ClassesInterdites { get; set; }

        public Race(string nom, int bForce, int bDex, int bInt, Classe classeNonAutorisee)
        {
            Nom = nom;
            BonusForce = bForce;
            BonusDexterite = bDex;
            BonusIntelligence = bInt;
            ClassesInterdites = new List<Classe> { classeNonAutorisee };
        }

        public override string ToString() => Nom;
    }
}