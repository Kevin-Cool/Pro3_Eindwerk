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

        }
        public void AddRunningTraining(DateTime when, int distance, TimeSpan time, float? averageSpeed, TrainingType trainingType, string comments)
        {
            _gerry.AddRunningTraining(when, distance, time, averageSpeed, trainingType, comments);

        }
        public Report GetMonlyRunningReport(int jaar, int maant)
        {
            return _gerry.GenerateMonthlyRunningReport(jaar, maant);
        }
        public Report GetMonlyCyclingReport(int jaar, int maant)
        {
            return _gerry.GenerateMonthlyCyclingReport(jaar, maant);
        }
        public Report GetMonlyReport(int jaar, int maant)
        {
            return _gerry.GenerateMonthlyTrainingsReport(jaar, maant);
        }
        public List<RunningSession> GetCountRunningSessions(int count)
        {
            return _gerry.GetPreviousRunningSessions(count);
        }
        public List<CyclingSession> GetCountCyclingSessions(int count)
        {
            return _gerry.GetPreviousCyclingSessions(count);
        }
        public List<CyclingSession> GetAllCyclingSessions()
        {
            return _gerry.GetAllCyclingSessions(); 
        }
        public List<RunningSession> GetAllRunningSessions()
        {
            return _gerry.GetAllRunningSessions();
        }
        public void RemoveSession(List<int> cyclingSessionIds, List<int> runningSessionIds)
        {
            _gerry.RemoveTrainings(cyclingSessionIds, runningSessionIds);
        }
    }//m.AddCyclingTraining(new DateTime(2020, 4, 21, 16, 00, 00), 40, new TimeSpan(1, 20, 00), 30, null, TrainingType.Endurance, null, BikeType.RacingBike);

    
}
