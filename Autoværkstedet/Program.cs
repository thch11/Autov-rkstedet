Værksted v = new Værksted();

v.OpretBil("AB12345");
v.OpretBil("BC12345");
v.OpretBil("CD12345");
v.OpretBil("DE12345");
v.OpretBil("EF12345");

Console.WriteLine(v.OpretBil("AQ69694"));


class Værksted
{
    public List<Bil> bilListe = new List<Bil>();


    public List<String> SeArbejde(string nummerplade)
    {
        Bil b = find(nummerplade);
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

    public bool erKlarTilAfhentning;

    public Bil(string nummerplade)
    {
        this.nummerplade = nummerplade;

        this.Arbejde = new List<string>();

        this.erKlarTilAfhentning = false;
    }
}