namespace Vizsgafeladat.Entities
{
    public class Worker
    {
        public int? ID { get; set; }
        public string? Name { get; set; }

        // Tulajdonság a navigáláshoz
        public ICollection<TheTask>? Tasks { get; set; }

        public override string ToString() => $"({ID}) {Name}";
    }
}
