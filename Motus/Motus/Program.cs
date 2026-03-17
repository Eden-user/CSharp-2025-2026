using System.IO;
class Program()
{
    static void AfficherCouleur(String text, ConsoleColor couleur)
    {
        switch (couleur)
        {
            case ConsoleColor.Red:
                // code pour le rouge
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(text);
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case ConsoleColor.Yellow:
                // code pour le jaune
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(text);
                Console.ForegroundColor = ConsoleColor.White;
                break;
        }
    }
    static String GetMot(int lenMot)
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Saisissez un mot de " + lenMot + " caractères : ");
            String input = Console.ReadLine()!;
            if (input != null)
            {
                if (input.Length.Equals(lenMot))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Vous devez saisir un mot de " + lenMot + " caractères.");
                }
            }
            else
            {
                continue;
            }
        }
    }

    static int GetNombreAleatoire(int min, int max)
    {
        Random rand = new Random();
        int randnb = rand.Next(min, max);
        return randnb;
    }

    static List<String> ChargerMots(String fileName)
    {
        String Line;
        List<String> words = new List<string>();
        try
        {
            //Alternative = class File, File.method ReadAllLines(path)
            //Pass the file path and file name to the StreamReader constructor
            StreamReader sr = new StreamReader(fileName);
            //Read the first line of text
            Line = sr.ReadLine()!;
            //Continue to read until you reach end of file
            while (Line != null)
            {
                if (Line.Length.Equals(6) || Line.Length.Equals(7) || Line.Length.Equals(8))
                {
                    words.Add(Line);
                }
                //Read the next line
                Line = sr.ReadLine()!;
            }
            //close the file
            sr.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        return words;
    }

    static String ChoisirMot(List<String> mots)
    {
        return mots[GetNombreAleatoire(0, mots.Count())];
    }

    static bool TestMot(String motCache, String motSaisi)
    {
        if (motCache.Equals(motSaisi))
        {
            Console.WriteLine("Bien joué ! Le mot était bien " + motCache + " !");
            return true;
        }
        else
        {
            for (int i = 0; i < motSaisi.Length; i++)
            {
                if (motCache.Contains(motSaisi[i]))
                {
                    if (motCache[i].Equals(motSaisi[i]))
                    {
                        AfficherCouleur(motSaisi[i].ToString(), ConsoleColor.Red);
                    }
                    else
                    {
                        AfficherCouleur(motSaisi[i].ToString(), ConsoleColor.Yellow);
                    }
                }
                else
                {
                    Console.Write(motSaisi[i]);
                }
            }
            return false;
        }
    }
    static void Main(string[] args)
    {
        List<String> mots = ChargerMots("./mots.txt");
        bool keepGoing = true;
        while (keepGoing)
        {
            // String motChoisi = ChoisirMot(mots);
            String motChoisi = "solide";
            Console.WriteLine();
            Console.WriteLine("Le mot secret commence par la lettre " + motChoisi[0] + ".");
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine();
                Console.WriteLine("Il vous reste " + (6 - i) + " tentatives.");
                if (TestMot(motChoisi, GetMot(motChoisi.Length)))
                {
                    break;
                }
                else
                {
                    if (i.Equals(5))
                    {
                        Console.WriteLine();
                        Console.WriteLine("Perdu ! Le mot secret était " + motChoisi + " :p");
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            Console.WriteLine("Voulez-vous jouer à nouveau ? O/n (default 0)");
            String answer = Console.ReadLine()!;
            if (answer.Equals("n"))
            {
                break;
            }
            else
            {
                continue;
            }
        }
    }
}