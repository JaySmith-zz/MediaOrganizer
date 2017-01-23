using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using Geocoding.Google;
using MetadataExtractor;
using Directory = System.IO.Directory;

namespace FileSorter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonMerge_Click(object sender, EventArgs e)
        {
            if (buttonMerge.Tag.ToString() == "Idle")
            {
                buttonMerge.Tag = "Running";
                buttonMerge.Text = "Cancel Sort";
                if (backgroundWorkerSort.IsBusy == true) return;
                backgroundWorkerSort.RunWorkerAsync();
            }
            else if (buttonMerge.Tag.ToString() == "Running")
            {
                if (!backgroundWorkerSort.IsBusy) return;
                buttonMerge.Tag = "Idle";
                buttonMerge.Text = "Begin Sort";
                backgroundWorkerSort.CancelAsync();
            }
        }

        private void backgroundWorkerSort_DoWork(object sender, DoWorkEventArgs e)
        {
            if (backgroundWorkerSort.CancellationPending == true)
            {
                e.Cancel = true;
            }

            PerformSort();
        }

        private void backgroundWorkerSort_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            AddListViewMessage(e.UserState.ToString());
        }

        private void backgroundWorkerSort_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            AddListViewMessage("Complete...");
            buttonMerge.Tag = "Idle";
            buttonMerge.Text = buttonMerge.Text = "Begin Sort";
        }

        private void AddListViewMessage(string message)
        {
            listViewMessages.Items.Add(new ListViewItem
            {
                Text = message
            });
            listViewMessages.Items[listViewMessages.Items.Count - 1].EnsureVisible();
            listViewMessages.Refresh();
        }

        public void PerformSort()
        {
            var sourceFiles = Directory.EnumerateFiles(textBoxSourceFolder.Text, textBoxSearchPattern.Text);

            foreach (var sourceFile in sourceFiles)
            {
                if (backgroundWorkerSort.CancellationPending) return;

                var sourceFilename = new FileInfo(sourceFile).Name;
                var dateTaken = new DateTime();

                using (var fs = new FileStream(sourceFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    var metadata = (BitmapMetadata)BitmapFrame.Create(fs).Metadata;
                    if (metadata != null) DateTime.TryParse(metadata.DateTaken, out dateTaken);

                    if (dateTaken == DateTime.MinValue)
                    {
                        var fileInfo = new FileInfo(sourceFile);
                        dateTaken = fileInfo.LastWriteTime;
                    }
                }

                
                var targetDirectoryWithYear = Path.Combine(textBoxTargetFolder.Text, dateTaken.Year.ToString());
                if (!Directory.Exists(targetDirectoryWithYear)) Directory.CreateDirectory(targetDirectoryWithYear);

                var targetDirectoryWithYearAndMonth = string.Format("{0}", Path.Combine(targetDirectoryWithYear, dateTaken.Month.ToString().PadLeft(2, '0')));
                if (!Directory.Exists(targetDirectoryWithYearAndMonth)) Directory.CreateDirectory(targetDirectoryWithYearAndMonth);

                var imageLocation = GetImageLocation(sourceFile);
                var targetDirectoryWithYearAndMonthAndLocation = targetDirectoryWithYearAndMonth;
                if (!string.IsNullOrEmpty(imageLocation))
                {
                    targetDirectoryWithYearAndMonthAndLocation = Path.Combine(targetDirectoryWithYearAndMonth, imageLocation);
                    if (!Directory.Exists(targetDirectoryWithYearAndMonthAndLocation))
                        Directory.CreateDirectory(targetDirectoryWithYearAndMonthAndLocation);
                }

                var targetDirectoryWithYearAndMonthAndLocationAndFilename = string.Format("{0}\\{1}",
                    targetDirectoryWithYearAndMonthAndLocation, sourceFilename);

                File.Copy(sourceFile, targetDirectoryWithYearAndMonthAndLocationAndFilename, true);

                var progressText = string.Format(@"File {0} copied", sourceFilename);
                backgroundWorkerSort.ReportProgress(0, progressText);
            }
        }

        private string GetImageLocation(string sourceDirectoryFile)
        {
            var location = string.Empty;

            //try
            //{
            //    var imageMetaData = ImageMetadataReader.ReadMetadata(sourceDirectoryFile);
            //    var directory = imageMetaData.FirstOrDefault(x => x.Name == "GPS");

            //    if (directory == null) return location;

            //    var tags = directory.Tags;
            //    var gpsLatitudeDegrees = tags.First(x => x.Name == "GPS Latitude").Description;
            //    //var gpsLatitudeHemisphere = tags.First(x => x.Name == "GPS Latitude Ref").Description;
            //    var latitude = ConvertDegreeAngleToDouble(gpsLatitudeDegrees);

            //    var gpsLongitude = tags.First(x => x.Name == "GPS Longitude").Description;
            //    //var gpsLongitudeHemisphere = tags.First(x => x.Name == "GPS Longitude Ref").Description;
            //    var longitude = ConvertDegreeAngleToDouble(gpsLongitude);

            //    var geoCoder = new GoogleGeocoder() { ApiKey = Properties.Settings.Default.GeoCodeApiKey };
            //    var result = geoCoder.ReverseGeocode(latitude, longitude).First();

            //    var state = result.Components[5].LongName;
            //    var city = result.Components[2].LongName;

            //    location = string.Format("{0}, {1}", city, state);
            //}
            //catch
            //{
            //   // Ignore
            //}

            return location;
        }

        private static double ConvertDegreeAngleToDouble(string location)
        {
            var elements = location.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            var degrees = double.Parse(elements[0].Replace("°", null));
            var minutes = double.Parse(elements[1].Replace("\'", null));
            var seconds = double.Parse(elements[2].Replace("\"", null));

            var result = degrees + (minutes / 60) + (seconds / 3600);

            //if (hemisphere == "W" || hemisphere == "S")
            //    result = result * -1;

            return result;
        }

        private void buttonSelectSourceFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Description = "Open source folder";
            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
            {
                textBoxSourceFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void buttonTargetFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Description = "Open target folder";
            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
            {
                textBoxTargetFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
