using Moq;
using SmartDataInitiative.Business.Interfaces;
using SmartDataInitiative.Business.Interfaces.Services;
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
        public async Task Add_ExecuteValidation()
        {
            // arrange
            var project = new Project
            {
                Name = _name,
                Description = _description,
                InitialDate = _initialDate,
                FinalDate = _finalDate,
                Status = _status
            };

            Assert.Equal(_name, project.Name);
            Assert.Equal(_description, project.Description);
            Assert.Equal(_initialDate, project.InitialDate);
            Assert.Equal(_finalDate, project.FinalDate);
            Assert.Equal(_status, project.Status);

            _mockProjectRepository.Setup(x => x.Add(project)).Returns(Task.FromResult(project));

            //act
            //await _projectService.Add(project);

            //_mockProjectRepository.Verify(x => x.Add(It.IsAny<Project>()), Times.Once);


            //assert


        }
    }
}
