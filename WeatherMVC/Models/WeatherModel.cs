using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Weather.bll;

namespace WeatherMVC.Models
{
    public class WeatherModel
    {
        [Required]
        [StringLength(30, ErrorMessage = "The longest city in the world by name is located in Thailand ( with 163 chars), but we will limit ourselves to 30 char")]
        [RegularExpression("[a-zA-Z][a-zA-Z ]+", ErrorMessage = "Only alphabet please!")]
        public string CityName { get; set; }

        public WeatherDataModel WeatherData { get; set; }
    }
}