using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Affichage.Models;

namespace Affichage
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Personnage> MesPersos { get; set; } = new();
        private List<Race> _toutesLesRaces = new();
        private List<Classe> _toutesLesClasses = new();
        
        private int _pointsRestants = 0;
        private int _tempFor = 0, _tempDex = 0, _tempInt = 0;

        public MainWindow()
        {
            InitializeComponent();
            CharactersList.ItemsSource = MesPersos;
            InitialiserDonnees();
            ComboRace.ItemsSource = _toutesLesRaces;
        }

        private void InitialiserDonnees()
        {
            _toutesLesClasses = new List<Classe> {
                new Classe("Guerrier", Competence.Resistance),
                new Classe("Mage", Competence.Precision),
                new Classe("Voleur", Competence.Rapidite)
            };

            _toutesLesRaces = new List<Race> {
                new Race("Nain", 2, 0, 0, _toutesLesClasses[1]),
                new Race("Elfe", 0, 2, 1, _toutesLesClasses[0]),
                new Race("Humain", 1, 1, 1, _toutesLesClasses[2])
            };
        }

        private void OnLancerDeClick(object sender, RoutedEventArgs e)
        {
            _pointsRestants = new Random().Next(1, 11);
            _tempFor = 0; _tempDex = 0; _tempInt = 0;
            RafraichirStatsUI();
        }

        // --- GESTION DES POINTS (+) ---
        private void OnAddForce(object sender, RoutedEventArgs e) { if(_pointsRestants > 0) { _tempFor++; _pointsRestants--; RafraichirStatsUI(); } }
        private void OnAddDex(object sender, RoutedEventArgs e) { if(_pointsRestants > 0) { _tempDex++; _pointsRestants--; RafraichirStatsUI(); } }
        private void OnAddInt(object sender, RoutedEventArgs e) { if(_pointsRestants > 0) { _tempInt++; _pointsRestants--; RafraichirStatsUI(); } }

        // --- GESTION DES POINTS (-) ---
        private void OnRemoveForce(object sender, RoutedEventArgs e) { if(_tempFor > 0) { _tempFor--; _pointsRestants++; RafraichirStatsUI(); } }
        private void OnRemoveDex(object sender, RoutedEventArgs e) { if(_tempDex > 0) { _tempDex--; _pointsRestants++; RafraichirStatsUI(); } }
        private void OnRemoveInt(object sender, RoutedEventArgs e) { if(_tempInt > 0) { _tempInt--; _pointsRestants++; RafraichirStatsUI(); } }

        private void RafraichirStatsUI()
        {
            TxtPointsRestants.Text = _pointsRestants.ToString();
            TxtFor.Text = _tempFor.ToString();
            TxtDex.Text = _tempDex.ToString();
            TxtInt.Text = _tempInt.ToString();

            // Indicateur visuel : le bouton devient vert quand on peut valider (0 points restants)
            if (_pointsRestants == 0 && (_tempFor > 0 || _tempDex > 0 || _tempInt > 0))
                BtnValider.Background = Brushes.Green;
            else
                BtnValider.Background = new SolidColorBrush(Color.Parse("#800020"));
        }

        private void OnRaceSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboRace.SelectedItem is Race r) {
                ComboClasse.ItemsSource = _toutesLesClasses.Where(c => !r.ClassesInterdites.Any(i => i.Nom == c.Nom)).ToList();
                ComboClasse.IsEnabled = true;
                ComboClasse.SelectedIndex = 0;
            }
        }

        private void OnValiderCreationClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(InputNom.Text) || ComboRace.SelectedItem == null || _pointsRestants > 0) return;

            var p = new Personnage {
                Nom = InputNom.Text,
                RaceChoisie = ComboRace.SelectedItem as Race,
                ClasseChoisie = ComboClasse.SelectedItem as Classe,
                StatForce = _tempFor, StatDexterite = _tempDex, StatIntelligence = _tempInt
            };
            p.AppliquerBonusRaciaux();
            MesPersos.Add(p);
            ReinitialiserFormulaire();
        }

        private void OnOuvrirFormulaireClick(object sender, RoutedEventArgs e) { FormPanel.IsVisible = true; BtnOuvrirFormulaire.IsVisible = false; }
        private void OnAnnulerClick(object sender, RoutedEventArgs e) => ReinitialiserFormulaire();

        private void ReinitialiserFormulaire()
        {
            InputNom.Text = ""; _pointsRestants = 0; _tempFor = 0; _tempDex = 0; _tempInt = 0;
            RafraichirStatsUI();
            FormPanel.IsVisible = false; BtnOuvrirFormulaire.IsVisible = true;
            EmptyMessageTxt.IsVisible = MesPersos.Count == 0;
        }
    }
}