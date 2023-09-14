using System;
using System.Linq;

class Point
{
    public double X { get; set; }
    public double Y { get; set; }
}

class Cercle
{
    private double Rayon { get; set; }

    public Cercle(double rayon)
    {
        Rayon = rayon;
    }

    public bool IsIn(Point point)
    {
        double distanceAuCarre = Math.Pow(point.X, 2) + Math.Pow(point.Y, 2);
        return distanceAuCarre <= Math.Pow(Rayon, 2);
    }
}

class Square
{
    private double Cote { get; set; }

    public Square(double cote)
    {
        Cote = cote;
    }

    public double Area()
    {
        return Math.Pow(Cote, 2);
    }

    public Point RandomPoint(Random random)
    {
        double x = random.NextDouble() * Cote - (Cote / 2);
        double y = random.NextDouble() * Cote - (Cote / 2);
        return new Point { X = x, Y = y };
    }
}

class Program
{
    public static double PiEstimate(int n)
    {
        Random random = new Random();
        Square square = new Square(2); // Carré de côté 2 pour inscrire le cercle de rayon 1
        Cercle cercle = new Cercle(1);
        int pointsDansCercle = 0;

        for (int i = 0; i < n; i++)
        {
            Point point = square.RandomPoint(random);
            if (cercle.IsIn(point))
            {
                pointsDansCercle++;
            }
        }

        double proportion = (double)pointsDansCercle / n;
        return proportion * square.Area();
    }

    static void Main()
    {
        int n = 1000000; // Nombre de points à générer
        double piEstimation = PiEstimate(n);
        Console.WriteLine("Estimation de π avec {0} points : {1}", n, piEstimation);
        Console.WriteLine("Valeur usuelle de π : {0}", Math.PI);
    }
}
