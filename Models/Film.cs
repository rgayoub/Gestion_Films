namespace EFM_MVC.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Réalisateur { get; set; }
        public DateTime DateDeSortie { get; set; }
        public string Synopsis { get; set; }
        public string Affiche { get; set; } 
        public string BandeAnnonce { get; set; } 
    }
   
}
