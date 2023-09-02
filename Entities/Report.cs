using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vizsgafeladat.Entities
{
    public class Report
    {
        /// <summary>
        /// Az adatbázis által automatikusan generált azonosító.
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Az észlelés helyszíne.
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Az észlelés körzetszáma.
        /// </summary>
        public string ZipCode { get; set; }
        /// <summary>
        /// Az észlelés körzete.
        /// </summary>
        public string District { get; set; }
        /// <summary>
        /// Az észlelés dátuma.
        /// </summary>
        public DateTime ReportDate { get; set; }

        ///Navigáció a taskok között
        public ICollection<TheTask>? Tasks { get; set; }
    }
}
