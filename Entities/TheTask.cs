using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Vizsgafeladat.Entities
{
    public class TheTask
    {
        /// <summary>
        /// A feladat azonosítója.
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// A jelentés azonosítója.
        /// </summary>
        public int ReportID { get; set; }
        /// <summary>
        /// A javítás típusa.
        /// </summary>
        public string? RepairType { get; set; }
        /// <summary>
        /// A javítás dátuma.
        /// </summary>
        public DateTime RepairDate { get; set; }
        /// <summary>
        /// A dolgozó azonosítója.
        /// </summary>
        public int WorkerID { get; set; }

        // Navigációk a report és munkás felé
        public Report? Report { get; set; }
        public Worker? Worker { get; set; }
        public override string ToString() => $"({ID}): Report {ReportID} - Dolgozó {WorkerID}";
    }
}
