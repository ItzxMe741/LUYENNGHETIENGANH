using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LWEnglishPractice.Entities
{
    public partial class Level
    {
        public Level()
        {
            Lesson = new HashSet<Lesson>();
        }

        public int Idlevel { get; set; }
        public int? Level1 { get; set; }
        public string Levelname { get; set; }
        public int Active { get; set; }

        public virtual ICollection<Lesson> Lesson { get; set; }
    }
}
