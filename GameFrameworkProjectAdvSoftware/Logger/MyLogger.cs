using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameworkProjectAdvSoftware.Logger
{
    /// <summary>
    /// Singleton class for logging and tracing messages within the framework
    /// </summary>
    public class MyLogger
    {
        private static readonly Lazy<MyLogger> instance = new Lazy<MyLogger>(() => new MyLogger());
        private readonly TraceSource traceSource;
        private const string LogName = "MyLog";

        // Private constructor to enforce Singleton pattern
        private MyLogger()
        {
            traceSource = new TraceSource(LogName);
            traceSource.Switch = new SourceSwitch(LogName, SourceLevels.Information.ToString());

            traceSource.Listeners.Add(new ConsoleTraceListener());
            traceSource.Listeners.Add(new TextWriterTraceListener($"{LogName}.txt")
            { Filter = new EventTypeFilter(SourceLevels.Error) });
            traceSource.Listeners.Add(new XmlWriterTraceListener($"{LogName}.xml"));
        }
        /// <summary>
        /// Logs a message at the Information level
        /// </summary>
        public void Log(string message)
        {
            traceSource.TraceEvent(TraceEventType.Information, 0, message);
            traceSource.Flush(); // Ensure immediate output to listeners
        }
        /// <summary>
        /// Gets the single instance of MyLogger
        /// </summary>
        public static MyLogger Instance => instance.Value;

        /// <summary>
        /// Logs an event with the specified type and message
        /// </summary>
        public void LogEvent(TraceEventType eventType, int eventId, string message)
        {
            traceSource.TraceEvent(eventType, eventId, message);
            traceSource.Flush();
        }

        /// <summary>
        /// Registers a new TraceListener
        /// </summary>
        public void RegisterListener(TraceListener listener)
        {
            traceSource.Listeners.Add(listener);
        }

        /// <summary>
        /// Unsubscribes (removes) a TraceListener
        /// </summary>
        public void UnregisterListener(TraceListener listener)
        {
            traceSource.Listeners.Remove(listener);
        }

        /// <summary>
        /// Stops all logging activities and closes all listeners
        /// </summary>
        public void StopLogging()
        {
            traceSource.Close();
        }
    }
}
