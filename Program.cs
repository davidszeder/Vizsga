using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Vizsgafeladat;

var builder = new ConfigurationBuilder()
.SetBasePath(Directory.GetCurrentDirectory())
.AddJsonFile("appsettings.json");
var configuration = builder.Build();
var connectionString = configuration.GetConnectionString("ReportDbContext");
var options = new DbContextOptionsBuilder<ReportDbContext>()
    .UseSqlServer(connectionString)
    .Options;

using var dbContext = new ReportDbContext(options);
var reports = dbContext.Reports.ToList();
Console.WriteLine($"{reports.Count} darab bejegyzés található.");


Console.WriteLine("Írjon be körzetszámot, kerületszámot, vagy 100-nál kisebb számot (ahány nappal ezelőttig felvett feladatokat szeretné látni)!:");
var input = Console.ReadLine();

if (int.TryParse(input, out int number))
{
    if (number < 100)
    {
        var dateThreshold = DateTime.Now.AddDays(-number);
        reports = dbContext.Reports
                             .Where(r => r.ReportDate >= dateThreshold)
                             .ToList();

        Console.WriteLine($"Az utóbbi {number} napban bejegyzett feladatok:");
        foreach (var report in reports)
        {
            Console.WriteLine($"- {report.Address} került bejegyzésre {report.ReportDate}");
        }
    }
    else if (number >= 101 && number <= 123)
    {
        string firstThreeDigits = number.ToString();

        reports = dbContext.Reports
                           .Where(r => r.ZipCode == null || r.ZipCode.StartsWith(firstThreeDigits))
                           .ToList();

        Console.WriteLine($"Feladatok a {number} körzet/kerületszámon:");
        foreach (var report in reports)
        {
            Console.WriteLine($"- {report.Address} bejegyezve {report.ReportDate} napon");
        }
    }
    else
    {

        string numberString = number.ToString();

        reports = dbContext.Reports
                           .Where(r => r.ZipCode == numberString || r.District == numberString)
                           .ToList();

        Console.WriteLine($"Feladatok a {number} körzet/kerületszámon:");
        foreach (var report in reports)
        {
            Console.WriteLine($"- {report.Address} bejegyezve {report.ReportDate} napon");
        }
    }
}
else
{
    Console.WriteLine("Helytelen a bevitt adat. Kérem próbáljon számot megadni!");
}
