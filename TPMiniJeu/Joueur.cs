using System;

namespace TPMiniJeu;

public class Joueur
{
    private int _PV = 100;

    public string? Name { get; set; }

    public int PV
    {
        get
        {
            return _PV;
        }
    }

    public bool EstVivant()
    {
        if (_PV <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    static int JeterDe()
    {
        De De = new();
        return De.JeterDe();
    }
    public void Attaquer(MonstreNiveau1 monstre)
    {
        int lancerM = JeterDe();
        int lancerJ = JeterDe();
        if (lancerJ >= lancerM)
        {
            monstre.EstVivant = false;
        }
    }

    public void RecoitDegat(int degats)
    {
        if (JeterDe() >= 2)
        {
            _PV -= degats;
        }
        else
        {
            Console.WriteLine("Le bouclier s'est déclenché, le joueur ne prend pas de dégats.");
        }
    }
}
