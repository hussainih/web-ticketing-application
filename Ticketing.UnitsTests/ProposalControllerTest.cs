//using EntityFramework.MoqHelper;
//using Moq;
//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Ticketing.TicketModel;
//using Ticketing.Identity;
//using Ticketing.Controllers;

//namespace Ticketing.UnitsTests
//{
//    public class ProposalControllerTest
//    {

       
//        AdminController _controller;
//        private Mock<IProposalRepository> _mockRepository;

//        [SetUp]
//        public void Setup()
//        {
//            _mockRepository = new Mock<IProposalRepository>();

//            var mockUoW = new Mock<IUnitOfWork>();
//            mockUoW.SetupGet(u => u.Proposals).Returns(_mockRepository.Object);

//            _controller = new AdminController(mockUoW.Object);
            
//        }
//        //[TestCase("22a", "Approved")]
//        //[TestCase("44B", "Submitted")]
//        [TestCase("99W", "Rejected")]
//        public void ProposalStatus_ReturnsProposalNotApproved(string input, string expectedResult)
//        {

//            var systemUnderTest = new ProposalRepository();
//            var model = new List<Proposal>
//            {
//                new Proposal { nameOfProject="something", status ="Approved"},
//                new Proposal { nameOfProject="nothing", status ="Sbumitted"},
//                new Proposal { nameOfProject="special", status = "Rejected"},
//                new Proposal {nameOfProject="Null", status = null}
//            };

//            _mockRepository.Setup(r => r.getProposalStatus(input)).Returns("Rejected");
            
            

//            var result = systemUnderTest.getProposalStatus(input);
//            Assert.That(result, Is.EqualTo(expectedResult));


//        }
//    }


//}
