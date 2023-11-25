﻿using NetflixApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace NetflixApp.PageModels
{
    public class OnboardingPageModel : BasePageModel
    {
        public ObservableCollection<OnboardingModel> OnboardingModels { get; set; } = new ObservableCollection<OnboardingModel>();

        public Command NavigateToSigninCommnad { get; }

        public OnboardingPageModel()
        {
            NavigateToSigninCommnad = new Command(() =>
            {
                CoreMethods.PushPageModel<SigninPageModel>();
            });
        }

        public override void Init(object initData)
        {
            base.Init(initData);

            OnboardingModels.Add(new OnboardingModel()
            {
                Body = "Watch anywhere. Cancel anytime.",
                Title = "Unlimited movies, TV shows & more",
                ImageSource = "img1",
                IsFill = true
            });

            OnboardingModels.Add(new OnboardingModel()
            {
                Body = "Always have something to watch offline.",
                Title = "Download and watch offline",
                ImageSource = "img2",
                IsFill = false
            });

            OnboardingModels.Add(new OnboardingModel()
            {
                Body = "Join today, cancel anytime.",
                Title = "No pesky contracts",
                ImageSource = "img3",
                IsFill = false
            });

            OnboardingModels.Add(new OnboardingModel()
            {
                Body = "Stream on your phone, tablet, laptop, TV and more.",
                Title = "Watch everywhere",
                ImageSource = "img4",
                IsFill = false
            });
        }
    }
}