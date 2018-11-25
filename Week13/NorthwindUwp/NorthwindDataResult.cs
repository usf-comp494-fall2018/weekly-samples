using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace NorthwindUwp
{
    public class NorthwindDataResult
    {
        public NorthwindDataResult()
        {
            ImagePath = "ms-appx:///Assets/Blank.png";
        }

        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string DisplayDetails { get; set; }
        public string ImagePath { get; set; }
    }
}
