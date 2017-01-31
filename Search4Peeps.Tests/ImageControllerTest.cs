using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Search4Peeps.Controllers;
using Search4Peeps.Services;
using Moq;
using System.IO;
using System.Security.Cryptography;
using System;

namespace Search4Peeps.Tests
{
    [TestClass]
    public class ImageControllerTest
    {
        private ImageController sut;
        private int photoId;
        private IPeepService mockPeepService;
        private byte[] testImageBytes;
        private MemoryStream testImageStream;

        [TestInitialize]
        public void Init()
        {
            InitData();
            InitFakes();

            sut = new ImageController(mockPeepService);
        }

        [TestMethod]
        public void Show_GivenId_SendsToPeepService()
        {
            CallShow(photoId);
            Mock.Get(mockPeepService).Verify(p => p.GetPhoto(photoId));
        }

        [TestMethod]
        public void Show_GivenImage_ReturnsSameData()
        {
            FileStreamResult actResult = CallShow(photoId);
            CollectionAssert.AreEqual(GetHash(testImageStream), GetHash(actResult.FileStream));
        }

        [TestMethod]
        public void Show_ThrowsException_ReturnsHttpStatus()
        {
            Mock.Get(mockPeepService).Setup(p => p.GetPhoto(It.IsAny<int>())).Throws<Exception>();
            var actReturn = sut.Show(0);
            Assert.AreEqual(((HttpStatusCodeResult)actReturn).StatusCode, 500);
        }

        [TestMethod]
        public void Show_ThrowsException_ReturnsExceptionMessage()
        {
            var testMessage = "testExceptionMessage";
            Mock.Get(mockPeepService).Setup(p => p.GetPhoto(It.IsAny<int>())).Throws(new Exception(testMessage));
            var actReturn = sut.Show(0);
            StringAssert.Contains(((HttpStatusCodeResult)actReturn).StatusDescription, testMessage);
        }

        [TestMethod]
        public void ShowPeeps_ThrowsException_ReturnsInnerExceptionMessage()
        {
            var testMessage = "testInnerExceptionMessage";
            Mock.Get(mockPeepService).Setup(p => p.GetPhoto(It.IsAny<int>())).Throws(new Exception(string.Empty, new Exception(testMessage)));
            var actReturn = sut.Show(0);
            StringAssert.Contains(((HttpStatusCodeResult)actReturn).StatusDescription, testMessage);
        }

        [TestMethod]
        public void ShowPeeps_GivenEmptyImage_ReturnsNull()
        {
            Mock.Get(mockPeepService).Setup(p => p.GetPhoto(photoId)).Returns<FileStreamResult>(null);
            var actReturn = CallShow(photoId);
            Assert.IsNull(actReturn);
        }

        private void InitData()
        {
            photoId = 1;
            testImageBytes = File.ReadAllBytes("TestData\\2x2.jpg");
            testImageStream = new MemoryStream(testImageBytes);
        }

        private void InitFakes()
        {
            mockPeepService = Mock.Of<IPeepService>(
                p => p.GetPhoto(It.IsAny<int>()) == testImageBytes);
        }

        private FileStreamResult CallShow(int photoId = 0)
        {
            return (FileStreamResult)sut.Show(photoId);
        }

        private byte[] GetHash(Stream stream)
        {
            stream.Position = 0;

            using (var crypto = new MD5CryptoServiceProvider())
            {
                return crypto.ComputeHash(stream);
            }
        }
    }
}
