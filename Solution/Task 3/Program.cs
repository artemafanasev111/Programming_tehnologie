using System.Text.Json;

class Program
{
    static void Main()
    {
        var json = File.ReadAllText("JSON_sample_1.json");
        var deals = JsonSerializer.Deserialize<List<Deal>>(json);

        var numbers = DealParser.GetNumbersOfDeals(deals);
        Console.WriteLine($"Сделки (не менее 100 руб, 5 самых ранних, отсортированы по сумме):");
        Console.WriteLine(string.Join(", ", numbers));

        var monthlySums = DealParser.GetSumsByMonth(deals);
        Console.WriteLine("\nСуммы по месяцам:");
        foreach (var sum in monthlySums)
        {
            Console.WriteLine($"{sum.Month:yyyy-MM}: {sum.Sum}");
        }
    }
}
