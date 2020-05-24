using DataLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class TrainingContextTest : TrainingContext
    {
        public TrainingContextTest(bool keepExistingDB = false) : base("Test")
        {
            if(keepExistingDB)
            {
                Database.EnsureCreated();
            }
            else
            {
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }
    }
}
