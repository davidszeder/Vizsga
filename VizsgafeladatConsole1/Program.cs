using Vizsgafeladat;

class Querytasks
{
    static void Main()
    {
        using var context = new ReportDbContext();

        Console.WriteLine("Enter a zip code, district number, or a number less than 100:");
        var input = Console.ReadLine();

        if (int.TryParse(input, out int number))
        {
            if (number < 100)
            {
                var dateThreshold = DateTime.Now.AddDays(-number);
                var reports = context.Reports
                                     .Where(r => r.ReportDate >= dateThreshold)
                                     .ToList();

                Console.WriteLine($"Tasks reported in the last {number} days:");
                foreach (var report in reports)
                {
                    Console.WriteLine($"- {report.Address} reported on {report.ReportDate}");
                }
            }
            else
            {
                var numberString = number.ToString();

                var reports = context.Reports
                                     .Where(r => r.ZipCode == numberString || r.District == numberString)
                                     .ToList();

                Console.WriteLine($"Tasks for zip code/district {number}:");
                foreach (var report in reports)
                {
                    Console.WriteLine($"- {report.Address} reported on {report.ReportDate}");
                }
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }
}
