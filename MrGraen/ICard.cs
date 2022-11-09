using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace MrGraen
{
    internal interface ICard
    {
        int Value { get; set; }
        string Name { get; set; }
        BitmapImage Image { get; set; }
    }
}
