namespace SndMauiApp
{
    public partial class MainPage : ContentPage
    {
        int catCounter = 1;
        int dogCounter = 0;
        public MainPage()
        {
            InitializeComponent();
        }

        private void ShowCat(object sender, EventArgs e)
        {
            if (!CatImage.IsVisible)
            {
                catCounter++;
                DogImage.IsVisible = false;
                CatImage.IsVisible = true;
                animalText.Text = $"Du har tittat på katten {catCounter} gånger, du har tittat på hunden {dogCounter} gånger";
            }
        }
        private void ShowDog(object sender, EventArgs e)
        {
            if (!DogImage.IsVisible)
            {
                dogCounter++;
                CatImage.IsVisible = false;
                DogImage.IsVisible = true;
                animalText.Text = $"Du har tittat på katten {catCounter} gånger, du har tittat på hunden {dogCounter} gånger";
            }
        }
    }
}
