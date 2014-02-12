using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using EventStore.ClientAPI;
using EventStore.ClientAPI.Common.Log;
using EventStore.ClientAPI.Common.Utils;
using EventStore.ClientAPI.SystemData;

namespace EventStore.Console
{
    class Program
    {
        private const int _tcpIpPort = 1113;
        private const int _httpPort = 2213;

        static void Main(string[] args)
        {
            var tcpEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), _tcpIpPort);
            var httpEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), _httpPort);

            ConsoleKeyInfo keypressed;

            do
            {
                System.Console.Clear();
                System.Console.WriteLine("\r\nMenu : ");
                System.Console.WriteLine("  1. Get projections.");
                System.Console.WriteLine("  2. Add sessions, as on first published agenda.");
                System.Console.WriteLine("  3. Add updated sessions.");
                System.Console.WriteLine("  4. Get sessions for Room 109.");
                System.Console.WriteLine("  0. Quit\r\n");
                
                keypressed = System.Console.ReadKey();
                
                System.Console.WriteLine("\r\n\r\n");

                switch (keypressed.KeyChar)
                {
                    case '1':
                        GetProjections(httpEndPoint);
                        System.Console.ReadKey();
                        break;
                    case '2':
                        AddInitialSessions(tcpEndPoint, SessionInfo.conferenceName);
                        System.Console.ReadKey();
                        break;
                    case '3':
                        AddUpdatedSessions(tcpEndPoint, SessionInfo.conferenceName);
                        System.Console.ReadKey();
                        break;
                    case '4':
                        GetEvents(tcpEndPoint, SessionInfo.room109);
                        System.Console.ReadKey();
                        break;
                    default:
                        System.Console.WriteLine("Unknown menu item : " + keypressed.KeyChar);
                        break;
                }            
                
            } while (keypressed.KeyChar != '0');

        }

        private static void GetProjections(IPEndPoint httpEndPoint)
        {
            var projectionsManager = new ProjectionsManager(new NoopLogger(), httpEndPoint);
            String allProjections = projectionsManager.ListAll(new UserCredentials("admin", "changeit"));
            System.Console.WriteLine(allProjections);

            // String byRoom = projectionsManager.GetQuery("Sessions-ByRoom", new UserCredentials("admin", "changeit"));
        }

        private static void AddInitialSessions(IPEndPoint tcpEndPoint, string conferenceName)
        {
            List<SessionInfo> allSessions = SessionInfo.GetAllSessions();
            AddSessions(tcpEndPoint, conferenceName, allSessions);
        }

        private static void AddUpdatedSessions(IPEndPoint tcpEndPoint, string conferenceName)
        {
            List<SessionInfo> allSessions = SessionInfo.GetUpdatedSessions();
            AddSessions(tcpEndPoint, conferenceName, allSessions);
        }

        private static void AddSessions(IPEndPoint tcpEndPoint, string conferenceName, List<SessionInfo> sessionInfoList)
        {
            using (var eventStoreConnection = EventStoreConnection.Create(tcpEndPoint))
            {
                eventStoreConnection.Connect();

                var eventDataForAllSessions = new List<EventData>();

                const bool isJsonFormat = true;
                byte[] noMetaData = null;

                foreach (var session in sessionInfoList)
                {
                    var json = session.ToJsonBytes();
                    eventDataForAllSessions.Add(new EventData(Guid.NewGuid(), "Session", isJsonFormat, json, noMetaData));
                }
                eventStoreConnection.AppendToStream(conferenceName, ExpectedVersion.Any, eventDataForAllSessions);
            }

            System.Console.WriteLine(String.Format("Added {0} sessions to Event Store stream {1}.\r\n", sessionInfoList.Count, conferenceName));
        }

        private static void GetEvents(IPEndPoint tcpEndPoint, string roomName)
        {
            const bool resolveLinkTosAsWeOnlyStoreOneInstanceOfEventData = true;

            using (var eventStoreConnection = EventStoreConnection.Create(tcpEndPoint))
            {
                eventStoreConnection.Connect();

                StreamEventsSlice stream = eventStoreConnection.ReadStreamEventsBackward("Room-" + roomName, 
                    -1, int.MaxValue, resolveLinkTosAsWeOnlyStoreOneInstanceOfEventData);
                Dictionary<String, SessionInfo> sessionList = new Dictionary<String, SessionInfo>();

                foreach (ResolvedEvent ev in stream.Events)
                {
                    System.Console.WriteLine(
                        String.Format("Event number in projection: {0}, Real Event Number in original stream : {1}",
                                      ev.OriginalEventNumber, 
                                      ev.Event.EventNumber));

                    SessionInfo si = ev.Event.Data.ParseJson<SessionInfo>();
                    if (!sessionList.ContainsKey(si.StartTime)) sessionList.Add(si.StartTime, si);
                }

                var sessionsInOrder = (from SessionInfo si in sessionList.Values orderby si.StartTime select si).ToList<SessionInfo>();

                System.Console.WriteLine(String.Format("Sessions for room {0}", roomName));
                foreach (SessionInfo session in from SessionInfo si in sessionList.Values orderby si.StartTime select si)
                {
                    System.Console.WriteLine(String.Format("  {0}-{1} {2} ({3})", session.StartTime, session.EndTime, session.Title, session.Speaker));
                }
            }
        }
    }
}
