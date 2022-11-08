﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace MrGraen
{
    internal class Card : ICard
    {
        public int Value { get; set; }
        public string Name { get; set; }
        public BitmapImage Image { get; set; }
    }
}
