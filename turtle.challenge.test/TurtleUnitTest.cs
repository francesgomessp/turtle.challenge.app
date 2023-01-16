using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using turtle.challenge.core.Dto;
using turtle.challenge.core.service;
using turtle.challenge.core.utils;

namespace turtle.challenge.test
{
    [TestClass]
    public class TurtleUnitTest
    {

        [TestMethod]
        public void MessageResultTest()
        {
            Assert.AreNotEqual(Message.Success, Message.IsMined);
        }

        [TestMethod]
        public void PointerDTOTest()
        {
            PointerDTO point = new PointerDTO(5, 3);
            Assert.AreEqual(3, point.Y);
        }


        [TestMethod]
        public void TestTurtle()
        {
            var turtle = TurtleDTO.Instance(new PointerDTO(5, 10));
            var positionX = turtle.Position.X;
            var positionY = turtle.Position.Y;
            Assert.AreEqual(positionX, 5);
            Assert.AreEqual(positionY, 10);
        }

        [TestMethod]
        public void ChallengeServiceTest()
        {
            var observer = new MovimentRuleService(new GridDTO(10, 6));
            Assert.AreEqual(false, observer.IsDanger(new PointerDTO(5, 10)));
        }

    }
}
