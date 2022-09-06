class Program
{
    static void Main()
    {
        Szkola zsl = new();

        Klasa klasa1 = new();
        Klasa klasa2 = new();


        klasa1.AddUczen(new UczenID { szkola = "zsl", klasa = "1s" }, "jan", "dps", 2, 3, 1);
        klasa1.AddUczen(new UczenID { szkola = "zsl", klasa = "1s" }, "ada", "iiiddsadaps", 3, 23, 91);
        klasa1.AddUczen(new UczenID { szkola = "zsl", klasa = "1s" }, "rop", "ooooodps", 5, 3, 11);
        klasa1.AddUczen(new UczenID { szkola = "zsl", klasa = "1s" }, "syzm", "jjjjjdps", 22, 333, 17);
        klasa1.AddUczen(new UczenID { szkola = "zsl", klasa = "1s" }, "fuk", "ggggdps", 32, 73, 16);
        klasa1.AddUczen(new UczenID { szkola = "zsl", klasa = "1s" }, "luc", "nnnndps", 62, 13, 71);
        klasa1.AddUczen(new UczenID { szkola = "zsl", klasa = "1s" }, "krzs", "cccdps", 212, 33, 11);
        klasa1.AddUczen(new UczenID { szkola = "zsl", klasa = "1s" }, "woj", "aaaadps", 12, 23, 15);


        klasa2.AddUczen(new UczenID { szkola = "zsl", klasa = "2g" }, "dps", "jan", 2, 3, 1);
        klasa2.AddUczen(new UczenID { szkola = "zsl", klasa = "2g" }, "iiiddsadaps", "ada", 3, 23, 91);
        klasa2.AddUczen(new UczenID { szkola = "zsl", klasa = "2g" }, "ooooodps", "rop", 5, 3, 11);
        klasa2.AddUczen(new UczenID { szkola = "zsl", klasa = "2g" }, "jjjjjdps", "syzm", 22, 333, 17);
        klasa2.AddUczen(new UczenID { szkola = "zsl", klasa = "2g" }, "ggggdps", "fuk", 32, 73, 16);
        klasa2.AddUczen(new UczenID { szkola = "zsl", klasa = "2g" }, "nnnndps", "luc", 62, 13, 71);
        klasa2.AddUczen(new UczenID { szkola = "zsl", klasa = "2g" }, "cccdps", "krzs", 212, 33, 11);
        klasa2.AddUczen(new UczenID { szkola = "zsl", klasa = "2g" }, "aaaadps", "woj", 12, 23, 15);

        zsl.AddKlasa("1s", klasa1);
        zsl.AddKlasa("2g", klasa2);


        UczenID uczenID = new UczenID { szkola = "zsl", klasa = "1s", numerUczen = 4 };

        var wybraniec = zsl.GetUczen(uczenID);

        Console.WriteLine(wybraniec.imie + " " + wybraniec.nazwisko);
    }
}

class Uczen
{
    public UczenID id;
    public string? imie;
    public string? nazwisko;
    public int inteligencja;
    public int zwinnosc;
    public int punktyZachowania;
}

class Klasa
{
    private Dictionary<int, Uczen> klasa = new Dictionary<int, Uczen>();

    public void AddUczen(UczenID uczenID , string imie, string nazwisko, int inteligencja, int zwinnosc, int zachowanie)
    {
        UczenID iD = new UczenID { szkola = uczenID.szkola, klasa = uczenID.klasa, numerUczen = klasa.Count + 1 };
        
        Uczen uczen = new Uczen { id = iD, imie = imie, nazwisko = nazwisko, inteligencja = inteligencja, zwinnosc = zwinnosc, punktyZachowania = zachowanie };
        
        klasa.Add(klasa.Count + 1, uczen);
    }
    
    public Uczen GetStudent(UczenID id)
    {
        if (this.klasa.TryGetValue(id.numerUczen, out Uczen uczen))
        {
            return uczen;
        }
        else
        {
            Console.WriteLine("Nie ma takiego ucznia " + id.numerUczen);
            throw new NullReferenceException();
        }
    }

    public float ObliczSredniaInteligencja()
    {
        float srednia = 0;
        foreach(int i in klasa.Keys)
        {
            srednia += klasa[i].inteligencja;
        }
        srednia /= klasa.Count;
        return srednia;
    }
    public float ObliczSredniaZwinnosc()
    {
        float srednia = 0;
        foreach (int i in klasa.Keys)
        {
            srednia += klasa[i].zwinnosc;
        }
        srednia /= klasa.Count;
        return srednia;
    }
    public float ObliczSumaPkt()
    {
        float suma = 0;
        foreach (int i in klasa.Keys)
        {
            suma += klasa[i].punktyZachowania;
        }
        return suma;
    }
    public float ObliczSredniaPkt()
    {
        float srednia = 0;
        foreach (int i in klasa.Keys)
        {
            srednia += klasa[i].punktyZachowania;
        }
        srednia /= klasa.Count;
        return srednia;
    }
}

class Szkola
{
    private Dictionary<string, Klasa> szkola = new Dictionary<string, Klasa>();

    public void AddKlasa(string nazwaKlasy, Klasa klasa)
    {
        szkola.Add(nazwaKlasy, klasa);
    }

    public Uczen GetUczen(UczenID idUczen)
    {
        if(this.szkola.TryGetValue(idUczen.klasa, out Klasa klasa))
        {
            return klasa.GetStudent(idUczen);
        }
        else
        {
            Console.WriteLine("Nie ma takiej szkoly " + idUczen.szkola);
            throw new NullReferenceException();
        }
    }
}

struct UczenID
{
    public string szkola;
    public string klasa;
    public int numerUczen;
}