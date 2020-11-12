using Moq;
using SmartDataInitiative.Business.Interfaces;
using SmartDataInitiative.Business.Models;
using System;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class Add
    {
        // Correct data
        private readonly string _name = "Project Test";
        private readonly string _description = "Project Description";
        private readonly DateTime _initialDate = new System.DateTime(2020, 05, 20, 8, 0, 0);
        private readonly DateTime _finalDate = new System.DateTime(2020, 05, 20, 8, 0, 0);
        private readonly Status _status = Status.NotReady;

        //Wrong data
        private readonly string _wrongName = "Project Test";
        private readonly string _wrongDescription = "Project Description";
        private readonly DateTime _wrongInitialDate = new System.DateTime(2020, 05, 20, 8, 0, 0);
        private readonly DateTime _wrongFinalDate = new System.DateTime(2020, 05, 20, 8, 0, 0);
        private readonly Status _wrongStatus = (Status) 5;


        private readonly Mock<IRepository<Project>> _mockProjectRepository;

        public Add()
        {
            _mockProjectRepository = new Mock<IRepository<Project>>();
        }

        [Fact]
        public async Task ExecuteValidation()
        {
            var project = new Project
            {
                Name = "Project test",
                Description = "Project description",
                InitialDate = new System.DateTime(2020, 05, 20, 8, 0, 0),
                FinalDate = new System.DateTime(2021, 05, 20, 8, 0, 0),
                Status = Status.NotReady
            };











        }




        //bool isOdd(int value)
        //{
        //    return value % 2 == 1;
        //}
    }
}
