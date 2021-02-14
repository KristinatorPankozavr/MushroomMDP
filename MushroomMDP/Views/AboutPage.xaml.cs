using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MushroomMDP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        private Mushroom mushroom;
        public AboutPage(Mushroom _mushroom)
        {
            mushroom = _mushroom;
            InitializeComponent();
            Title = mushroom.Title;
            titleLabel.Text = mushroom.Title;
            mushroomImage.Source = mushroom.Image;
            descriptionLabel.Text = mushroom.Description;
            if (mushroom.Toxic)
            {
                toxicLabel.IsVisible = true;   
            }
        }

        private async void wikiButton_Clicked(object sender, EventArgs e)
        {
            await Browser.OpenAsync(mushroom.WikiUri);
        }
    }
}