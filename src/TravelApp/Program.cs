using TravelApp.Models;

// Щоб українські літери (і, ї, є, ґ) правильно відображалися в консолі Windows
Console.OutputEncoding = System.Text.Encoding.UTF8;

Tour tour1 = new()
{
    Country = "Італія",
    City = "Рим",
    Price = 42300
};

Tour tour2 = new()
{
    Country = "Туреччина",
    City = "Анталія",
    Price = 28500
};

Client client1 = new()
{
    Name = "Олександр Бондаренко"
};

Client client2 = new()
{
    Name = "Катерина Литвин"
};

Console.WriteLine("Тури:");
Console.WriteLine($"{tour1.Country}, {tour1.City} – {tour1.Price} грн");
Console.WriteLine($"{tour2.Country}, {tour2.City} – {tour2.Price} грн");

Console.WriteLine("\nКлієнти:");
Console.WriteLine(client1.Name);
Console.WriteLine(client2.Name);
