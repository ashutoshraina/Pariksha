using EFRepository.Infrastructure;
using Moq;
using ParikshaModel.Model;
using ParikshaServices;
using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
namespace ParikshaModelTests
{
    [TestFixture]
    public class TestServiceTest
    {
        /// <summary>
        ///Initialize() is called once during test execution before test methods in this test class are executed.
        ///</summary>
        [SetUp()]
        public void Initialize()
        {
            
        }

        /// <summary>
        ///Cleanup() is called once during test execution after test methods in this class have executed unless
        ///this test class' Initialize() method throws an exception.
        ///</summary>
        [TearDown()]
        public void Cleanup()
        {

            //  TODO: Add test cleanup code
        }

        [Test]
        [Category("TestService")]
        [Description("")]
        public void RatingChangeCheck()
        {
            
        }
    }
}