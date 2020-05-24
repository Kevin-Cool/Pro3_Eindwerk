using System;
using System.Collections.Generic;
using System.Text;
using DataLayer;
using DomainLibrary;
using DomainLibrary.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
namespace UnitTestProject
{
    [TestClass]
    public class TrainingManagerTest
    {
        private DomainController DC;
        private CyclingSession _cycling = new CyclingSession(new DateTime(2020, 4, 21, 16, 00, 00), 40, new TimeSpan(1, 20, 00), 30, null, TrainingType.Endurance, null, BikeType.RacingBike);
        private RunningSession _running = new RunningSession(new DateTime(2020, 4, 17, 12, 30, 00), 5000, new TimeSpan(0, 27, 17), null, TrainingType.Endurance, null);

        [TestInitialize]
        public void SetUp()
        {
            DC = new DomainController(new UnitOfWork(new TrainingContextTest(false)));
        }



        [TestMethod]
        public void DomainController_AddCyclingTrainings_CreatesCyclingTrainging()
        {
            //CyclingSession cycle2 = new CyclingSession(new DateTime(2020, 4, 18, 18, 00, 00), 40, new TimeSpan(1, 42, 00), null, null, TrainingType.Recuperation, null, BikeType.RacingBike);
            //CyclingSession cycle3 = new CyclingSession(new DateTime(2020, 4, 19, 16, 45, 00), null, new TimeSpan(1, 0, 00), null, 219, TrainingType.Interval, "5x5 min 270", BikeType.IndoorBike);

            DC.AddCyclingTraining(new DateTime(2020, 4, 21, 16, 00, 00), 40, new TimeSpan(1, 20, 00), 30, null, TrainingType.Endurance, null, BikeType.RacingBike);

            DC.GetAllCyclingSessions()[0].When.Should().Be(_cycling.When);
            DC.GetAllCyclingSessions()[0].Distance.Should().Be(_cycling.Distance);
            DC.GetAllCyclingSessions()[0].Time.Should().Be(_cycling.Time);
            DC.GetAllCyclingSessions()[0].AverageSpeed.Should().Be(_cycling.AverageSpeed);
            DC.GetAllCyclingSessions()[0].AverageWatt.Should().Be(_cycling.AverageWatt);
            DC.GetAllCyclingSessions()[0].TrainingType.Should().Be(_cycling.TrainingType);
            DC.GetAllCyclingSessions()[0].Comments.Should().Be(_cycling.Comments);
            DC.GetAllCyclingSessions()[0].BikeType.Should().Be(_cycling.BikeType);

        }
        [TestMethod]
        public void DomainController_AddRunningTrainings_CreatesRunningTrainging()
        {

            //DC.AddRunningTraining(new DateTime(2020, 4, 19, 12, 30, 00), 5000, new TimeSpan(0, 25, 48), null, TrainingType.Endurance, null);
            //DC.AddRunningTraining(new DateTime(2020, 3, 17, 11, 0, 00), 5000, new TimeSpan(0, 28, 10), null, TrainingType.Interval, "3x700m");
            //DC.AddRunningTraining(new DateTime(2020, 3, 17, 11, 0, 00), 8000, new TimeSpan(0, 42, 10), null, TrainingType.Endurance, null);

            DC.AddRunningTraining(new DateTime(2020, 4, 17, 12, 30, 00), 5000, new TimeSpan(0, 27, 17), null, TrainingType.Endurance, null);

            DC.GetAllRunningSessions()[0].When.Should().Be(_running.When);
            DC.GetAllRunningSessions()[0].Distance.Should().Be(_running.Distance);
            DC.GetAllRunningSessions()[0].Time.Should().Be(_running.Time);
            DC.GetAllRunningSessions()[0].AverageSpeed.Should().Be(_running.AverageSpeed);
            DC.GetAllRunningSessions()[0].TrainingType.Should().Be(_running.TrainingType);
            DC.GetAllRunningSessions()[0].Comments.Should().Be(_running.Comments);
        }
        [TestMethod]
        public void DomainController_GetMontlyRunningReport_ReceivedRunningReport()
        {
            DC.AddRunningTraining(new DateTime(2020, 4, 17, 12, 30, 00), 5000, new TimeSpan(0, 27, 17), null, TrainingType.Endurance, null);
           
            var montlyRunning = DC.GetMonlyRunningReport(2020,4).TimeLine;

            RunningSession tempRunn = (RunningSession)montlyRunning[0].Item2;

            tempRunn.When.Should().Be(_running.When);
            tempRunn.Distance.Should().Be(_running.Distance);
            tempRunn.Time.Should().Be(_running.Time);
            tempRunn.AverageSpeed.Should().Be(_running.AverageSpeed);
            tempRunn.TrainingType.Should().Be(_running.TrainingType);
            tempRunn.Comments.Should().Be(_running.Comments);

        }
        [TestMethod]
        public void DomainController_GetMontlyCyclingReport_ReceivedCyclingReport()
        {
            DC.AddCyclingTraining(new DateTime(2020, 4, 21, 16, 00, 00), 40, new TimeSpan(1, 20, 00), 30, null, TrainingType.Endurance, null, BikeType.RacingBike);

            var montlycycling = DC.GetMonlyCyclingReport(2020, 4).TimeLine;

            CyclingSession tempCycle = (CyclingSession)montlycycling[0].Item2;

            tempCycle.When.Should().Be(_cycling.When);
            tempCycle.Distance.Should().Be(_cycling.Distance);
            tempCycle.Time.Should().Be(_cycling.Time);
            tempCycle.AverageSpeed.Should().Be(_cycling.AverageSpeed);
            tempCycle.AverageWatt.Should().Be(_cycling.AverageWatt);
            tempCycle.TrainingType.Should().Be(_cycling.TrainingType);
            tempCycle.Comments.Should().Be(_cycling.Comments);
            tempCycle.BikeType.Should().Be(_cycling.BikeType);

        }
        [TestMethod]
        public void DomainController_GetMontlyReport_ReceivedMontlyReport()
        {
            DC.AddCyclingTraining(new DateTime(2020, 4, 21, 16, 00, 00), 40, new TimeSpan(1, 20, 00), 30, null, TrainingType.Endurance, null, BikeType.RacingBike);
            DC.AddRunningTraining(new DateTime(2020, 4, 17, 12, 30, 00), 5000, new TimeSpan(0, 27, 17), null, TrainingType.Endurance, null);

            var montly = DC.GetMonlyReport(2020, 4).TimeLine;

            // if(montly[0].Item2 is CyclingSession)
            RunningSession tempRunn = (RunningSession)montly[0].Item2;

            tempRunn.When.Should().Be(_running.When);
            tempRunn.Distance.Should().Be(_running.Distance);
            tempRunn.Time.Should().Be(_running.Time);
            tempRunn.AverageSpeed.Should().Be(_running.AverageSpeed);
            tempRunn.TrainingType.Should().Be(_running.TrainingType);
            tempRunn.Comments.Should().Be(_running.Comments);

            CyclingSession tempCycle = (CyclingSession)montly[1].Item2;

            tempCycle.When.Should().Be(_cycling.When);
            tempCycle.Distance.Should().Be(_cycling.Distance);
            tempCycle.Time.Should().Be(_cycling.Time);
            tempCycle.AverageSpeed.Should().Be(_cycling.AverageSpeed);
            tempCycle.AverageWatt.Should().Be(_cycling.AverageWatt);
            tempCycle.TrainingType.Should().Be(_cycling.TrainingType);
            tempCycle.Comments.Should().Be(_cycling.Comments);
            tempCycle.BikeType.Should().Be(_cycling.BikeType);
            
            

        }
        [TestMethod]
        public void DomainController_GetCountRunningSessions_ReceivedRunningSessions()
        {
            DC.AddRunningTraining(new DateTime(2020, 4, 17, 12, 30, 00), 5000, new TimeSpan(0, 27, 17), null, TrainingType.Endurance, null);

            var count = DC.GetCountRunningSessions(1);

            // if(montly[0].Item2 is CyclingSession)
            RunningSession tempRunn = count[0];

            tempRunn.When.Should().Be(_running.When);
            tempRunn.Distance.Should().Be(_running.Distance);
            tempRunn.Time.Should().Be(_running.Time);
            tempRunn.AverageSpeed.Should().Be(_running.AverageSpeed);
            tempRunn.TrainingType.Should().Be(_running.TrainingType);
            tempRunn.Comments.Should().Be(_running.Comments);

        }
        [TestMethod]
        public void DomainController_GetCountCycleSessions_ReceivedCycleSSessions()
        {
            //CyclingSession cycle2 = new CyclingSession(new DateTime(2020, 4, 18, 18, 00, 00), 40, new TimeSpan(1, 42, 00), null, null, TrainingType.Recuperation, null, BikeType.RacingBike);
            //CyclingSession cycle3 = new CyclingSession(new DateTime(2020, 4, 19, 16, 45, 00), null, new TimeSpan(1, 0, 00), null, 219, TrainingType.Interval, "5x5 min 270", BikeType.IndoorBike);

            DC.AddCyclingTraining(new DateTime(2020, 4, 21, 16, 00, 00), 40, new TimeSpan(1, 20, 00), 30, null, TrainingType.Endurance, null, BikeType.RacingBike);

            var count = DC.GetCountCyclingSessions(1);

            // if(montly[0].Item2 is CyclingSession) 
            CyclingSession tempCycle = count[0];

            tempCycle.When.Should().Be(_cycling.When);
            tempCycle.Distance.Should().Be(_cycling.Distance);
            tempCycle.Time.Should().Be(_cycling.Time);
            tempCycle.AverageSpeed.Should().Be(_cycling.AverageSpeed);
            tempCycle.AverageWatt.Should().Be(_cycling.AverageWatt);
            tempCycle.TrainingType.Should().Be(_cycling.TrainingType);
            tempCycle.Comments.Should().Be(_cycling.Comments);
            tempCycle.BikeType.Should().Be(_cycling.BikeType);

        }
        [TestMethod]
        public void DomainController_RemoveSessions_SessionsRemoved()
        {

            DC.AddCyclingTraining(new DateTime(2020, 4, 21, 16, 00, 00), 40, new TimeSpan(1, 20, 00), 30, null, TrainingType.Endurance, null, BikeType.RacingBike);
            DC.AddRunningTraining(new DateTime(2020, 4, 17, 12, 30, 00), 5000, new TimeSpan(0, 27, 17), null, TrainingType.Endurance, null);

            List<int> cyclingSessionIds = new List<int>();
            List<int> runningSessionIds = new List<int>();
            cyclingSessionIds.Add(1);
            runningSessionIds.Add(1);

            DC.RemoveSession(cyclingSessionIds, runningSessionIds);

            var montly = DC.GetMonlyReport(2020, 4).TimeLine;

            montly.Should().BeEmpty();


        }


    }
}
