// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
List<int> list = new List<int>();
list.Add(3);
list.Add(1);    
list.Add(2);
List<int> list2 = new List<int>()
{
    1,
    2,
    3
};

List<Chleb> chleby = new List<Chleb>();
chleby.Add(new Chleb() { a = 3, b = "bułka" });
chleby.Add(new Chleb() { a = 1, b = "kajzerka" });

List<Chleb> chleby2 = new List<Chleb>()
{
    new Chleb()
    {
        a = 1,
        b = "bagietka"
    },
    new Chleb()
    {
        a = 2,
        b = "hotdog"
    }
};
Console.WriteLine(list.Count.ToString() + " " + list2.Count + " " + chleby.Count + " " + chleby2.Count);
Console.ReadKey();
list.Sort();
for (int i = 0; i < chleby.Count; i++)
    Console.WriteLine(chleby[i] + i.ToString());
Console.ReadKey();
chleby.Sort();

for (int i = 0; i < chleby.Count; i++)
    Console.WriteLine(chleby[i].b);

Console.ReadKey();
Console.WriteLine(list.Count);
if (list.Contains(2))
    list.Remove(2);
list.Sort();
Console.WriteLine(list.Count);

Console.ReadKey();
Dictionary<Chleb, string> nazwyChlebow = new Dictionary<Chleb, string>();
nazwyChlebow.Add(chleby2[0], "bagietka");
nazwyChlebow.Add(chleby2[1], "hotdog");

Dictionary<string, Chleb> nazwyChlebow2 = new Dictionary<string, Chleb>();
nazwyChlebow2.Add("bagietka", chleby2[0]);
nazwyChlebow2.Add("hotdog", chleby2[1]);

if (chleby2.Contains(nazwyChlebow2["bagietka"]))
{
    Console.WriteLine("bagietka");
}


class Chleb : IComparable<Chleb>
{
    public int a;
    public string b;

    public int CompareTo(Chleb chlebToCompare)
    {
        if (this.b.Length < chlebToCompare.b.Length)
            return 1;
        else if (this.b.Length > chlebToCompare.b.Length)
            return -1;
        else
            return 0;
    }
}