using System.ComponentModel.DataAnnotations;

namespace CityBreaks.Models
{
    public enum Rating
    {
        Unrated,
        [Display(Name = "1 Star")]
        OneStar,
        [Display(Name = "2 Star")]
        TwoStar,
        [Display(Name = "3 Star")]
        ThreeStar,
        [Display(Name = "4 Star")]
        FourStar,
        [Display(Name = "5 Star")]
        FiveStar
    }
}
