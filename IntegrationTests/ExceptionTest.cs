using EFRepository.Context;
using EFRepository.Infrastructure;
using NUnit.Framework;
using ParikshaModel.Model;
using ParikshaModel.Model.User;
using System;

namespace IntegrationTests
{
    [TestFixture]
    public class ExceptionTest
    {  
        [Test]
        [Category("ExceptionTests")]
        [Description("Initialising a repository with nul context shuould raise an exception")]           
        public void CheckIfExceptionIsRaisedWhenContextIsNull()
        {                
            Assert.Throws<UnitOfWorkException>(() => new EFUnitOfWork(null));
        }

        [Test]
        [Category("ExceptionTests")]
        [Description("Initialising a repository with null context or null IUnitOfWork should raise an exception")]           
        public void CheckIfExceptionIsRaisedWhenContextOrUnitOfWorkAreNull()
        {
            Assert.Throws<ArgumentNullException>(() => new EFRepository<UserDetail>(null, null));
            Assert.Throws<ArgumentNullException>(() => new EFRepository<UserDetail>(null, new ParikshaContext()));
            Assert.Throws<ArgumentNullException>(() => new EFRepository<UserDetail>(new EFUnitOfWork(new ParikshaContext()), null));
        }
    }
}
