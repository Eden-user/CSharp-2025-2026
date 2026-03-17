using System;

namespace TPMiniJeu;

public class MonstreNiveau1
{
    private int _degatsGeneres;
    private bool _estVivant = true;
    public int DegatsGeneres
    {
        get
        {
            return _degatsGeneres;
        }
        set
        {
            _degatsGeneres = value;
        }
    }
    public bool EstVivant
    {
        get
        {
            return _estVivant;
        }
        set
        {
            _estVivant = value;
        }
    }

    protected int JeterDe()
    {
        De De = new();
        return De.JeterDe();
    }
    public virtual void Attaquer(Joueur joueur)
    {
        int lancerM = JeterDe();
        int lancerJ = JeterDe();
        if (lancerM > lancerJ)
        {
            int degats = JeterDe();
            joueur.RecoitDegat(degats);
            Console.WriteLine("Dégats monstre niveau 1 : " + degats);
            Console.WriteLine("PV joueur = " + joueur.PV);
        }
    }

    public bool RecoitDegat()
    {
        if (_estVivant)
        {
            return false;
        }
        else
        {
            Console.WriteLine("Bien joué : le monstre a été vaincu.");
            return true;
        }
    }

}
