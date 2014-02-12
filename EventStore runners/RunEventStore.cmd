rem Run Event Store without projections
rem   parameters : database/log name
rem
rem   RunEventStore TestData1
rem
C:\EventStore\v2.0.1\EventStore.SingleNode.exe --db=c:\EventStore\Data\%1\Data --log=c:\EventStore\Data\%1\logs --http-prefix http://*:2213/

