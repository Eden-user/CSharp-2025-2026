namespace TPMiniJeu;

public class Program
{
    static void Main(String[] args)
    {
        Joueur joueur = new();
        Random rnd = new();
        int count1 = 0;
        int count2 = 0;
        while (joueur.EstVivant())
        {
            int random = rnd.Next(0, 2);
            if (random == 1)
            {
                MonstreNiveau1 monstre = new();
                //Console.WriteLine("Un monstre niveau 1 apparaît.");
                joueur.Attaquer(monstre);
                while (!monstre.RecoitDegat())
                {
                    joueur.Attaquer(monstre);
                    monstre.Attaquer(joueur);
                }
                count1 += 1;
            }
            else
            {
                MonstreNiveau2 monstre = new();
                //Console.WriteLine("Un monstre niveau 2 apparaît.");
                joueur.Attaquer(monstre);
                while (!monstre.RecoitDegat())
                {
                    joueur.Attaquer(monstre);
                    monstre.Attaquer(joueur);
                }
                count2 += 1;
            }
        }
        Console.WriteLine();
        Console.WriteLine("-------------------------------------");
        Console.WriteLine();
        Console.WriteLine("Vous êtes mort...");
        Console.WriteLine("Bravo, vous avez tué " + count1 + " monstres de niveau 1 et " + count2 + " monstres de niveau 2.");
        Console.WriteLine("Vous avez gagné " + (count1 + (count2 * 2)) + " points.");
    }
}