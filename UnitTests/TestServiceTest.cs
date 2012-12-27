using EFRepository.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ParikshaModel.Model;
using ParikshaServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParikshaModelTests
{
    [TestClass]
    public class TestServiceTest
    {

        /// <summary>
        ///Initialize() is called once during test execution before test methods in this test class are executed.
        ///</summary>
        [TestInitialize()]
        public void Initialize()
        {
            
        }

        /// <summary>
        ///Cleanup() is called once during test execution after test methods in this class have executed unless
        ///this test class' Initialize() method throws an exception.
        ///</summary>
        [TestCleanup()]
        public void Cleanup()
        {

            //  TODO: Add test cleanup code
        }

        [TestMethod]
        [TestCategory("TestService")]
        [Description("")]
        public void RatingChangeCheck()
        {
            
        }
    }
}