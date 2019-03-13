using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using PastryEmporium.Controllers;
using PastryEmporium.Models;
using PastryEmporium.Tests.MockRepos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PastryEmporium.Tests
{
    class PastryControllerTests
    {
        [Test]
        public void Index_ReturnViewResult_ContainsAllPastries()
        {
            var mockPastryRepository = RepositoryMocks.GetPastryRepository();

            var pastryController = new PastriesController(mockPastryRepository.Object);

            ViewResult result = pastryController.Index() as ViewResult;

            List<Pastry> pastries = result.ViewData.Model as List<Pastry>;

            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsAssignableFrom<List<Pastry>>(result.ViewData.Model);
            Assert.AreEqual(2, pastries.Count);
        }
    }
}

