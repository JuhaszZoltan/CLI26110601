internal class Product
{
    //Id,Kategoria,Gyarto,Modell,Ar_HUF,Keszlet_Db,Ertekeles

    public int Id { get; set; }
    public string Category { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int PriceHUF { get; set; }
    public int StoctQty { get; set; }
    public float Rating { get; set; }

    public override string ToString() =>
        $"\tKategória: {Category}\n" +
        $"\t[ID: {Id}] {Brand} - {Model}\n" +
        $"\tÁr: {PriceHUF:C0}\n" +
        $"\tKészleten: {StoctQty} db\n" +
        $"\tÉrtékelés: {Rating:0.0}/5.0";

}