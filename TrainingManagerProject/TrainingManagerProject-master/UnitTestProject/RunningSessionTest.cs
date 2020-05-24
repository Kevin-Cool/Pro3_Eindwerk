using System;
using System.Collections.Generic;
using System.Text;
using DomainLibrary.Domain;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace UnitTestProject
{
    [TestClass]
    public class RunningSessionTest
    {


        [TestMethod]
        public void RunningSession_AverageSpeedNull_CreatesCyclingSession()
        {
            RunningSession running = new RunningSession(new DateTime(2020, 4, 17, 12, 30, 00), 5000, new TimeSpan(0, 27, 17), null, TrainingType.Endurance, null);

            running.AverageSpeed.Should().BeApproximately((float)10.9957237,3);
        }
    }
}
