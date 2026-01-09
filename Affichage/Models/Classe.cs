using System.Collections.Generic;

namespace Affichage.Models
{
    public class Classe
    {
        public string Nom { get; set; }
        public List<Competence> CompetencesInitiales { get; set; }

        public Classe(string nom, Competence competenceParDefaut)
        {
            Nom = nom;
            CompetencesInitiales = new List<Competence> { competenceParDefaut };
        }

        public override string ToString() => Nom;
    }
}