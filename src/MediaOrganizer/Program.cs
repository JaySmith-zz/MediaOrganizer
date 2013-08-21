using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace MediaOrganizer
{
    class Program
    {
        static void Main(string[] args)
        {
            string folderPath = "PhotosToOrganise";
            
            if (args.Length > 0) folderPath = args[0];
            
            foreach (var photoPath in Directory.EnumerateFiles(folderPath, "*.jpg"))
            {
                var photoFileName = new FileInfo(photoPath).Name;
                var dateTaken = new DateTime();
                
                using (var fs = new FileStream(photoPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    var md = (BitmapMetadata)BitmapFrame.Create(fs).Metadata;
                    if (md != null) DateTime.TryParse(md.DateTaken, out dateTaken);
                }

                var yearDirectoryName = Path.Combine(folderPath, dateTaken.Year.ToString());

                // check for year directory
                if (!Directory.Exists(yearDirectoryName)) Directory.CreateDirectory(yearDirectoryName);

                // if year directory does not exist create it
                var monthDirectoryName = String.Format("{0}", Path.Combine(yearDirectoryName , dateTaken.Month.ToString().PadLeft(2, '0'))); 

                // check for year/month directory
                // if year/month directory does not exist create it
                if (!Directory.Exists(monthDirectoryName)) Directory.CreateDirectory(monthDirectoryName);

                // copy image to directory
                File.Move(photoPath, String.Format("{0}\\{1}", monthDirectoryName, photoFileName));
            }

        }
    }
}
