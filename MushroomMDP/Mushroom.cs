using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MushroomMDP
{
    public class Mushroom
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ImageSource Image { get; set; }
        public string WikiUri { get; set; }
        public bool Toxic { get; set; }
        public ContentPage TargetPage { get; set; }
    }
}
