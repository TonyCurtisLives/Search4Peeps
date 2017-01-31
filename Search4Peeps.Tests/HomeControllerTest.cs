using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Search4Peeps.Services;
using Search4Peeps.Models;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Search4Peeps.Controllers;
using System.Web.Mvc;
using System.Web;
using System.Web.Routing;
using System.Web.Script.Serialization;

namespace Search4Peeps.Tests
{
    [TestClass]
    public class HomeControllerTest
    {
        private IList<Peep> testPeeps;
        private IList<Peep> testPeeps2;
        private NameValueCollection testForm;
        private IPeepService mockPeepService;
        private HttpRequestBase stubRequest;
        private HttpContextBase stubContext;
        private HomeController sut;

        [TestInitialize]
        public void Init()
        {
            InitData();
            InitFakes();

            sut = new HomeController(mockPeepService);
            sut.ControllerContext = new ControllerContext(stubContext, new RouteData(), sut);
        }

        [TestMethod]
        public void ShowPeeps_GivenSearchText_SendsToPeepsService()
        {
            CallShowPeeps();
            Mock.Get(mockPeepService).Verify(s => s.GetPeeps(testForm[0]));
        }

        [TestMethod]
        public void ShowPeeps_GivenFirstName_ReturnsFirstName()
        {
            string actResult = CallShowPeeps();
            StringAssert.Contains(actResult, testPeeps[0].FirstName);
        }

        [TestMethod]
        public void ShowPeeps_GivenMiddleName_ReturnsMiddleName()
        {
            string actResult = new JavaScriptSerializer().Serialize(((JsonResult)sut.ShowPeeps()).Data);
            StringAssert.Contains(actResult, testPeeps[0].MiddleName);
        }

        [TestMethod]
        public void ShowPeeps_GivenLastName_ReturnsLastName()
        {
            string actResult = new JavaScriptSerializer().Serialize(((JsonResult)sut.ShowPeeps()).Data);
            StringAssert.Contains(actResult, testPeeps[0].LastName);
        }

        [TestMethod]
        public void ShowPeeps_GivenLine1_ReturnsLine1WithBreak()
        {
            string actResult = new JavaScriptSerializer().Serialize(((JsonResult)sut.ShowPeeps()).Data);
            StringAssert.Contains(actResult, string.Format(@"{0}\u003cbr/\u003e", testPeeps[0].Address.Line1));
        }

        [TestMethod]
        public void ShowPeeps_GivenLine2_ReturnsLine2WithBreak()
        {
            string actResult = new JavaScriptSerializer().Serialize(((JsonResult)sut.ShowPeeps()).Data);
            StringAssert.Contains(actResult, string.Format(@"{0}\u003cbr/\u003e", testPeeps[0].Address.Line2));
        }

        [TestMethod]
        public void ShowPeeps_GivenCity_ReturnsCityWithComma()
        {
            string actResult = new JavaScriptSerializer().Serialize(((JsonResult)sut.ShowPeeps()).Data);
            StringAssert.Contains(actResult, string.Format(@"{0},", testPeeps[0].Address.City));
        }

        [TestMethod]
        public void ShowPeeps_GivenState_ReturnsStateWithComma()
        {
            string actResult = new JavaScriptSerializer().Serialize(((JsonResult)sut.ShowPeeps()).Data);
            StringAssert.Contains(actResult, string.Format(@"{0},", testPeeps[0].Address.StateOrProvince));
        }

        [TestMethod]
        public void ShowPeeps_GivenPostalCode_ReturnsPostalCodeWithBreak()
        {
            string actResult = new JavaScriptSerializer().Serialize(((JsonResult)sut.ShowPeeps()).Data);
            StringAssert.Contains(actResult, string.Format(@"{0}\u003cbr/\u003e", testPeeps[0].Address.PostalCode));
        }

        [TestMethod]
        public void ShowPeeps_GivenCountry_ReturnsCountry()
        {
            string actResult = new JavaScriptSerializer().Serialize(((JsonResult)sut.ShowPeeps()).Data);
            StringAssert.Contains(actResult, testPeeps[0].Address.Country);
        }

        [TestMethod]
        public void ShowPeeps_GivenPhoto_ReturnsPhotoID()
        {
            string actResult = new JavaScriptSerializer().Serialize(((JsonResult)sut.ShowPeeps()).Data);
            StringAssert.Contains(actResult, testPeeps[0].Photo.PhotoID.ToString());
        }

        [TestMethod]
        public void ShowPeeps_GivenAge_ReturnsAge()
        {
            string actResult = new JavaScriptSerializer().Serialize(((JsonResult)sut.ShowPeeps()).Data);
            StringAssert.Contains(actResult, testPeeps[0].Age.ToString());
        }

        [TestMethod]
        public void ShowPeeps_GivenInterests_ReturnsInterests()
        {
            string actResult = new JavaScriptSerializer().Serialize(((JsonResult)sut.ShowPeeps()).Data);
            StringAssert.Contains(actResult, testPeeps[0].Interests);
        }

        [TestMethod]
        public void ShowPeeps_ThrowsException_ReturnsHttpStatus()
        {
            Mock.Get(mockPeepService).Setup(p => p.GetPeeps(It.IsAny<string>())).Throws<Exception>();
            var actReturn = sut.ShowPeeps();
            Assert.AreEqual(((HttpStatusCodeResult)actReturn).StatusCode, 500);
        }

        [TestMethod]
        public void ShowPeeps_ThrowsException_ReturnsExceptionMessage()
        {
            var testMessage = "testExceptionMessage";
            Mock.Get(mockPeepService).Setup(p => p.GetPeeps(It.IsAny<string>())).Throws(new Exception(testMessage));
            var actReturn = sut.ShowPeeps();
            StringAssert.Contains(((HttpStatusCodeResult)actReturn).StatusDescription, testMessage);
        }

        [TestMethod]
        public void ShowPeeps_ThrowsException_ReturnsInnerExceptionMessage()
        {
            var testMessage = "testInnerExceptionMessage";
            Mock.Get(mockPeepService).Setup(p => p.GetPeeps(It.IsAny<string>())).Throws(new Exception(string.Empty, new Exception(testMessage)));
            var actReturn = sut.ShowPeeps();
            StringAssert.Contains(((HttpStatusCodeResult)actReturn).StatusDescription, testMessage);
        }

        private void InitData()
        {
            var testAddress = new Address
            {
                AddressID = 5,
                Line1 = "TestLine1",
                Line2 = "TestLine2",
                City = "TestCity",
                StateOrProvince = "TestState",
                PostalCode = "TestPostal",
                Country = "TestCountry"
            };

            var testPhoto = new Photo
            {
                PhotoID = 42,
                Image = Enumerable.Repeat((byte)0x20, 37).ToArray()
            };

            var testPeep = new Peep
            {
                PeepID = 3,
                Address = testAddress,
                Photo = testPhoto,
                Age = 37,
                FirstName = "testFirstName",
                MiddleName = "testMiddleName",
                LastName = "testLastName",
                Interests = "testInterests"
            };

            testPeeps = new List<Peep>
            {
                testPeep
            };

            testPeeps2 = new List<Peep>
            {
                testPeep,

            };

            testForm = new NameValueCollection() { { "txtName", "meh" }, { "chkDelay", "false" } };
        }

        private void InitFakes()
        {
            mockPeepService = Mock.Of<IPeepService>(
                p => p.GetPeeps(It.IsAny<string>()) == testPeeps);
            stubRequest = Mock.Of<HttpRequestBase>(
                r => r.Headers == new System.Net.WebHeaderCollection { { "X-Requested-With", "XMLHttpRequest" } }
                && r.Form == testForm);
            stubContext = Mock.Of<HttpContextBase>(
                c => c.Request == stubRequest);
        }

        private string CallShowPeeps()
        {
            return new JavaScriptSerializer().Serialize(((JsonResult)sut.ShowPeeps()).Data);
        }
    }
}
