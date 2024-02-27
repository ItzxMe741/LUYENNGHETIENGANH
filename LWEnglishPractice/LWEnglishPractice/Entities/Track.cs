using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LWEnglishPractice.Entities
{
    public partial class Track
    {
        public int Idtrack { get; set; }
        public string Trackname { get; set; }
        public string Source { get; set; }
        public DateTime Dateupload { get; set; }
        public int Duration { get; set; }
        public string Describe { get; set; }
        public int Active { get; set; }
        public int Idlesson { get; set; }

        public virtual Lesson IdlessonNavigation { get; set; }
    }
}
