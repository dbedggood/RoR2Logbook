using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RoR2Logbook.Pages
{
    public class AboutModel : PageModel
    {
        public string ror2 { get; set; }
        public string who { get; set; }
        public string why { get; set; }
        public string how1 { get; set; }
        public string how2 { get; set; }

        public void OnGet()
        {
            ror2 = "Risk of Rain 2 is a 3D multiplayer third-person shooter roguelike video game developed by Hopoo Games and published by Gearbox Publishing. It is the sequel to Risk of Rain, released in an early access version on March 28, 2019, on Steam for Microsoft Windows.";
            who = "My name is Daniel Bedggood. I am a kiwi computer science student at the University of Auckland, graduating around June 2019. I love video games and I enjoy coding up random projects in my spare time. If you want to have a look at my other projects, my github account is ";
            why = "The original Risk of Rain was the game that first got me interested in roguelikes, I played it a lot back in 2013 when it came out and I still come back to it every now and then. Risk of rain 2 is an amazing sequel that somehow keeps the core mechanics of the game, and makes it all work in 3D. Long story short, I'm in love with this game and I wanted to make something to practice my web development skills.";
            how1 = "This project is made with ASP.NET Core Razor Pages and is hosted on Azure. I started off following the Razor Pages tutorial ";
            how2 = ", then started doing my own thing after I figured out how it all worked. I created this project in the Visual Studio 2019 Community IDE on Windows.";
    }
    }
}
