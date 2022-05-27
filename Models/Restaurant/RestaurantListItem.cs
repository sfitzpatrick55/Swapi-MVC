using System.ComponentModel.DataAnnotations;

namespace SwapiMVC.Models.Restaurant
{
    public class RestaurantListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Display(Name = "Average Score")] // This is what will be displayed on the page, instead of the C# property name
        public double Score { get; set; }
    }
}