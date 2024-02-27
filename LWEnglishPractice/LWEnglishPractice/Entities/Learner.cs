using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LWEnglishPractice.Entities
{
    public partial class Learner
    {
        public Learner()
        {
            History = new HashSet<History>();
        }

        public int Idlearner { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public DateTime Joindate { get; set; }
        public DateTime? Dateofbirth { get; set; }
        public string Sex { get; set; }
        public int Active { get; set; }

        public virtual ICollection<History> History { get; set; }
    }
}
