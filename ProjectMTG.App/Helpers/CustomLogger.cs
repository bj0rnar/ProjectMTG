using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Gaming.XboxLive;
using Windows.Storage;

namespace ProjectMTG.App.Helpers
{
    //Most popular loggers comes in nugets or are third party, so this is a custom logger
    public static class CustomLogger
    {
        //Creates a new file and appends text, if file exists just append text.
        public static async Task Log(string log)
        {
            var folder = ApplicationData.Current.LocalFolder;
            var logfile = await folder.CreateFileAsync("ProjectMTGLogFile.txt", CreationCollisionOption.OpenIfExists);
            //Debug.WriteLine(logfile.Path);
            await FileIO.AppendTextAsync(logfile, log + Environment.NewLine);
            //Debug.WriteLine(logfile.Path.ToString());
        }
    }
}
