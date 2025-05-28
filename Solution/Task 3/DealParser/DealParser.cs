
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public class Deal
{
    public int Sum { get; set; }
    public required string Id { get; set; }
    public DateTime Date { get; set; }
}

public record SumByMonth(DateTime Month, int Sum);

public class DealParser
{
    public static Deal[] LoadDeals(string path)
    {
        string json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<Deal[]>(json);
    }

    public static IList<string> GetNumbersOfDeals(IEnumerable<Deal> deals)
    {
        return deals
            .Where(d => d.Sum >= 100)
            .OrderBy(d => d.Date)
            .Take(5)
            .OrderByDescending(d => d.Sum)
            .Select(d => d.Id)
            .ToList();
    }

    public static IList<SumByMonth> GetSumsByMonth(IEnumerable<Deal> deals)
    {
        return deals
            .GroupBy(d => new DateTime(d.Date.Year, d.Date.Month, 1))
            .Select(g => new SumByMonth(g.Key, g.Sum(d => d.Sum)))
            .ToList();
    }
}
