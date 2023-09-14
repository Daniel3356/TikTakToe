using System;
using System.Text;

public class Staircase
{
    public static string CreateStaircase(int height, int width)
    {
        StringBuilder staircase = new StringBuilder();

        for (int i = 1; i <= height; i++)
        {
            // Construire chaque marche en ajoutant des "#" à la ligne actuelle
            for (int j = 0; j < width; j++)
            {
                staircase.Append("#");
            }

            // Ajouter un retour à la ligne après chaque marche
            staircase.AppendLine();
            // Ajouter une deuxième ligne identique
            staircase.AppendLine();

            // Doublez la largeur pour la prochaine marche
            width *= 2;
        }

        return staircase.ToString();
    }

    public static void Main(string[] args)
    {
        // Test unitaire
        string result = CreateStaircase(4, 2);
        Console.WriteLine(result);
    }
}
