using Moq;
using NUnit.Framework;
using System;
using URE6XP_HFT_2021221.Logic;
using URE6XP_HFT_2021221.Repository;

namespace URE6XP_HFT_2021221.Test
{
    [TestFixture]
    public class Test
    {
        PresentationLogick presentationLogick;
        [SetUp]
        public void Init()
        {
            var mockCarRepository = new Mock<IPresentationRepository>();


        }

    }
}
