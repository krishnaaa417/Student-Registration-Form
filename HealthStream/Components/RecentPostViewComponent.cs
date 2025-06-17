using Microsoft.AspNetCore.Mvc;

namespace HealthStream.Components
{
    public class RecentPostViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            // write down a code to make a db call to fetch records

            var RecentPosts = new List<string> { "Weather is good", "India played very wel", "It's raining today" };
            return View(RecentPosts);
        }
    }
}
