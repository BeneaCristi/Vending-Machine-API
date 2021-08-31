using System.Diagnostics;

namespace iQuest.VendingMachine.ProgramConfiguration
{
    internal class EventViewerErrorWriter : IEventViewerErrorWriter
    {
        private int eventID = 1;

        public void EventLogger(string message)
        {
            EventLog eventLog = new EventLog();

            if(!EventLog.SourceExists("Vending-Machine"))
            {
                EventLog.CreateEventSource("Vending-Machine", "Application");
            }

            eventLog.Source = "Vending-Machine";

            for(;;)
            {
                eventLog.WriteEntry(message, EventLogEntryType.Error, eventID);
                eventID++;
                break;
            }  

            eventLog.Close();
        }
    }
}
