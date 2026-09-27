namespace TravelApp.Models;

/// <summary>
/// Базовий абстрактний клас туристичної пропозиції.
/// Містить спільні для всіх турів дані, перевірки й бронювання.
/// Створити «просто тур» не можна — лише конкретний тип: пляжний, екскурсійний чи пригодницький.
/// </summary>
public abstract class Tour
{
    private string _country = string.Empty;
    private string _city = string.Empty;
    private decimal _price;

    /// <summary>
    /// Конструктор protected: його викликають лише похідні класи через base(...).
    /// </summary>
    protected Tour(string country, string city, decimal price)
    {
        Country = country;
        City = city;
        Price = price;
    }

    public string Country
    {
        get => _country;
        set => _country = RequireText(value, "Країна");
    }

    public string City
    {
        get => _city;
        set => _city = RequireText(value, "Місто");
    }

    /// <summary>
    /// Базова ціна туру, грн. Повинна бути більшою за нуль.
    /// </summary>
    public decimal Price
    {
        get => _price;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Ціна туру повинна бути більшою за нуль.");
            }

            _price = value;
        }
    }

    public Client? BookedBy { get; private set; }

    public bool IsAvailable => BookedBy is null;

    /// <summary>
    /// Назва типу туру. Абстрактна: кожен похідний клас зобов'язаний її визначити.
    /// </summary>
    public abstract string TourType { get; }

    /// <summary>
    /// Підсумкова вартість туру. Віртуальна: базовий алгоритм повертає базову ціну,
    /// а похідні класи перевизначають його (override).
    /// </summary>
    public virtual decimal CalculatePrice()
    {
        return Price;
    }

    /// <summary>
    /// Особливості конкретного туру. Абстрактний метод без реалізації в базовому класі.
    /// </summary>
    protected abstract string GetDetails();

    /// <summary>
    /// Спільний для всіх турів формат опису. Метод один, але TourType, GetDetails()
    /// і CalculatePrice() викликаються з того класу, яким є об'єкт насправді.
    /// </summary>
    public string GetInfo()
    {
        string status = BookedBy is null ? "доступний" : $"заброньовано: {BookedBy.Name}";
        return $"{TourType}: {Country}, {City} ({GetDetails()}) – {CalculatePrice():0.##} грн [{status}]";
    }

    public void BookTour(Client client)
    {
        ArgumentNullException.ThrowIfNull(client);

        if (!IsAvailable)
        {
            throw new InvalidOperationException($"Тур «{Country}, {City}» уже заброньовано.");
        }

        BookedBy = client;
    }

    public void CancelBooking()
    {
        if (IsAvailable)
        {
            throw new InvalidOperationException($"Тур «{Country}, {City}» не заброньовано, скасовувати нічого.");
        }

        BookedBy = null;
    }

    private static string RequireText(string value, string fieldName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"Поле «{fieldName}» не може бути порожнім.");
        }

        return value.Trim();
    }
}
