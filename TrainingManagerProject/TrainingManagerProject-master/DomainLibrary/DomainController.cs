using DomainLibrary.Domain;
//using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary
{
    public class DomainController
    {
        private IUnitOfWork _jonny;
        private TrainingManager _gerry ;
        public DomainController(IUnitOfWork unitOfWork)
        {
            _jonny = unitOfWork;
            _gerry = new TrainingManager(unitOfWork);
        }
        
        public void AddCyclingTraining(DateTime when, float? distance, TimeSpan time, float? averageSpeed, int? averageWatt, TrainingType trainingType, string comments, BikeType bikeType)
        {
            _gerry.AddCyclingTraining(when, distance, time, averageSpeed, averageWatt, trainingType, comments, bikeType);
            //_gerry.Complete();

        }
        public Report GetCyclingTraining(int jaar, int maant)
        {
            return _gerry.GenerateMonthlyRunningReport(jaar, maant);
        }




    }//m.AddCyclingTraining(new DateTime(2020, 4, 21, 16, 00, 00), 40, new TimeSpan(1, 20, 00), 30, null, TrainingType.Endurance, null, BikeType.RacingBike);

    
}
