using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Foundation;
using UIKit;

namespace Todoer.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {

            // Copy the database across (if it doesn't exist)
            //var appdir = NSBundle.MainBundle.ResourcePath;
            //var seedFile = Path.Combine(appdir, "projects.sqlite");
            //string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            //string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder instead

            //var path = Path.Combine(libraryPath, "projects.sqlite");

            //if (!File.Exists(seedFile))
            //{
            //    File.Copy(seedFile, path);
            //}

            Xamarin.Calabash.Start();
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
