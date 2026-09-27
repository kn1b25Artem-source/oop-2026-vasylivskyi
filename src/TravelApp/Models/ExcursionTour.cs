namespace TravelApp.Models;

/// <summary>
/// Екскурсійний тур. Кожна екскурсія з гідом коштує 800 грн понад базову ціну.
/// </summary>
public class ExcursionTour : Tour
{
    private const decimal ExcursionFee = 800m;
    private int _excursionCount;

    public ExcursionTour(string country, string city, decimal price, int excursionCount)
        : base(country, city, price)
    {
        ExcursionCount = excursionCount;
    }

    public int ExcursionCount
    {
        get => _excursionCount;
        set
        {
            if (value < 1)
            {
                throw new ArgumentException("Екскурсійний тур повинен містити хоча б одну екскурсію.");
            }

            _excursionCount = value;
        }
    }

    public override string TourType => "Екскурсійний тур";

    public override decimal CalculatePrice()
    {
        return base.CalculatePrice() + ExcursionCount * ExcursionFee;
    }

    protected override string GetDetails()
    {
        return $"екскурсій: {ExcursionCount}";
    }
}
