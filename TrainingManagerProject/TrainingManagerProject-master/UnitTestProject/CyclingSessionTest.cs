using DomainLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace UnitTestProject
{
    [TestClass]
    public class CyclingSessionTest
    {


        [TestMethod]
        public void CyclingSession_AverageSpeedNullAndDistanceNull_CreatesCyclingSession()
        {
            CyclingSession cycle = new CyclingSession(new DateTime(2020, 4, 21, 16, 00, 00), null, new TimeSpan(1, 20, 00), null, 20, TrainingType.Endurance, null, BikeType.RacingBike);

            cycle.AverageSpeed.Should().Be(null);
        }
        [TestMethod]
        public void CyclingSession_AverageSpeedNullAndDistanceNotNull_CreatesCyclingSession()
        {
            CyclingSession cycle = new CyclingSession(new DateTime(2020, 4, 21, 16, 00, 00), 40, new TimeSpan(1, 20, 00), null,20, TrainingType.Endurance, null, BikeType.RacingBike);
            
            cycle.AverageSpeed.Should().Be(30);
        }
        [TestMethod]
        public void CyclingSession_AverageWattNull_CreatesCyclingSession()
        {
            CyclingSession cycle = new CyclingSession(new DateTime(2020, 4, 21, 16, 00, 00), 40, new TimeSpan(1, 20, 00), 20, null, TrainingType.Endurance, null, BikeType.RacingBike);

            cycle.AverageWatt.Should().Be(null);

        }
    }
}
