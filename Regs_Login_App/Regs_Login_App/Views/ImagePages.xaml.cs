﻿using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Regs_Login_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImagePages : ContentPage
    {
        public ImagePages()
        {

            InitializeComponent();
        }

        
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsTakePhotoSupported && !CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Message", "Photo Capture and Pick not Supported", "Ok");
                return;
            }
            else
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    Directory = "Pictures",
                    Name = "test"
                });
                if (file == null)
                {
                    return;
                }
                await DisplayAlert("File Path", file.Path, "Ok");

                MyImage.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    return stream;
                });

            }
        }
    }
    
}