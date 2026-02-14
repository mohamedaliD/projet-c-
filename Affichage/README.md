# Générateur de Fiches de Personnages RPG 🎲

[cite_start]Une application de bureau développée en C# permettant de créer, gérer et exporter des fiches de personnages pour des jeux de rôle (RPG)[cite: 3]. [cite_start]Ce projet utilise le framework multiplateforme Avalonia UI et met fortement en pratique les concepts de la Programmation Orientée Objet (POO)[cite: 4, 20].

## 🌟 Fonctionnalités

* [cite_start]**Création de Personnage :** Choix du nom, de la race (Nain, Elfe, Humain) et de la classe (Guerrier, Mage, Voleur)[cite: 9].
* [cite_start]**Système de Règles Dynamiques :** * Certaines races n'ont pas accès à toutes les classes (ex: un Nain ne peut pas être Mage)[cite: 10].
  * [cite_start]Les races octroient des bonus de statistiques uniques[cite: 10, 13].
* [cite_start]**Génération des Attributs :** Un système de lancer de dés détermine le nombre de points à répartir manuellement entre la Force, la Dextérité et l'Intelligence[cite: 11, 12].
* [cite_start]**Inventaire de Départ :** Gestion d'un inventaire généré automatiquement selon la classe choisie, incluant des armes et des potions classées par rareté (Commun, Rare, Épique, Légendaire)[cite: 18].
* [cite_start]**Interface UI Dynamique :** Les menus et les boutons se mettent à jour en temps réel selon les actions de l'utilisateur[cite: 25].
* [cite_start]**Fiche Détaillée :** Une fois validé, le résultat final s'affiche dans une nouvelle fenêtre complète[cite: 28].

## ✨ Fonctionnalités Bonus

* [cite_start]**Importation d'Avatar :** Possibilité d'importer une image locale pour personnaliser la fiche de son héros[cite: 31].
* [cite_start]**Exportation Image :** Permet à l'utilisateur d'exporter sa fiche de personnage finalisée sous format d'image (.png) pour la sauvegarder ou la partager[cite: 30].

## 🛠️ Technologies Utilisées

* **Langage :** C# (.NET 9)
* [cite_start]**Interface Graphique :** Avalonia UI (XAML & Code-Behind) [cite: 4, 24]
* [cite_start]**Architecture :** Programmation Orientée Objet (Classes, Héritage, Polymorphisme) [cite: 20, 21]

## 🚀 Comment lancer le projet

Assurez-vous d'avoir le SDK .NET installé sur votre machine.

1. Clonez ce dépôt :
   ```bash
   git clone [https://github.com/mohamedaliD/projet-c-.git](https://github.com/mohamedaliD/projet-c-.git)
