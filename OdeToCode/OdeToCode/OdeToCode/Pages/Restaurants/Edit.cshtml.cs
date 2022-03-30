using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToCode.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Restaurant Restaurant { get; set; }

        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? restaurantId)
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisinType>();

            if (restaurantId.HasValue)
            {
                Restaurant = this.restaurantData.GetById(restaurantId.Value);
            }
            else
            {
                Restaurant = new Restaurant { };
            }

            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Cuisines = htmlHelper.GetEnumSelectList<CuisinType>();

                return Page();

            }

            if (Restaurant.Id > 0)
            {
                Restaurant = restaurantData.Update(this.Restaurant);
                TempData["Message"] = "Restaurant Updated!";
            }
            else
            {
                Restaurant = restaurantData.Add(this.Restaurant);
                TempData["Message"] = "Restaurant Saved!";
            }

            restaurantData.Commit();

            return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });
        }
    }
}
