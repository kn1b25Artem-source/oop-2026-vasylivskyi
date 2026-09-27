using TravelApp.Models;

// Щоб українські літери (і, ї, є, ґ) правильно відображалися в консолі Windows
Console.OutputEncoding = System.Text.Encoding.UTF8;

Client client1 = new() { Name = "Олександр Бондаренко" };
Client client2 = new() { Name = "Катерина Литвин" };

// Поліморфна колекція: список має тип базового класу Tour,
// а зберігає об'єкти різних похідних класів
List<Tour> tours = new List<Tour>
{
    new BeachTour("Туреччина", "Анталія", 28500, allInclusive: true),
    new BeachTour("Греція", "Крит", 34000, allInclusive: false),
    new ExcursionTour("Італія", "Рим", 42300, excursionCount: 3),
    new AdventureTour("Україна", "Яремче", 9800, difficultyLevel: 2)
};

PrintTours("Туристичні пропозиції:", tours);
Console.WriteLine($"Разом за всіма турами: {CalculateTotal(tours):0.##} грн");

// Бронювання через посилання на базовий тип Tour
tours[0].BookTour(client1);
tours[2].BookTour(client2);
PrintTours("\nПісля бронювання:", tours);

Tour? cheapest = FindCheapestAvailable(tours);
if (cheapest is not null)
{
    Console.WriteLine("\nНайдешевший із доступних турів:");
    Console.WriteLine(cheapest.GetInfo());
}

// Перевірки працюють і в базовому класі, і в похідних
Console.WriteLine("\nПеревірка некоректних даних:");

try
{
    Tour wrongTour = new ExcursionTour("Франція", "Париж", 39000, excursionCount: 0);
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Помилка: {ex.Message}");
}

try
{
    Tour wrongTour = new AdventureTour("Грузія", "Казбегі", 15000, difficultyLevel: 5);
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Помилка: {ex.Message}");
}

try
{
    Tour wrongTour = new BeachTour("", "Шарм-ель-Шейх", 30000, allInclusive: true);
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Помилка: {ex.Message}");
}

// Такий код не скомпілюється:
// Tour tour = new Tour("Італія", "Рим", 42300);   // CS0144: не можна створити об'єкт абстрактного класу

// Виводить усі тури списку. Для кожного викликається GetInfo() базового класу,
// а всередині нього — CalculatePrice() і GetDetails() конкретного типу туру.
static void PrintTours(string title, List<Tour> tourList)
{
    Console.WriteLine(title);
    foreach (Tour tour in tourList)
    {
        Console.WriteLine(tour.GetInfo());
    }
}

// Сумарна вартість: CalculatePrice() кожного туру викликається через базовий тип
static decimal CalculateTotal(List<Tour> tourList)
{
    decimal total = 0;
    foreach (Tour tour in tourList)
    {
        total += tour.CalculatePrice();
    }

    return total;
}

// Найдешевший тур серед доступних для бронювання
static Tour? FindCheapestAvailable(List<Tour> tourList)
{
    Tour? cheapest = null;
    foreach (Tour tour in tourList)
    {
        if (tour.IsAvailable && (cheapest is null || tour.CalculatePrice() < cheapest.CalculatePrice()))
        {
            cheapest = tour;
        }
    }

    return cheapest;
}
