using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;


namespace dotnetthanks.Pages
{
    public class Index2Model : PageModel
    {
        private readonly ILogger<Index2Model> _logger;
           
        public Index2Model(ILogger<Index2Model> logger)
        {
            _logger = logger;
        }

        
        public void Get()
        {
        }

    }

}
