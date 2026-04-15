namespace SklepPB.Models.ViewModels
{
    public class AddFilmViewModel
    {
        public List<Category> Categories { get; set; }

        public Film Film { get; set; }

        public IFormFile Poster { get; set; }
    }
}
