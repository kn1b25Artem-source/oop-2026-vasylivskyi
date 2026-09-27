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
