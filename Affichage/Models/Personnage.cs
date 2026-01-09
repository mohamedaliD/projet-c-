using System.Collections.Generic;

namespace Affichage.Models
{
    public class Personnage
    {
        public string Nom { get; set; } = string.Empty;
        public Race? RaceChoisie { get; set; }
        public Classe? ClasseChoisie { get; set; }
        
        public int StatForce { get; set; }
        public int StatDexterite { get; set; }
        public int StatIntelligence { get; set; }

        public void AppliquerBonusRaciaux()
        {
            if (RaceChoisie != null)
            {
                StatForce += RaceChoisie.BonusForce;
                StatDexterite += RaceChoisie.BonusDexterite;
                StatIntelligence += RaceChoisie.BonusIntelligence;
            }
        }
    }
}