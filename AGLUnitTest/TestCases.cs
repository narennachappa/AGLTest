using AGLTest;
using DataTransferObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGLUnitTest
{
    [TestClass]
    public class TestCases
    {
        Mock<getUserData> mockObject = new Mock<getUserData>();

        [TestMethod]
        public void Should_Validate_Get_With_Valid_Inputs_Without_Mocking()
        {
            string gender = "Male";
            string petName = "Cat";
            getUserData obj = new getUserData();
            var ab = obj.getAGLPeopleJSONData(gender, petName);
            Assert.AreEqual(ab.Count, 2);
        }
        [TestMethod]
        public void Should_Validate_Get_With_Valid_Inputs_With_Mocking()
        {
            string gender = "Male";
            string petName = "Cat";
            var output = mockObject.Object.getAGLPeopleJSONData(gender, petName);
            Assert.AreEqual(output.Count, 2);
        }
    }
}
