namespace MyApp.Models
{
    public class CarouselModel
    {
        public CarouselModel(string imageString)
        {
            Image = imageString;
        }

        private string _image;

        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }
    }
}