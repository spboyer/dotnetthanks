using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotnetthanks
{
    public class IndexModel : PageModel
    {
        private readonly string reponame = "core";
        public string tag {get;set;}

        public Repo CurrentRepo {get;set;}
        public Release CurrentRelease {get;set;}
        public bool LoadRelease {get;set;} = false;
        public bool LoadTags {get;set;} = false;

        private IRepos repos;

        public IndexModel(IRepos repos)
        {
            this.repos  = repos;
        }

        public IActionResult OnGet()
        {

            return RedirectPermanent("https://thanks.dot.net");

           // CurrentRepo =  repos.Items.Find(r => r.Name == reponame);
           
           // if (RouteData.Values["tag"] != null)
           // {
           //     this.tag = RouteData.Values["tag"].ToString();
           //     CurrentRelease = CurrentRepo.ReleaseByTag(tag);
           // }
           

           //if (!string.IsNullOrEmpty(tag))
           //{
           //    LoadRelease = true;
           //}
           //else
           //{
           //    LoadTags = true;
           //}
        }
    }
}
