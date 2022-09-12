class Program
{
    static void Main()
    {
        ListaSzkol szkoly = new();
        
        Szkola zsl = new();

        Klasa klasa1 = new();
        Klasa klasa2 = new();
        Klasa klasa3 = new();


        klasa1.AddStudent(new UczenID { szkola = "zsl", klasa = "1s" }, "jan", "dps", 2, 3, 1);
        klasa1.AddStudent(new UczenID { szkola = "zsl", klasa = "1s" }, "ada", "iiiddsadaps", 3, 23, 91);
        klasa1.AddStudent(new UczenID { szkola = "zsl", klasa = "1s" }, "rop", "ooooodps", 5, 3, 11);
        klasa1.AddStudent(new UczenID { szkola = "zsl", klasa = "1s" }, "syzm", "jjjjjdps", 22, 333, 17);
        klasa1.AddStudent(new UczenID { szkola = "zsl", klasa = "1s" }, "fuk", "ggggdps", 323, 73, 16);
        klasa1.AddStudent(new UczenID { szkola = "zsl", klasa = "1s" }, "luc", "nnnndps", 612, 13, 71);
        klasa1.AddStudent(new UczenID { szkola = "zsl", klasa = "1s" }, "krzs", "cccdps", 212, 33, 11);
        klasa1.AddStudent(new UczenID { szkola = "zsl", klasa = "1s" }, "woj", "aaaadps", 12, 23, 15);


        klasa2.AddStudent(new UczenID { szkola = "zsl", klasa = "2g" }, "dps", "jan", 2, 3, 1);
        klasa2.AddStudent(new UczenID { szkola = "zsl", klasa = "2g" }, "iiiddsadaps", "ada", 3, 23, 91);
        klasa2.AddStudent(new UczenID { szkola = "zsl", klasa = "2g" }, "ooooodps", "rop", 5, 3, 11);
        klasa2.AddStudent(new UczenID { szkola = "zsl", klasa = "2g" }, "jjjjjdps", "syzm", 22, 333, 17);
        klasa2.AddStudent(new UczenID { szkola = "zsl", klasa = "2g" }, "ggggdps", "fuk", 32, 73, 16);
        klasa2.AddStudent(new UczenID { szkola = "zsl", klasa = "2g" }, "nnnndps", "luc", 62, 13, 71);
        klasa2.AddStudent(new UczenID { szkola = "zsl", klasa = "2g" }, "cccdps", "krzs", 212, 33, 11);
        klasa2.AddStudent(new UczenID { szkola = "zsl", klasa = "2g" }, "aaaadps", "woj", 12, 23, 15);


        klasa3.AddStudent(new UczenID { szkola = "zsl", klasa = "4h" }, "jan", "snus", 2, 3, 1);
        klasa3.AddStudent(new UczenID { szkola = "zsl", klasa = "4h" }, "nb", "sadek", 3, 23, 91);
        klasa3.AddStudent(new UczenID { szkola = "zsl", klasa = "4h" }, "cowboy", "bepbop", 5, 3, 11);
        klasa3.AddStudent(new UczenID { szkola = "zsl", klasa = "4h" }, "ss", "ayzm", 2, 333, 17);
        klasa3.AddStudent(new UczenID { szkola = "zsl", klasa = "4h" }, "ps", "sfuk", 2, 73, 16);
        klasa3.AddStudent(new UczenID { szkola = "zsl", klasa = "4h" }, "rober", "lewandoski", 62, 213, 71);
        klasa3.AddStudent(new UczenID { szkola = "zsl", klasa = "4h" }, "ishow", "sped", 2, 33, 11);
        klasa3.AddStudent(new UczenID { szkola = "zsl", klasa = "4h" }, "swea", "daj", 1, 23, 15);

        zsl.AddClass("1s", klasa1);
        zsl.AddClass("2g", klasa2);
        zsl.AddClass("4h", klasa3);

        szkoly.AddSchool("zsl", zsl);

        ShowTree(szkoly);    
    }
    
    static void ShowTree(ListaSzkol szkoly)
    {
        int sql = 0;
        int kls = 0;
        int ucz = 0;


        foreach (var szkola in szkoly.listaSzkol.Values)
        {
            Console.WriteLine(szkoly.listaSzkol.Keys.ToArray()[sql] + " - szkola");
            sql++;

            foreach (var klasa in szkola.szkola.Values)
            {
                Console.WriteLine("|-" + szkola.szkola.Keys.ToArray()[kls] + " srednia inteligencja klasy: " + klasa.ObliczSredniaInteligencja());
                kls++;

                foreach (var uczen in klasa.klasa.Values)
                {
                    Console.WriteLine("  |-" + uczen.imie);
                    ucz++;
                }
                ucz = 0;
            }
            kls = 0;
        }
        sql = 0;
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
    public Dictionary<int, Uczen> klasa = new Dictionary<int, Uczen>();

    public void AddStudent(UczenID uczenID , string imie, string nazwisko, int inteligencja, int zwinnosc, int zachowanie)
    {
        UczenID iD = new UczenID { szkola = uczenID.szkola, klasa = uczenID.klasa, numerUczen = klasa.Count + 1 };
        
        Uczen uczen = new Uczen { id = iD, imie = imie, nazwisko = nazwisko, inteligencja = inteligencja, zwinnosc = zwinnosc, punktyZachowania = zachowanie };
        
        klasa.Add(klasa.Count + 1, uczen);
    }
    
    public Uczen GetStudentFromClass(UczenID uczenID)
    {
        if (this.klasa.TryGetValue(uczenID.numerUczen, out Uczen uczen))
        {
            return uczen;
        }
        else
        {
            Console.WriteLine("Nie ma takiego ucznia " + uczenID.numerUczen);
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
    public Dictionary<string, Klasa> szkola = new Dictionary<string, Klasa>();

    public void AddClass(string nazwaKlasy, Klasa klasa)
    {
        szkola.Add(nazwaKlasy, klasa);
    }

    public Klasa GetClassFromSchool(UczenID uczenID)
    {
        if(this.szkola.TryGetValue(uczenID.klasa, out Klasa klasa))
        {
            return klasa;
        }
        else
        {
            Console.WriteLine("Nie ma takiej szkoly " + uczenID.szkola);
            throw new NullReferenceException();
        }
    }

    public Uczen GetUczenFromSchool(UczenID uczenID)
    {
        var klasa = GetClassFromSchool(uczenID);
        var uczen = klasa.GetStudentFromClass(uczenID);

        if (uczen != null)
        {
            return uczen;
        }
        else
        {
            Console.WriteLine("Nie ma takiego ucznia " + uczenID.ToString());
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

class ListaSzkol
{
    public Dictionary<string, Szkola> listaSzkol = new Dictionary<string, Szkola>();

    public void AddSchool(string nazwaSzkoly, Szkola szkola)
    {
        listaSzkol.Add(nazwaSzkoly, szkola);
    }

    public Szkola GetSchoolFromList(UczenID uczenID)
    {
        if (this.listaSzkol.TryGetValue(uczenID.szkola, out Szkola szkola))
        {
            return szkola;
        }
        else
        {
            Console.WriteLine("Nie ma takiej szkoly " + uczenID.szkola);
            throw new NullReferenceException();
        }
    }
    
    public Uczen GetStudentFromAnywhere(UczenID uczenID)
    {
        var szkola = GetSchoolFromList(uczenID);
        var klasa = szkola.GetClassFromSchool(uczenID);
        var uczen = klasa.GetStudentFromClass(uczenID);

        if (uczen != null)
        {
            return uczen;
        }
        else
        {
            Console.WriteLine("Nie ma takiego ucznia " + uczenID.ToString());
            throw new NullReferenceException();
        }
    }
}