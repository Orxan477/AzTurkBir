using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aztobir.Business.ViewModels.Home.FAQ
{
    public class CreateFAQVM
    {
        public string Question { get; set; }
        public string Response { get; set; }
    }
}
