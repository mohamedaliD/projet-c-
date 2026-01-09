namespace Affichage.Models
{
    public abstract class Item
    {
        public string Nom { get; set; } = string.Empty; // Initialisation par défaut
        public Rarete NiveauRarete { get; set; }
    }
}