namespace Affichage.Models
{
    public abstract class Item
    {
        public string Nom { get; set; } = string.Empty;
        public Rarete NiveauRarete { get; set; }
    }
}