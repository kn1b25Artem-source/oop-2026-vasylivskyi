namespace TravelApp.Models;

/// <summary>
/// Пляжний тур. Опція «все включено» додає 30 % до базової ціни.
/// </summary>
public class BeachTour : Tour
{
    private const decimal AllInclusiveMarkup = 0.30m;

    public BeachTour(string country, string city, decimal price, bool allInclusive)
        : base(country, city, price)
    {
        AllInclusive = allInclusive;
    }

    public bool AllInclusive { get; set; }

    public override string TourType => "Пляжний тур";

    public override decimal CalculatePrice()
    {
        decimal price = base.CalculatePrice();
        return AllInclusive ? price + price * AllInclusiveMarkup : price;
    }

    protected override string GetDetails()
    {
        return AllInclusive ? "все включено" : "лише проживання";
    }
}
