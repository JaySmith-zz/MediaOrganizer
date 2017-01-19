using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace FileSorter
{
    public class FileSorter
    {
        private string _sourceDirectory;
        private string _targetDirectory;

        public FileSorter(string sourceDirectory, string targetDirectory)
        {
            _sourceDirectory = sourceDirectory;
            _targetDirectory = targetDirectory;
        }

        public void PerformSort(string searchPattern)
        {
            foreach (var photoPath in Directory.EnumerateFiles(_sourceDirectory, searchPattern))
            {
                var photoFileName = new FileInfo(photoPath).Name;
                var dateTaken = new DateTime();

                using (var fs = new FileStream(photoPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    var md = (BitmapMetadata)BitmapFrame.Create(fs).Metadata;
                    if (md != null) DateTime.TryParse(md.DateTaken, out dateTaken);
                }

                var yearDirectoryName = Path.Combine(_sourceDirectory, dateTaken.Year.ToString());

                // check for year directory
                if (!Directory.Exists(yearDirectoryName)) Directory.CreateDirectory(yearDirectoryName);

                // if year directory does not exist create it
                var monthDirectoryName = string.Format("{0}", Path.Combine(yearDirectoryName, dateTaken.Month.ToString().PadLeft(2, '0')));

                // check for year/month directory
                // if year/month directory does not exist create it
                if (!Directory.Exists(monthDirectoryName)) Directory.CreateDirectory(monthDirectoryName);

                // copy image to directory
                File.Move(photoPath, string.Format("{0}\\{1}", monthDirectoryName, photoFileName));
            }

        }
    }
}