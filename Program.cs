Værksted v = new Værksted();

v.OpretBil("AB12345");
v.OpretBil("BC12345");
v.OpretBil("CD12345");
v.OpretBil("DE12345");
v.OpretBil("EF12345");

Console.WriteLine(v.OpretBil("AQ69694"));
v.LavArbejde("AB12345", "Nye bremser", 2500);
v.LavArbejde("AB12345", "Nyt tag", 10000);
v.SeArbejde("AB12345");

Console.ReadLine();


class Værksted
{
    public List<Bil> bilListe = new List<Bil>();

    public void FærdigBil(string nummerplade)
    {
        Bil b = find(nummerplade);
        FærdigMeld(b);
    }
    private void FærdigMeld(Bil b)
    {
        b.erKlarTilAfhentning = true;
    }

    public void LavArbejde(string nummerplade, string beskrivelse, int pris)
    {
        Bil b = find(nummerplade);
        if (b != null)
        {
            NyArbejde(b, beskrivelse, pris);
        }
        else
        {
            Console.WriteLine($"Bil med nummerplade " + nummerplade + " blev ikke fundet.");
        }
    }

    private void NyArbejde(Bil b, string beskrivelse, int pris)
    {
        b.Arbejde.Add(beskrivelse);
        b.regning = b.regning + pris;
    }
    public List<String> SeArbejde(string nummerplade)
    {
        Bil b = find(nummerplade);
        int i = 0;
        Console.WriteLine("-------------------");
        Console.WriteLine("Arbejde lavet på:" + b.nummerplade);
        while (i < b.Arbejde.Count)
        {
            Console.WriteLine(b.Arbejde[i]);
            i++;
        }
        Console.WriteLine("----------------");
        return b.Arbejde;
    }

    private Bil find(string nummerplade)
    {
        int i = 0;
        Bil b = bilListe[i];
        while (i < bilListe.Count)
        {
            if (bilListe[i].nummerplade == nummerplade)
            {
                b = bilListe[i];
            }
            i++;
        }
        return b;
    }

    public string OpretBil(string nummerplade)
    {
        string svar = opret(nummerplade);
        return svar;
    }

    private string opret(string nummerplade)
    {
        Bil b = new Bil(nummerplade);
        bilListe.Add(b);
        return b.nummerplade;
    }
}

class Bil
{
    public List<string> Arbejde;
    public string nummerplade;
    public int regning;
    public bool erKlarTilAfhentning;

    public Bil(string nummerplade)
    {
        this.nummerplade = nummerplade;

        this.Arbejde = new List<string>();

        this.erKlarTilAfhentning = false;

        this.regning = 0;
    }
}
