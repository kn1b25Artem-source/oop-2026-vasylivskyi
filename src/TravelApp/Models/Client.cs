namespace TravelApp.Models;

/// <summary>
/// Клієнт туристичної агенції.
/// </summary>
public class Client
{
    private string _name = string.Empty;

    /// <summary>
    /// Ім'я клієнта. required — без нього об'єкт не створити,
    /// init — задається лише під час створення, а далі тільки читається.
    /// </summary>
    public required string Name
    {
        get => _name;
        init
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Ім'я клієнта не може бути порожнім.");
            }

            _name = value.Trim();
        }
    }
}
