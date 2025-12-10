using System;

namespace TaskManagerDesktop.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Tytul { get; set; }
        public string Kategoria { get; set; } // praca, nauka, dom
        public string Priorytet { get; set; } // niski, œredni, wysoki
        public bool Ukoñczone { get; set; }
        public DateTime Termin { get; set; }
    }
}
