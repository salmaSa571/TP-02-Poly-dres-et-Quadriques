# TP 02 - Polyèdres et Quadriques


## Description
Ce projet contient plusieurs scripts pour modéliser des polyèdres et quadriques dans Unity. Il comprend les exercices demandés dans le TP 02, tels que la création d'un plan, d'un cylindre, d'une sphère, un cône tronqué, et une option pour des objets tronqués.
## Table des matières

1. [Exercice 0 : Plan](#exercice-0--plan)
2. [Exercice I : Cylindre](#exercice-i--cylindre)
3. [Exercice II : Sphère](#exercice-ii--sphère)
4. [Exercice III (Optionnel) : Cône](#exercice-iii-optionnel--cône)
5. [Exercice IV (Optionnel) : Objets tronqués](#exercice-iv-optionnel--objets-tronqués)

## Exercice 0 : Plan
- **Description** : Modélisation de triangle.
- **Fichier** : `DrawTriangle.cs`
- **Description** : Modélisation d'un plan en utilisant deux triangles. Le script permet également de générer un plan plus complexe en décomposant le plan en un nombre de lignes et de colonnes.
- **Fichier** : `GenerateurDePlan.cs`

## Exercice I : Cylindre

- **Description** : Ce script modélise un cylindre avec des facettes triangulaires. Les paramètres incluent le rayon, la hauteur, et le nombre de méridiens. Le cylindre est fermé par des couvercles.
- **Fichier** : `Cylindre.cs`

## Exercice II : Sphère

- **Description** : Ce script modélise une sphère avec des parallèles et des méridiens. Les paramètres incluent le rayon, le nombre de parallèles, et le nombre de méridiens.
- **Fichier** : `GenerateurDeSphère.cs`

## Exercice III (Optionnel) : Cône

- **Description** : Modélisation d'un cône tronqué ou non avec des paramètres tels que le rayon et la hauteur.
- **Fichier** : `Cone.cs`

## Exercice IV (Optionnel) : Objets tronqués

- **Description** : Ce script reprend les objets des exercices précédents (sphère, cylindre, cône) et permet de les tronquer. Par exemple, la sphère peut être tronquée pour ressembler à un hémisphère. Cela peut inclure la fermeture des objets à leurs extrémités coupées.
- **Fichier** : `TruncatedSphere.cs`
## Étapes pour exécuter le projet Unity 
- **Ouvrir Unity**
- Lancer Unity et ouvrir le projet en sélectionnant le dossier du dépôt cloné.
- **Accéder à la scène principale**
- Une fois le projet ouvert, naviguez dans le dossier Assets/Scenes.
- Double-cliquez sur la scène principale pour l'ouvrir.
- **Vérifier les objets dans la Hiérarchie**
- Dans la fenêtre Hiérarchie d'Unity, vous trouverez les objets comme Plan, Cylindre, Sphère, etc.
- Vous pouvez configurer les paramètres de chaque objet si nécessaire.
- Chaque objet a un script attaché que vous pouvez consulter ou modifier.
- **Exécuter la scène**
- Appuyez sur le bouton Play en haut de l'éditeur Unity pour exécuter la scène.
- Vous devriez voir les objets comme le plan, cylindre, ou sphère apparaître dans la fenêtre de jeu en fonction des scripts attachés à ces objets.
