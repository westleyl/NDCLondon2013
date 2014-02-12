using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStore.Console
{
    class SessionInfo
    {
        public string Conference { get; set; }
        public string Room { get; set; }
        public string Title { get; set; }
        public string Speaker { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public const string conferenceName = "DDDNorth3";

        public const string room107 = "007 (Prospect)";
        public const string roomTCLT = "TCLT (Prospect)";
        public const string room009 = "009 (Prospect)";
        public const string room108 = "108 (DGIC)";
        public const string room109 = "109 (DGIC)";

        public static List<SessionInfo> GetAllSessions()
        {
            string startTime;
            string endTime;

            List<SessionInfo> allSessions = new List<SessionInfo>();

            startTime = "09:30";
            endTime = "10:30";

            allSessions.Add(new SessionInfo { Conference = conferenceName, StartTime = startTime, EndTime = endTime,
                Room = room107, Title = "Using HTML5 to Build Desktop Software", Speaker = "Kevin Boyle" } );
            allSessions.Add(new SessionInfo { Conference = conferenceName, StartTime = startTime, EndTime = endTime,
                Room = roomTCLT, Title = "TDD Where Did It All Go Wrong?", Speaker = "Ian Cooper" } );
            allSessions.Add(new SessionInfo { Conference = conferenceName, StartTime = startTime, EndTime = endTime,
                Room = room009, Title = "F# Eye for the C# Guy", Speaker = "Phillip Trelford" } );
            allSessions.Add(new SessionInfo { Conference = conferenceName, StartTime = startTime, EndTime = endTime,
                Room = room108, Title = "Making 3D Games With Monogame", Speaker = "Richard Garside" } );
            allSessions.Add(new SessionInfo { Conference = conferenceName, StartTime = startTime, EndTime = endTime,
                Room = room109, Title = "CQRS From The Trenches", Speaker = "Ashic Mahtab" } );

            startTime = "10:50";
            endTime = "11:50";

            allSessions.Add(new SessionInfo { Conference = conferenceName, StartTime = startTime, EndTime = endTime,
                Room = room107, Title = "Cross-platform Mobile Development in Visual Studio", Speaker = "Bart Read" } );
            allSessions.Add(new SessionInfo { Conference = conferenceName, StartTime = startTime, EndTime = endTime,
                Room = roomTCLT, Title = "Scaling Systems Architectures That Grow", Speaker = "Kendall Miller" } );
            allSessions.Add(new SessionInfo { Conference = conferenceName, StartTime = startTime, EndTime = endTime,
                Room = room009, Title = "Hadoop Kickstarter", Speaker = "Gary Short" } );
            allSessions.Add(new SessionInfo { Conference = conferenceName, StartTime = startTime, EndTime = endTime,
                Room = room108, Title = "UI For Developers (AKA Getting Started with Twitter Bootstrap in .NET", Speaker = "Peter Shaw" } );
            allSessions.Add(new SessionInfo { Conference = conferenceName, StartTime = startTime, EndTime = endTime,
                Room = room109, Title = "Gadgeteer, Signal R, Web API and Windows Azure - Challenges of the .Net Micro Framework", Speaker = "Steve Spencer" } );

            startTime = "12:10";
            endTime = "13:10";

            allSessions.Add(new SessionInfo { Conference = conferenceName, StartTime = startTime, EndTime = endTime,
                Room = room107, Title = "Automated Build Is Not The End Of The Story", Speaker = "Richard Fennell" } );
            allSessions.Add(new SessionInfo { Conference = conferenceName, StartTime = startTime, EndTime = endTime,
                Room = roomTCLT, Title = "It's Up To Us!", Speaker = "Amy Lynch" } );
            allSessions.Add(new SessionInfo { Conference = conferenceName, StartTime = startTime, EndTime = endTime,
                Room = room009, Title = "WTFP?! Functional Programming and why you should care, with examples in F#	", Speaker = "Grant Crofton" } );
            allSessions.Add(new SessionInfo { Conference = conferenceName, StartTime = startTime, EndTime = endTime,
                Room = room108, Title = "Cross Platform Mobile Development in C#", Speaker = "Ross Dargan" } );
            allSessions.Add(new SessionInfo { Conference = conferenceName, StartTime = startTime, EndTime = endTime,
                Room = room109, Title = "You've Got Your Compiler In My Service", Speaker = "Matthew Steeples" } );
          
            startTime = "14:35";
            endTime = "15:35";

            allSessions.Add(new SessionInfo { Conference = conferenceName, StartTime = startTime, EndTime = endTime,
                Room = room107, Title = "Single Page Apps With AngularJS", Speaker = "Mauro Servienti" } );
            allSessions.Add(new SessionInfo { Conference = conferenceName, StartTime = startTime, EndTime = endTime,
                Room = roomTCLT, Title = "Tyrannosaurus Rx: Slaying the Event-Driven Sauropod with Reactive Extensions for .Net", Speaker = "John Stovin" } );
            allSessions.Add(new SessionInfo { Conference = conferenceName, StartTime = startTime, EndTime = endTime,
                Room = room009, Title = "MongoDB for the C# Developer", Speaker = "Simon Elliston Ball" } );
            allSessions.Add(new SessionInfo { Conference = conferenceName, StartTime = startTime, EndTime = endTime,
                Room = room108, Title = "An Introduction to Octopus Deployment", Speaker = "Joel Hammond-Turner" } );
            allSessions.Add(new SessionInfo { Conference = conferenceName, StartTime = startTime, EndTime = endTime,
                Room = room109, Title = "The Joy of Wires: An Introduction to Netduino, .NET Micro Framework and the Internet of Things", Speaker = "Iain Angus" } );

            startTime = "15:55";
            endTime = "16:55";

            allSessions.Add(new SessionInfo { Conference = conferenceName, StartTime = startTime, EndTime = endTime,
                Room = room107, Title = "Cross Platform Continuous Delivery: Web, Mobile and Desktop - A Grand Unified Thoery", Speaker = "Justin Caldicott" } );
            allSessions.Add(new SessionInfo { Conference = conferenceName, StartTime = startTime, EndTime = endTime,
                Room = roomTCLT, Title = "Testing Crap in Web Applications Like ASP.Net MVC", Speaker = "Rob Ashton" } );
            allSessions.Add(new SessionInfo { Conference = conferenceName, StartTime = startTime, EndTime = endTime,
                Room = room009, Title = "EventStore - an Introduction to a DSD for Event Sourcing and Notifications", Speaker = "Liam Westley" } );
            allSessions.Add(new SessionInfo { Conference = conferenceName, StartTime = startTime, EndTime = endTime,
                Room = room108, Title = "Panic Driven Development: Creating a DDD Web Site from Scratch, Just in the Nick Of Time", Speaker = "Alastair Smith" } );
            allSessions.Add(new SessionInfo { Conference = conferenceName, StartTime = startTime, EndTime = endTime,
                Room = room109, Title = "You've learnt the basics of F#: What's next?", Speaker = "Ian Russell" } );

            return allSessions;
        }

        public static List<SessionInfo> GetUpdatedSessions()
        {
            string startTime;
            string endTime;

            List<SessionInfo> allSessions = new List<SessionInfo>();

            startTime = "09:30";
            endTime = "10:30";

            allSessions.Add(new SessionInfo { Conference = conferenceName, StartTime = startTime, EndTime = endTime,
                Room = room109, Title = "TFS Lab Management War Stories", Speaker = "Rik Hepworth" } );

            return allSessions;
        }
    }
}
