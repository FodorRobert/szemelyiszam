using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.Write("Kérem adja meg az első személyazonosító jel 10 jegyét: ");
        string id1 = Console.ReadLine();
        Console.Write("Kérem adja meg a második személyazonosító jel 10 jegyét: ");
        string id2 = Console.ReadLine();
        string nem1 = GetGender(id1[0]);
        string nem2 = GetGender(id2[0]);
        Console.WriteLine($"Az első személy: {nem1}");
        Console.WriteLine($"A második személy: {nem2}");
        string szuletesisorrend1 = GetBirthOrder(id1);
        string szuletesisorrend2 = GetBirthOrder(id2);
        Console.WriteLine($"Az első személy születési sorszáma: {szuletesisorrend1}");
        Console.WriteLine($"A második személy születési sorszáma: {szuletesisorrend2}");
        (int ev1, int honap1, int nap1) = GetBirthDate(id1);
        (int ev2, int honap2, int nap2) = GetBirthDate(id2);
        int szuletesnap1 = CalculateAge(ev1);
        int szuletesnap2 = CalculateAge(ev2);
        int jelenev = DateTime.Now.Year;
        int kor1 = jelenev - szuletesnap1;
        int kor2 = jelenev - szuletesnap2;
        Console.WriteLine($"Az első személy {kor1} éves.");
        Console.WriteLine($"A második személy {kor2} éves.");
        if (szuletesnap1 > szuletesnap2 && honap1 > honap2 && nap1 > nap2)
        {
            Console.WriteLine("Az első személy idősebb.");
        }
        else if (szuletesnap1 < szuletesnap2 && honap1 < honap2 && nap1 < nap2)
        {
            Console.WriteLine("A második személy idősebb.");
        }
        else
        {
            if (szuletesisorrend1.CompareTo(szuletesisorrend2) < 0)
            {
                Console.WriteLine("Az első személy idősebb.");
            }
            else
            {
                Console.WriteLine("A második személy idősebb.");
            }
        }
        int korkulonbseg = Math.Abs(szuletesnap1 - szuletesnap2);
        Console.WriteLine($"A születési évek közötti különbség: {korkulonbseg} év.");
        string teljesid2 = GetCompleteId(id2);
        Console.WriteLine($"A második személy teljes személyazonosító jele: {teljesid2}");
        using (StreamWriter writer = new StreamWriter("C:\\Users\\fodorr\\Gitwork\\SzemSzam\\szemszam.txt"))
        {
            writer.WriteLine(id1);
            writer.WriteLine(id2);
        }
    }
    static string GetGender(char elsoszam)
    {
        return (elsoszam == '1' || elsoszam == '3') ? "férfi" : "nő";
    }
    static string GetBirthOrder(string code)
    {
        return code.Substring(7, 3);
    }
    static (int year, int month, int day) GetBirthDate(string code)
    {
        int ev = int.Parse(code.Substring(1, 2));
        int honap = int.Parse(code.Substring(3, 2));
        int nap = int.Parse(code.Substring(5, 2));
        return (ev, honap, nap);
    }
    static int CalculateAge(int ev)
    {
        return ev < 99 ? 1900 + ev : 2000 + ev;
    }
    static string GetCompleteId(string code)
    {
        int osszes = 0;
        for (int i = 0; i < 10; i++)
        {
            osszes += int.Parse(code[i].ToString()) * (i + 1);
        }
        int maradek = osszes % 11;
        if (maradek == 10)
        {
            return "Hibás a születési sorszám!";
        }
        return code + maradek.ToString();
    }
}