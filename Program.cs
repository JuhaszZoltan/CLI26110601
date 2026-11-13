using System.Net.NetworkInformation;

List<Product> products = [];

#region read file
#nullable disable

const string FilePath = "..\\..\\..\\data\\arukeszlet.csv";

using StreamReader sr = new(FilePath);
_ = sr.ReadLine();
while (!sr.EndOfStream)
{
    var t = sr.ReadLine().Split(',');
    products.Add(new()
    {
        Id = int.Parse(t[0]),
        Category = t[1],
        Brand = t[2],
        Model = t[3],
        PriceHUF = int.Parse(t[4]),
        StoctQty = int.Parse(t[5]),
        Rating = float.Parse(t[6].Replace('.', ','))
    });
}

#endregion


//imperatív (C#, python, js, php) (HOGYAN????)
//int c = 0;
//for (int i = 0; i < products.Count; i++)
//{
//    if (products[i].Brand == "Nova")
//    {
//        c++;
//    }
//}
//Console.WriteLine($"op: {c}");

//deklaratív (SQL, html, xml) (MIT????)
/*
    SELECT COUNT(*)
    FROM products
    WHERE Brand LIKE 'Nova'; 
*/

var sum = products.Sum(p => p.StoctQty);

var avg = products.Average(p => p.Rating);

var count = products.Count(p => p.Brand == "Nova");

var maxby = products.MaxBy(p => p.PriceHUF);

// maxby és minby onjektum referenciát (példányt) ad vissza
// max és min CSAK az értéket (és ez alapján nem egyértelmű, hogy az melyik példányhoz artozik)

//contains: NEM LINQ (hanem collection.generic), nem <selector>-t vagy <predicate>-t, hanem KONKRÉT obj. referenciát!

var any = products.Any(p => p.Brand == "Microsoft");
//Console.WriteLine(any ?  "van microsoft termék" : "nincs microsoft termék");

var all = products.All(p => p.PriceHUF < 1000000);
//Console.WriteLine(all ? "minden termék olcsóbb, mint 1M" : "van 1M ft feletti árú termék");

//kiválasztás, lieáris keresés
//int i = 0;
//while (i < products.Count && products[i].Brand != "Microsoft") i++;
//Console.WriteLine($"{i}");

//'kiválasztás'            'keresés'
//  first               first or default
//  last                last or default
//  single              single or default

var fod = products.FirstOrDefault(p => p.Brand == "Cyber");
Console.WriteLine(fod is null ? "nincs találat" : fod);

// FIRST
// HA VAN a <pred>-nek megfelelő TALÁLAT, akkor visszaadja rendre az ELSŐ megfelelő példányt
// HA NINCS, akkor 'Sequence contains no matching element' exc-et dob!

// LAST
// HA VAN a <pred>-nek megfelelő TALÁLAT, akkor visszaadja rendre az UTOLSÓ megfelelő példányt
// HA NINCS, akkor 'Sequence contains no matching element' exc-et dob!

// FIRST OR DEFAULT
// HA VAN a <pred>-nek megfelelő TALÁLAT, akkor visszaadja rendre az ELSŐ megfelelő példányt
// HA NINCS, akkor típuskól függő default értékkel tér vissza, ami:
//    reference typeok (azaz class) esetében >>>> NULL <<<<
//    value typok esetében a típuson értelmezett "zéró" érték.

// LAST OR DEFAULT
// HA VAN a <pred>-nek megfelelő TALÁLAT, akkor visszaadja rendre az UTOLSÓ megfelelő példányt
// HA NINCS, akkor típuskól függő default értékkel tér vissza, ami:
//    reference typeok (azaz class) esetében >>>> NULL <<<<
//    value typok esetében a típuson értelmezett "zéró" érték.

// SINGLE
// HA EGYETLEN a <pred>-nek megfelelő TALÁLAT van, akkor visszaadja azt a példányt
// HA TÖBB találat LENNE, akkor 'Sequence contains more than one matching element' - exc.-et dob
// HA NINCS, akkor 'Sequence contains no matching element' exc-et dob!

// SINGLE OR DEFAULT
// HA EGYETLEN a <pred>-nek megfelelő TALÁLAT van, akkor visszaadja azt a példányt
// HA TÖBB találat LENNE, akkor 'Sequence contains more than one matching element' - exc.-et dob
// HA NINCS, akkor típuskól függő default értékkel tér vissza, ami:
//    reference typeok (azaz class) esetében >>>> NULL <<<<
//    value typok (azaz struct) esetében a típuson értelmezett "zéró" érték.

// másolás
// kiválogatás
// szétválogatás (csoportosítás)
// rendezés