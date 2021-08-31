using System;

namespace iQuest.VendingMachine.PresentationLayer.Views.Interfaces
{
    internal interface IReportsView
    {
        void TellFileFormat(string format);
        void CreatedMessage(string option, string reportsFolder);
        DateTime AskForADate(string dateTime);
    }
}