using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Affichage.Models; 

namespace Affichage
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Personnage> MesPersos { get; set; }
        
        private List<Race> _racesDisponibles;
        private Random _rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();
            MesPersos = new ObservableCollection<Personnage>();
            CharactersList.ItemsSource = MesPersos;

            InitializeGameData();

            ComboRace.ItemsSource = _racesDisponibles;
        }

        private void InitializeGameData()
        {
            Classe guerrier = new Classe("Guerrier");
            Classe mage = new Classe("Mage");
            Classe voleur = new Classe("Voleur");
            Classe paladin = new Classe("Paladin");
            Classe rodeur = new Classe("Rôdeur");
            Classe druide = new Classe("Druide");
            Classe forgeron = new Classe("Forgeron");
            Classe barbare = new Classe("Barbare");
            Classe chaman = new Classe("Chaman");

           
            Race humain = new Race("Humain", 1, 1, 1, 1);
            humain.ClassesAccessibles.AddRange(new[] { guerrier, mage, voleur, paladin });

            Race elfe = new Race("Elfe", 0, 1, 2, 0);
            elfe.ClassesAccessibles.AddRange(new[] { mage, rodeur, druide, voleur });

            Race nain = new Race("Nain", 1, 0, 0, 2);
            nain.ClassesAccessibles.AddRange(new[] { guerrier, paladin, forgeron }); // Pas de Mage !

            Race orc = new Race("Orc", 2, 0, 0, 1);
            orc.ClassesAccessibles.AddRange(new[] { guerrier, barbare, chaman });

            _racesDisponibles = new List<Race> { humain, elfe, nain, orc };
        }


        private void OnCreateClick(object sender, RoutedEventArgs e)
        {
            BtnCreate.IsVisible = false;
            FormPanel.IsVisible = true;
            InputName.Focus();
        }

        private void OnRaceChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboRace.SelectedItem is Race raceChoisie)
            {
                ComboClass.ItemsSource = raceChoisie.ClassesAccessibles;
                ComboClass.IsEnabled = true;
                ComboClass.SelectedIndex = 0;

                if (TxtForce.Text != "0") OnRollDiceClick(null, null);
            }
            else
            {
                ComboClass.ItemsSource = null;
                ComboClass.IsEnabled = false;
            }
        }

        private void OnRollDiceClick(object sender, RoutedEventArgs e)
        {
            int force = _rnd.Next(5, 19);
            int agi = _rnd.Next(5, 19);
            int intel = _rnd.Next(5, 19);
            int vig = _rnd.Next(5, 19);

            if (ComboRace.SelectedItem is Race race)
            {
                force += race.BonusForce;
                agi += race.BonusAgilite;
                intel += race.BonusIntel;
                vig += race.BonusVigueur;
            }

            // 3. Affichage
            TxtForce.Text = force.ToString();
            TxtAgilite.Text = agi.ToString();
            TxtIntel.Text = intel.ToString();
            TxtVigueur.Text = vig.ToString();
        }

        private void OnValidateClick(object sender, RoutedEventArgs e)
        {
            string nom = InputName.Text ?? "";
            Race? race = ComboRace.SelectedItem as Race;
            Classe? classe = ComboClass.SelectedItem as Classe;

            int.TryParse(TxtForce.Text, out int f);
            int.TryParse(TxtAgilite.Text, out int a);
            int.TryParse(TxtIntel.Text, out int i);
            int.TryParse(TxtVigueur.Text, out int v);

            if (string.IsNullOrWhiteSpace(nom) || race == null || classe == null) return;

            if (f == 0)
            {
                OnRollDiceClick(null, null);
                int.TryParse(TxtForce.Text, out f);
                int.TryParse(TxtAgilite.Text, out a);
                int.TryParse(TxtIntel.Text, out i);
                int.TryParse(TxtVigueur.Text, out v);
            }

            MesPersos.Add(new Personnage 
            { 
                Nom = nom, 
                RaceInfo = race, 
                ClasseInfo = classe,
                Force = f, Agilite = a, Intel = i, Vigueur = v
            });
            
            EmptyMessageTxt.IsVisible = false;
            ResetForm();
        }

        private void OnCancelClick(object sender, RoutedEventArgs e) => ResetForm();

        private void ResetForm()
        {
            InputName.Text = "";
            ComboRace.SelectedIndex = -1;
            ComboClass.SelectedIndex = -1;
            ComboClass.IsEnabled = false;
            TxtForce.Text = "0"; TxtAgilite.Text = "0"; TxtIntel.Text = "0"; TxtVigueur.Text = "0";
            FormPanel.IsVisible = false;
            BtnCreate.IsVisible = true;
        }
    }
}