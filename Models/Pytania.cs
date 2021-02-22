using System;
using System.Collections.Generic;

namespace ztp_projekt.Models
{
    public partial class Pytania
    {
        public decimal IdPytania { get; set; }
        public string TrescAngielski { get; set; }
        public string TrescPolski { get; set; }
        public string OdpowiedzAngielski { get; set; }
        public string OdpowiedzPolski { get; set; }
        public string BlednaOdpAngielski1 { get; set; }
        public string BlednaOdpAngielski2 { get; set; }
        public string BlednaOdpAngielski3 { get; set; }
        public string BlednaOdpPolski1 { get; set; }
        public string BlednaOdpPolski2 { get; set; }
        public string BlednaOdpPolski3 { get; set; }
    }
}
