using AxelPIGNOL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxelPIGNOL
{
    public partial class BeerDetailPage : ContentPage
    {
        public BeerDetailPage(Beer beer)
        {
            InitializeComponent();
            BindingContext = beer;
        }
    }
}
