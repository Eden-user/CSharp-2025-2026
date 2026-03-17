using System;

namespace TPMiniJeu;

public class MonstreNiveau2 : MonstreNiveau1
{
    private int _degatsGeneresSort;
    public int DegatsGeneresSort
    {
        get
        {
            return _degatsGeneresSort;
        }
        set
        {
            _degatsGeneresSort = value;
        }
    }

    public override void Attaquer(Joueur joueur)
    {
        int lancerM = JeterDe();
        int lancerJ = JeterDe();
        if (lancerM > lancerJ)
        {
            int degats = JeterDe();
            joueur.RecoitDegat(degats);
            Console.WriteLine("Dégats monstre niveau 2 : " + degats);
            Console.WriteLine("PV joueur = " + joueur.PV);
            int jetSort = JeterDe();
            if (jetSort < 6)
            {
                joueur.RecoitDegat(jetSort * 5);
                Console.WriteLine("Dégats sort monstre niveau 2 : " + jetSort * 5);
                Console.WriteLine("PV joueur = " + joueur.PV);
            }
        }
    }

}
