using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Task2.Models
{
    public class PhoneNum
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public string CountryCode { get; set; }
        public string CityCode { get; set; }
        public string PhoneNumber { get; set; }
    }
}