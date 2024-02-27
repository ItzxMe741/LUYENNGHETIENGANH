using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLySanXuat.ViewModels
{
    public class EditImageViewModel : UploadImageViewModel
    {
     
        public string ExistingLink { get; set; }
    }

    //******có thể viết chung 1 class nhưng để dễ hiểu thì tách ra
    //******1 cái dành cho eidt 1 cái dành cho create

    //public class EditImageViewModel : UploadImageViewModel
    //{
    //    

    //    //[Display(Name = "Image")]
    //    //public IFormFile Hinhanh { get; set; }
    //    public string ExistingImage { get; set; }
    //}
}
