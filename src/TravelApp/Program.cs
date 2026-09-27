using TravelApp.Models;

// Щоб українські літери (і, ї, є, ґ) правильно відображалися в консолі Windows
Console.OutputEncoding = System.Text.Encoding.UTF8;

// 1. Створення об'єктів.
// Тур створюється через конструктор: без країни, міста й ціни його не створити.
// У клієнта ім'я — required-властивість: без неї код не скомпілюється.
Tour tour1 = new("Італія", "Рим", 42300);
Tour tour2 = new("Туреччина", "Анталія", 28500);

Client client1 = new() { Name = "Олександр Бондаренко" };
Client client2 = new() { Name = "Катерина Литвин" };

Console.WriteLine("Тури:");
Console.WriteLine(tour1.GetInfo());
Console.WriteLine(tour2.GetInfo());

Console.WriteLine("\nКлієнти:");
Console.WriteLine(client1.Name);
Console.WriteLine(client2.Name);

// 2. Зміна властивості: нова ціна проходить перевірку в set
tour2.Price = 26900;
Console.WriteLine($"\nЗнижка: {tour2.GetInfo()}");

// 3. Керування станом туру — лише через методи BookTour() і CancelBooking()
Console.WriteLine("\nБронювання:");
tour1.BookTour(client1);
Console.WriteLine(tour1.GetInfo());

try
{
    tour1.BookTour(client2);
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Помилка: {ex.Message}");
}

tour1.CancelBooking();
Console.WriteLine(tour1.GetInfo());

try
{
    tour1.CancelBooking();
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Помилка: {ex.Message}");
}

// 4. Некоректні дані: об'єкт не переходить у неприпустимий стан
Console.WriteLine("\nПеревірка некоректних даних:");

try
{
    Tour wrongTour = new("Єгипет", "Хургада", -1000);
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Помилка: {ex.Message}");
}

try
{
    tour2.City = "   ";
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Помилка: {ex.Message}");
}

try
{
    Client wrongClient = new() { Name = "" };
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Помилка: {ex.Message}");
}

Console.WriteLine($"Тур не змінився: {tour2.GetInfo()}");

// Такий код не скомпілюється — стан змінюється лише через методи класу:
// tour1.IsAvailable = false;     // CS0200: властивість лише для читання
// tour1.BookedBy = client2;      // CS0272: set-аксесор приватний
// client1.Name = "Інше ім'я";    // CS8852: init-властивість задається лише під час створення
