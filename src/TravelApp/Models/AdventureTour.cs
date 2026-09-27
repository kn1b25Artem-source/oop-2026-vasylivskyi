namespace TravelApp.Models;

/// <summary>
/// Пригодницький тур. Кожен рівень складності додає 10 % до базової ціни,
/// а обов'язкова страховка — ще 1500 грн.
/// </summary>
public class AdventureTour : Tour
{
    private const decimal DifficultyMarkup = 0.10m;
    private const decimal InsuranceFee = 1500m;
    private int _difficultyLevel;

    public AdventureTour(string country, string city, decimal price, int difficultyLevel)
        : base(country, city, price)
    {
        DifficultyLevel = difficultyLevel;
    }

    /// <summary>
    /// Рівень складності від 1 до 3.
    /// </summary>
    public int DifficultyLevel
    {
        get => _difficultyLevel;
        set
        {
            if (value < 1 || value > 3)
            {
                throw new ArgumentException("Рівень складності повинен бути від 1 до 3.");
            }

            _difficultyLevel = value;
        }
    }

    public override string TourType => "Пригодницький тур";

    public override decimal CalculatePrice()
    {
        decimal price = base.CalculatePrice();
        return price + price * DifficultyMarkup * DifficultyLevel + InsuranceFee;
    }

    protected override string GetDetails()
    {
        return $"складність {DifficultyLevel} з 3, зі страховкою";
    }
}
