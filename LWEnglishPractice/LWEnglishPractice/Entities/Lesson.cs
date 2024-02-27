using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LWEnglishPractice.Entities
{
    public partial class Lesson
    {
        public Lesson()
        {
            History = new HashSet<History>();
            Track = new HashSet<Track>();
        }

        public int Idlesson { get; set; }
        public string Lessonanme { get; set; }
        public DateTime Datecreate { get; set; }
    
        public string Describe { get; set; }
        public int Active { get; set; }
        public int Idlevel { get; set; }

        public virtual Level IdlevelNavigation { get; set; }
        public virtual ICollection<History> History { get; set; }
        public virtual ICollection<Track> Track { get; set; }
    }
}
