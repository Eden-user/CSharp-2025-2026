using System;

namespace TPMiniJeu;

public class De
{
    Random rnd = new();
    public int JeterDe()
    {
        return rnd.Next(1, 7);
    }
}
