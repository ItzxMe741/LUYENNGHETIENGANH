﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LWEnglishPractice.Entities
{
    public partial class History
    {
        public int Idhistory { get; set; }
        public int? Score { get; set; }
        public int? Finishtime { get; set; }
        public DateTime? Finishdate { get; set; }
        public int Idlearner { get; set; }
        public int Idlesson { get; set; }

        public virtual Learner IdlearnerNavigation { get; set; }
        public virtual Lesson IdlessonNavigation { get; set; }
    }
}
