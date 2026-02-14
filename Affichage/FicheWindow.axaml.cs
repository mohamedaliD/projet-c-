using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Avalonia.Platform.Storage;
using System;
using System.IO;
using Affichage.Models;

namespace Affichage
{
    public partial class FicheWindow : Window
    {
        private Personnage _personnage;

        public FicheWindow() { InitializeComponent(); }

        public FicheWindow(Personnage perso)
        {
            InitializeComponent();
            _personnage = perso;

            TxtNom.Text = perso.Nom;
            TxtRaceClasse.Text = $"{perso.RaceChoisie?.Nom} - {perso.ClasseChoisie?.Nom}";
            TxtForce.Text = perso.StatForce.ToString();
            TxtDex.Text = perso.StatDexterite.ToString();
            TxtInt.Text = perso.StatIntelligence.ToString();

            InventaireList.ItemsSource = perso.Inventaire;
        }

        private async void OnImporterImageClick(object sender, RoutedEventArgs e)
        {
            var topLevel = TopLevel.GetTopLevel(this);
            var files = await topLevel!.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
            {
                Title = "Choisir un avatar",
                AllowMultiple = false,
                FileTypeFilter = new[] { FilePickerFileTypes.ImageAll }
            });

            if (files.Count >= 1)
            {
                await using var stream = await files[0].OpenReadAsync();
                var bitmap = new Bitmap(stream);
                AvatarImage.Source = bitmap;
            }
        }

        private async void OnExporterFicheClick(object sender, RoutedEventArgs e)
        {
            var topLevel = TopLevel.GetTopLevel(this);
            var file = await topLevel!.StorageProvider.SaveFilePickerAsync(new FilePickerSaveOptions
            {
                Title = "Sauvegarder la fiche",
                DefaultExtension = "png",
                SuggestedFileName = $"Fiche_{_personnage.Nom}.png",
                FileTypeChoices = new[] { FilePickerFileTypes.ImagePng }
            });

            if (file != null)
            {
                var rtb = new RenderTargetBitmap(new PixelSize((int)ZoneAExporter.Bounds.Width, (int)ZoneAExporter.Bounds.Height), new Vector(96, 96));
                rtb.Render(ZoneAExporter);

                await using var stream = await file.OpenWriteAsync();
                rtb.Save(stream);
            }
        }
    }
}