using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SimWeb.Pages
{
    public class IndexModel : PageModel
    {
        public string Moves => App.SimulationHistory.GetMoves();

        public void OnGet()
        {

        }
    }
}
