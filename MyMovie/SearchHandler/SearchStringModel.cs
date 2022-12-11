using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace MyMovie.SearchHandler
{
    public class SearchStringModel : PageModel
    {

        [BindProperty]
        public InputModel Input { get; set;}

        public class InputModel
        {
            [Display(Name = "searchString")]
            public string SearchQurrie { get; set; }

            [Display(Name = "discoverCheckbox")]
            public bool DiscoverMode { get; set; } = false;
        }

        public SearchModel Search(InputModel input)
        {
            ISearchHandler searchHandler = new SearchHandler();
            SearchModel model;
            if (input.DiscoverMode)
            {
                return model = searchHandler.Discover(input.SearchQurrie);
            } 
            else
            {
                return model = searchHandler.Search(input.SearchQurrie);
            }
        }


    }
}
