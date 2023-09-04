using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Vizsgafeladat;
using Vizsgafeladat.Entities;
using System.Linq;

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


var pendingReports = dbContext.Reports
                              .Where(r => !r.Tasks.Any()) // Ha a bejegyzéshez (Report) nem tartozik Task, akkor az elvégzetlennek minősül!
                              .ToList();

Console.WriteLine("Válassza az elvégzett bejegyzést:");
for (int i = 0; i < pendingReports.Count; i++)
{
    Console.WriteLine($"{i + 1}. {pendingReports[i].Address} reported on {pendingReports[i].ReportDate}"); //listázzuk a bejegyzéseket
}

int selectedTaskIndex;
while (true)
{
    if (int.TryParse(Console.ReadLine(), out selectedTaskIndex) && selectedTaskIndex >= 1 && selectedTaskIndex <= pendingReports.Count)
    {
        break;
    }
    Console.WriteLine("Helytelen számot adott meg, nem létezik feladat ezen a sorszámon.");
}

var selectedReport = pendingReports[selectedTaskIndex - 1];

Console.WriteLine("Válassza ki a munka típusát (a munka sorszámának beírásával):");  //Munka típusának beírása
string[] repairTypes = { "Izzócsere", "Lámpabúra javítás", "Vezeték javítás" }; //Listként hoztam létre, de  még bővíthető, vagy enum is használható
for (int i = 0; i < repairTypes.Length; i++)  
{
    Console.WriteLine($"{i + 1}. {repairTypes[i]}");  // MUnkatípushoz sorszám generálás
}

int selectedRepairTypeIndex;
while (true)
{
    if (int.TryParse(Console.ReadLine(), out selectedRepairTypeIndex) && selectedRepairTypeIndex >= 1 && selectedRepairTypeIndex <= repairTypes.Length)
    {
        break;
    }
    Console.WriteLine("Nem jó munkatípust választott!");
}

string selectedRepairType = repairTypes[selectedRepairTypeIndex - 1];


Console.WriteLine("Írja be az azonosító számát!");

var workers = dbContext.Workers;
int workerIdEntered;

while (true)
{
    if (int.TryParse(Console.ReadLine(), out workerIdEntered) && dbContext.Workers.Any(w => w.ID == workerIdEntered))
    {
        break;
    }
    Console.WriteLine("Helytelen azonosító. Kérem próbálja újra!");
}

var task = new TheTask
{
    ReportID = selectedReport.ID,
    WorkerID = workerIdEntered,
    RepairType = selectedRepairType,
    RepairDate = DateTime.Now
};

dbContext.Tasks.Add(task);
dbContext.SaveChanges();

Console.WriteLine("Feladat sikeresen elvégezve!");
