using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductView.Models;

namespace ProductView.Views.Home
{
    public class IndexModel : PageModel
    {
        public List<Phone> phones { get; set; }
        public void OnGet()
        {
            phones  = PhoneRep.Select().ToList();
        }
    }
}
