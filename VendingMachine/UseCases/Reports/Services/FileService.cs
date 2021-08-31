using iQuest.VendingMachine.UseCases.Reports.Interfaces;
using System.IO;
using System.IO.Compression;

namespace iQuest.VendingMachine.UseCases.Reports.Services
{
    internal class FileService : IFileService
    {
        public void Save(string textToWrite, string format, string folderName, string name)
        {
            string path = $@"D:\Programing\BitBucket\Remote Learning\Homework5\Vending Machine\VendingMachine\UseCases\Reports\SerializedObjects\{format}\{folderName}\{name}.zip";

            using (var zipToOpen = new MemoryStream())
            {
                using (var reportsArchive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
                {
                    var newReportFile = reportsArchive.CreateEntry($"{name}.{format.ToLower()}");

                    using (var writingStream = newReportFile.Open())

                    using (var writer = new StreamWriter(writingStream))
                    {
                        writer.Write(textToWrite);
                    }
                }

                IZippedReportFileStream zippedReportClass = new ZippedReportFileStream(path);

                var bytesArray = zipToOpen.GetBuffer();
                zippedReportClass.Write(bytesArray, 0, bytesArray.Length);
            }
        }
    }
}

/*                                           If we only want to make the reports in .zip format :                        
 *                  HERE IS ANOTHER IMPLEMENTATION MUCH SIMPLIER AND SHORTER BUT WITHOUT USING THE CLASS THAT WE WERE ASKED TO IMPLEMENT        
 *   but maybe this class have some other role , or will have in the future and I am just not seeing it now , so I implemented a solution with that class also 
 * 
 * 
 * 
 * 
 *  public void Save(string filePath, string textToWrite, string format, string folderName, string name)
        {
            using (FileStream zipToOpen = new FileStream($@"C:\Users\OMEN\Desktop\Vending Machine\VendingMachine\UseCases\Reports\SerializedObjects\{format}\{folderName}\{name}.zip", FileMode.CreateNew))
            {
                using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
                {
                    ZipArchiveEntry readmeEntry = archive.CreateEntry($"{name}.{format.ToLower()}");
                    using (StreamWriter writer = new StreamWriter(readmeEntry.Open()))
                    {
                        writer.Write(textToWrite);                  
                    }
                }
            }

        }

*/
