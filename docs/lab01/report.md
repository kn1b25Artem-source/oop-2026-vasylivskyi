# Лабораторна робота №01

## Створення та організація проєкту на C#/.NET у середовищі Visual Studio

- **Студент:** Василівський Артем, група КН1-Б25
- **Варіант:** 6 — Туристична агенція
- **Проєкт:** TravelApp

## Мета роботи

Ознайомитися з організацією програмного проєкту на платформі .NET та особливостями його створення у середовищі Visual Studio; сформувати практичні навички створення проєкту мовою C#, організації програмного коду та початкової структури предметної області; започаткувати розроблення індивідуального наскрізного проєкту, який буде послідовно розширюватися під час виконання наступних лабораторних робіт.

## Завдання

Проєкт: програма для обліку туристичних пропозицій та клієнтів.

1. Створити проєкт `TravelApp` та простір імен `TravelApp.Models`.
2. Створити класи `Tour` (`Country`, `City`, `Price`) та `Client` (`Name`).
3. Створити по два об'єкти кожного класу та вивести інформацію про них.

## Хід виконання

### 1. Створення проєкту

У Visual Studio 2026 створено консольний застосунок **TravelApp** (шаблон *Console App*, мова C#, платформа .NET 10). Файл рішення `TravelApp.slnx` розміщено в корені репозиторію, а проєкт — у папці `src/TravelApp`. Після створення проєкт успішно скомпільовано та запущено.

### 2. Класи предметної області

У проєкті створено папку `Models`, у якій оголошено простір імен `TravelApp.Models` з двома класами.

Клас `Tour` описує туристичну пропозицію: країну, місто та ціну (файл `Models/Tour.cs`):

```csharp
namespace TravelApp.Models;

/// <summary>
/// Туристична пропозиція (тур).
/// </summary>
public class Tour
{
    public string Country { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
```

Для ціни обрано тип `decimal`, оскільки він призначений для грошових сум і не має похибок двійкового округлення, властивих `double`. Рядкові властивості ініціалізовано значенням `string.Empty`: у шаблоні проєкту ввімкнено nullable reference types, і без початкового значення компілятор видає попередження CS8618.

Клас `Client` описує клієнта агенції (файл `Models/Client.cs`):

```csharp
namespace TravelApp.Models;

/// <summary>
/// Клієнт туристичної агенції.
/// </summary>
public class Client
{
    public string Name { get; set; } = string.Empty;
}
```

### 3. Створення та використання об'єктів

У файлі `Program.cs` підключено простір імен `TravelApp.Models`, створено по два об'єкти кожного класу за допомогою ініціалізаторів об'єктів та виведено інформацію про них у консоль. Рядок `Console.OutputEncoding = System.Text.Encoding.UTF8;` потрібен для коректного відображення українських літер у консолі Windows.

```csharp
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
```

## Структура проєкту

```text
oop-2026-vasylivskyi/
├── src/
│   └── TravelApp/
│       ├── Models/
│       │   ├── Client.cs
│       │   └── Tour.cs
│       ├── Program.cs
│       └── TravelApp.csproj
├── docs/
│   └── lab01/
│       └── report.md
├── .gitignore
├── README.md
└── TravelApp.slnx
```

## Результат виконання

```text
Тури:
Італія, Рим – 42300 грн
Туреччина, Анталія – 28500 грн

Клієнти:
Олександр Бондаренко
Катерина Литвин
```

## Висновки

Під час виконання лабораторної роботи я ознайомився з організацією програмного проєкту на платформі .NET: файлом рішення (`.slnx`), файлом проєкту (`.csproj`) та файлами вихідного коду (`.cs`). У Visual Studio створено консольний застосунок TravelApp, класи предметної області `Tour` і `Client` винесено в окремий простір імен `TravelApp.Models`, а в `Program.cs` продемонстровано створення об'єктів і роботу з їхніми властивостями. Проєкт розміщено в репозиторії GitHub і надалі розширюватиметься в наступних лабораторних роботах.
