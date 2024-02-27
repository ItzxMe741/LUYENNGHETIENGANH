using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLySanXuat.ViewModels
{
    public class UploadImageViewModel
    {
       
        public IFormFile Source { get; set; }
    }
}
