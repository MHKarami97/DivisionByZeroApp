﻿using System.Collections.Generic;
using MvvmCross;
using MyApp.Helpers;
using MyApp.Services;
using Xamarin.Essentials;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace MyApp.ViewModels
{
    public class AboutViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public AboutViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            Version = Mvx.IoCProvider.Resolve<ILocalizeService>().Translate("Version") + " " + VersionTracking.CurrentVersion;
        }

        #region Property

        public string Version { get; set; }

        #endregion

        #region Events

        public IMvxAsyncCommand ToolbarSearchCommand =>
            new MvxAsyncCommand(async () =>
            {
                await _navigationService.Navigate<SearchViewModel>();
            });

        public IMvxAsyncCommand ToolbarHomeCommand =>
            new MvxAsyncCommand(async () =>
            {
                await _navigationService.Navigate<RootViewModel>();
            });

        public IMvxCommand CallByPhoneCommand =>
            new MvxCommand(() =>
            {
                PhoneDialer.Open(989390709197.ToString());

                //Device.OpenUri(new Uri("tel://989390709197"));
            });

        public IMvxAsyncCommand CallByEmailCommand =>
            new MvxAsyncCommand(async () =>
            {
                var message = new EmailMessage
                {
                    Subject = "contact us",
                    Body = "hello",
                    To = new List<string> { "mhkarami1997@gmail.com" },
                    //Cc = ccRecipients,
                    //Bcc = bccRecipients
                };
                await Email.ComposeAsync(message);

                //Device.OpenUri(new Uri("mailto:mhkarami1997@gmail.com"));
            });

        #endregion
    }
}