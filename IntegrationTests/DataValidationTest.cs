using NUnit.Framework;
namespace IntegrationTests
{
    [TestFixture]
    public class DataValidationTest
    {
        [SetUp]
        public void Initialise()
        { }

        [TearDown]
        public void CleanUp()
        { }

        [Test]
        [Category("DataValidationTestForUser")]
        [Description("")]
        public void CheckUserNameLength()
        { }

        [Test]
        [Category("DataValidationTestForUser")]
        [Description("")]
        public void CheckPasswordLength()
        { }
        
        [Test]
        [Category("DataValidationTestForSubject")]
        [Description("")]
        public void CheckSubjectNameLength()
        { }

        [Test]
        [Category("DataValidationTestForStandard")]
        [Description("")]
        public void CheckIfStandardCanBeCreatedWithoutASubject()
        { }
    }
}