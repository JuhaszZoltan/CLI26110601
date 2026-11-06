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

