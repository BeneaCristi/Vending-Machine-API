namespace iQuest.VendingMachine.UseCases.Reports.Interfaces
{
    internal interface IFileService
    {
        void Save(string textToWrite, string format, string folderName, string name);
    }
}