using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;
using TestNinja.Mocking.Interfaces;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class HousekeeperServiceTests
    {
        private readonly string _statementFilename = "filename";
        private Mock<IUnitOfWork> _unitOfWork;
        private Mock<IStatementGenerator> _statementGenerator;
        private Mock<IEmailSender> _emailSender;
        private Mock<IXtraMessageBox> _xtraMessageBox;
        private HousekeeperService _housekeeperService;
        private DateTime _statementDate = new DateTime(2017, 1, 1);
        private Housekeeper _housekeeper;

        [SetUp]
        public void SetUp()
        {
            _housekeeper = new Housekeeper { Email = "a", FullName = "b", Oid = 1, StatementEmailBody = "c" };

            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(uof => uof.Query<Housekeeper>()).Returns(new List<Housekeeper>
            {
                _housekeeper
            }.AsQueryable());

            _statementGenerator = new Mock<IStatementGenerator>();
            _emailSender = new Mock<IEmailSender>();
            _xtraMessageBox = new Mock<IXtraMessageBox>();
            _housekeeperService = new HousekeeperService(_unitOfWork.Object, 
                                                         _statementGenerator.Object, 
                                                         _emailSender.Object, 
                                                         _xtraMessageBox.Object);
        }

        [Test]
        public void SendStatementEmails_WhenCalled_GenerateStatements()
        {
            _housekeeperService.SendStatementEmails(_statementDate);

            _statementGenerator.Verify(sg => 
                                        sg.SaveStatement(_housekeeper.Oid, _housekeeper.FullName, _statementDate));

        }
        
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void SendStatementEmails_HousekeepersEmailIsInvalid_ShouldNotGenerateStatement(string invalidEmail)
        {
            _housekeeper.Email = invalidEmail;

            _housekeeperService.SendStatementEmails(_statementDate);

            _statementGenerator.Verify(sg => 
                                        sg.SaveStatement(_housekeeper.Oid, _housekeeper.FullName, _statementDate), 
                                        Times.Never);

        }

        [Test]
        public void SendStatementEmails_WhenCalled_EmailTheStatement()
        {
            _statementGenerator
                        .Setup(sg => sg.SaveStatement(_housekeeper.Oid, _housekeeper.FullName, _statementDate))
                        .Returns(_statementFilename);

            _housekeeperService.SendStatementEmails(_statementDate);
            VerifyIfEmailWasSent();

        }
        
        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void SendStatementEmails_StatementFileNameIsInvalid_ShouldNotEmailTheStatement(string invalidStatementFileName)
        {
            _statementGenerator
                        .Setup(sg => sg.SaveStatement(_housekeeper.Oid, _housekeeper.FullName, _statementDate))
                        .Returns(() => invalidStatementFileName);

            _housekeeperService.SendStatementEmails(_statementDate);
            VerifyIfEmailWasNotSent();

        }

        [Test]
        public void SendStatementEmails_EmailSendingFails_DisplayAMessageBox()
        {
            _emailSender.Setup(e => e.EmailFile(It.IsAny<string>(),
                                                It.IsAny<string>(),
                                                It.IsAny<string>(),
                                                It.IsAny<string>()))
                        .Throws<Exception>();

            _statementGenerator
                        .Setup(sg => sg.SaveStatement(_housekeeper.Oid, _housekeeper.FullName, _statementDate))
                        .Returns(_statementFilename);

            _housekeeperService.SendStatementEmails(_statementDate);

            _xtraMessageBox.Verify(mb => mb.Show(It.IsAny<string>(),
                                                It.IsAny<string>(),
                                                MessageBoxButtons.OK));
        }

        #region Private Methods
        private void VerifyIfEmailWasSent()
        {
            _emailSender.Verify(es => es.EmailFile(
                                                                _housekeeper.Email,
                                                                _housekeeper.StatementEmailBody,
                                                                _statementFilename,
                                                                It.IsAny<string>()));
        }

        private void VerifyIfEmailWasNotSent()
        {
            _emailSender.Verify(es => es.EmailFile(
                                                                It.IsAny<string>(),
                                                                It.IsAny<string>(),
                                                                It.IsAny<string>(),
                                                                It.IsAny<string>()),
                                            Times.Never);
        }

        #endregion
    }
}
