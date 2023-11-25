using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NetflixApp.Models
{
    public class OnboardingModel 
    {
        public string Title {  get; set; }
        public string Body { get; set; }
        public string ImageSource { get; set; }
        public bool IsFill {  get; set; }
    }
}
