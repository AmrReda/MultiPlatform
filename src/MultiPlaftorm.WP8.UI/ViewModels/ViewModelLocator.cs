﻿/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:MultiPlatform.WP8.UI.ViewModels"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using MultiPlatform.WP8.UI.Services;


namespace MultiPlatform.WP8.UI.ViewModels
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MultiPlatform.Domain.Interfaces.INavigation<MultiPlatform.Domain.Interfaces.NavigationModes>, UiNavigation>();
            SimpleIoc.Default.Register<MultiPlatform.Domain.Interfaces.IStorage, MultiPlatform.Shared.Services.UiStorage>();
            SimpleIoc.Default.Register<MultiPlatform.Domain.Interfaces.IUx, MultiPlatform.Shared.Services.UiUx>();
            SimpleIoc.Default.Register<MultiPlatform.Domain.Interfaces.ILocation, MultiPlatform.Shared.Services.LocationService>();
          
            SimpleIoc.Default.Register<Domain.ViewModels.Home>();
            SimpleIoc.Default.Register<Domain.ViewModels.Details>();
            SimpleIoc.Default.Register<Domain.ViewModels.Login>();
            SimpleIoc.Default.Register<Domain.ViewModels.Map>();
         
        }

        public Domain.ViewModels.Home Home
        {
            get
            {
                return ServiceLocator.Current.GetInstance<Domain.ViewModels.Home>();
            }
        }

        public Domain.ViewModels.Details Details
        {
            get
            {
                return ServiceLocator.Current.GetInstance<Domain.ViewModels.Details>();
            }
        }

        public Domain.ViewModels.Login Login
        {
            get
            {
                return ServiceLocator.Current.GetInstance<Domain.ViewModels.Login>();
            }
        }

        public Domain.ViewModels.Map Map
        {
            get
            {
                return ServiceLocator.Current.GetInstance<Domain.ViewModels.Map>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}