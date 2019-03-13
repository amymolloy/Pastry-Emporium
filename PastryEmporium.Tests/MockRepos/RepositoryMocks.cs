using Moq;
using PastryEmporium.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PastryEmporium.Tests.MockRepos
{
    public class RepositoryMocks
    {
        public static Mock<IPastryRepository> GetPastryRepository()
        {
            var pastries = new List<Pastry>
            {
                new Pastry
                {
                    Name = "Croissant",
                    Description = "One tasty croissant",
                    Price = 3.99m,
                    ImageUrl = "croissant.jpg",
                    ThumbnailUrl = "croissant.jpg"
                },

                new Pastry
                {
                    Name = "Cherry Pie",
                    Description = "One tasty cherry pie",
                    Price = 3.99m,
                    ImageUrl = "cherry-pie.jpg",
                    ThumbnailUrl = "cherry-pie.jpg"
                },
            };

            var mockPastryRepository = new Mock<IPastryRepository>();
            mockPastryRepository.Setup(repo => repo.GetPastries()).Returns(pastries);
            mockPastryRepository.Setup(repo => repo.GetPastryById(It.IsAny<int>())).Returns(pastries[0]);
            return mockPastryRepository;
        }
    }
}
