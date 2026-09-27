using TravelApp.Models;

Tour tour1 = new()
{
    Country = "Італія",
    City = "Рим",
    Price = 25000m
};

Tour tour2 = new()
{
    Country = "Іспанія",
    City = "Барселона",
    Price = 21500m
};

Client client1 = new()
{
    Name = "Андрій Мельник"
};

Client client2 = new()
{
    Name = "Марія Бондаренко"
};

Console.WriteLine("Тури:");
Console.WriteLine($"{tour1.Country}, {tour1.City} – {tour1.Price} грн");
Console.WriteLine($"{tour2.Country}, {tour2.City} – {tour2.Price} грн");

Console.WriteLine("\nКлієнти:");
Console.WriteLine(client1.Name);
Console.WriteLine(client2.Name);
