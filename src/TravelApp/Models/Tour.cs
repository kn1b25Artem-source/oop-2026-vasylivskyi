namespace TravelApp.Models;

/// <summary>
/// Туристична пропозиція (тур).
/// Дані зберігаються в приватних полях, а доступ до них іде через властивості з перевірками.
/// </summary>
public class Tour
{
    private string _country = string.Empty;
    private string _city = string.Empty;
    private decimal _price;

    /// <summary>
    /// Створює тур. Значення присвоюються через властивості,
    /// тому ті самі перевірки працюють і під час створення, і під час зміни.
    /// </summary>
    public Tour(string country, string city, decimal price)
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
    /// Ціна туру, грн. Повинна бути більшою за нуль.
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

    /// <summary>
    /// Клієнт, який забронював тур. Змінити ззовні не можна: set приватний.
    /// </summary>
    public Client? BookedBy { get; private set; }

    /// <summary>
    /// Чи доступний тур для бронювання. Обчислюється з BookedBy, тому стан завжди узгоджений.
    /// </summary>
    public bool IsAvailable => BookedBy is null;

    /// <summary>
    /// Бронює тур для клієнта. Повторне бронювання заборонене.
    /// </summary>
    public void BookTour(Client client)
    {
        ArgumentNullException.ThrowIfNull(client);

        if (!IsAvailable)
        {
            throw new InvalidOperationException($"Тур «{Country}, {City}» уже заброньовано.");
        }

        BookedBy = client;
    }

    /// <summary>
    /// Скасовує бронювання. Скасувати можна лише заброньований тур.
    /// </summary>
    public void CancelBooking()
    {
        if (IsAvailable)
        {
            throw new InvalidOperationException($"Тур «{Country}, {City}» не заброньовано, скасовувати нічого.");
        }

        BookedBy = null;
    }

    /// <summary>
    /// Короткий опис туру разом із його станом.
    /// </summary>
    public string GetInfo()
    {
        string status = BookedBy is null ? "доступний" : $"заброньовано: {BookedBy.Name}";
        return $"{Country}, {City} – {Price:0.##} грн [{status}]";
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
