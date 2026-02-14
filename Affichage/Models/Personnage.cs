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

        // Nouvelles propriétés pour l'inventaire et l'image
        public List<Item> Inventaire { get; set; } = new();
        public string CheminImageAvatar { get; set; } = string.Empty;

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