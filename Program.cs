using System;
using System.Threading;

namespace TikTakToe
{
    class MainClass
    {
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int joueur = 1; // Par défaut, le joueur 1 est sélectionné
        static int choix; // Ceci contient la position choisie où l'utilisateur veut marquer
        static void Main()
        {
            int flag = 0; // La variable drapeau vérifie qui a gagné : si sa valeur est 1, quelqu'un a gagné le match, si -1, le match est nul, si 0, le match est toujours en cours

            do
            {
                Console.Clear(); // À chaque redémarrage de la boucle, l'écran est effacé
                Console.WriteLine("Joueur 1 : X et Joueur 2 : O");
                Console.WriteLine("\n");
                if (joueur % 2 == 0) // Vérification du tour du joueur
                {
                    Console.WriteLine("Joueur 2");
                }
                else
                {
                    Console.WriteLine("Joueur 1");
                }
                Console.WriteLine("\n");
                AfficherGrille(); // Appel de la fonction AfficherGrille
                choix = int.Parse(Console.ReadLine()); // Saisie du choix de l'utilisateur

                if (arr[choix] != 'X' && arr[choix] != 'O')
                {
                    if (joueur % 2 == 0) // Si c'est le tour du joueur 2, marquer O sinon marquer X
                    {
                        arr[choix] = 'O';
                        joueur++;
                    }
                    else
                    {
                        arr[choix] = 'X';
                        joueur++;
                    }
                }
                else
                {
                    Console.WriteLine("Désolé, la case {0} est déjà marquée avec {1}", choix, arr[choix]);
                    Console.WriteLine("\n");
                    Console.WriteLine("Veuillez patienter 2 secondes, la grille se recharge...");
                    Thread.Sleep(2000);
                }
                flag = VerifierVictoire(); // Appel de la fonction VerifierVictoire
            }
            while (flag != 1 && flag != -1);

            Console.Clear(); // Effacer la console
            AfficherGrille(); // Afficher à nouveau la grille remplie
            LeGagnantEst(joueur, flag);
            Console.ReadLine();
        }

        private static void LeGagnantEst(int joueur, int flag)
        {
            if (flag == 1) // Si la valeur du drapeau est 1, quelqu'un a gagné
            {
                Console.WriteLine("Le joueur {0} a gagné", (joueur % 2) + 1);
            }
            else // Si la valeur du drapeau est -1, le match est nul
            {
                Console.WriteLine("Match nul");
            }
        }

        private static void AfficherGrille()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[1], arr[2], arr[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[4], arr[5], arr[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[7], arr[8], arr[9]);
            Console.WriteLine("     |     |      ");
        }

        private static int VerifierVictoire()
        {
            if (arr[1] == arr[2] && arr[2] == arr[3]) // Condition de victoire pour la première ligne
            {
                return 1;
            }
            else if (arr[4] == arr[5] && arr[5] == arr[6]) // Condition de victoire pour la deuxième ligne
            {
                return 1;
            }
            else if (arr[6] == arr[7] && arr[7] == arr[8]) // Condition de victoire pour la troisième ligne
            {
                return 1;
            }
            else if (arr[1] == arr[4] && arr[4] == arr[7]) // Condition de victoire pour la première colonne
            {
                return 1;
            }
            else if (arr[2] == arr[5] && arr[5] == arr[8]) // Condition de victoire pour la deuxième colonne
            {
                return 1;
            }
            else if (arr[3] == arr[6] && arr[6] == arr[9]) // Condition de victoire pour la troisième colonne
            {
                return 1;
            }
            else if (arr[1] == arr[5] && arr[5] == arr[9]) // Condition de victoire pour la diagonale principale
            {
                return 1;
            }
            else if (arr[3] == arr[5] && arr[5] == arr[7]) // Condition de victoire pour la diagonale secondaire
            {
                return 1;
            }
            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9') // Si toutes les cellules sont remplies
            {
                return -1; // Match nul
            }
            else
            {
                return 0; // Le match est en cours
            }
        }
    }
}
