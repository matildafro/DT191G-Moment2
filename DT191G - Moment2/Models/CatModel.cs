using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace DT191G___Moment2.Models
{
    public class CatModel
    {
        [Required(ErrorMessage = "Namn på katten måste anges.")]
        [Display(Name = "Kattens namn:")]
        //anger att strängens längd max får vara 60 tecken lång, minst 2
		[StringLength(60, MinimumLength = 2, ErrorMessage = "Fält behöver vara minst två bokstäver.")]
		public string? Name { get; set; }

        [Required(ErrorMessage = "Kattens ras måste anges.")]
        [Display(Name = "Kattens ras:")]
		[StringLength(60, MinimumLength = 2, ErrorMessage = "Fält behöver vara minst två bokstäver.")]
		public string? Breed { get; set; }


        [Required(ErrorMessage = "Ett värde måste läggas in. Om kattens ålder är okänt, vänligen gör en gissning.")]
        [Display(Name = "Ålder:")]
        [MaxLength(2)]
        
        public string? Age { get; set; }

        [Required(ErrorMessage = "Ja eller nej måste fyllas i.")]
        [Display(Name = "Tillgänglig för adoption? ")]
        public string? Available { get; set; }

        [Required(ErrorMessage = "Ja eller nej måste fyllas i.")]
        [Display(Name = "Är katten vaccinerad? ")]
        //skapar enum Vaccinated för att kunna göra en select-lista
        public Vaccinated CatVaccinated { get; set; }

}
    //lamda expression där valalternativ från select skrivs in
    public enum Vaccinated
    {
        Ja,
        Nej,
        Okänt
    }
}
