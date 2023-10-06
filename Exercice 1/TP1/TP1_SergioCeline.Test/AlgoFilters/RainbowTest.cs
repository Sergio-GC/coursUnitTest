﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1_SergioCeline.AlgoFilters;

namespace TP1_SergioCeline.Test.AlgoFilters
{
    // Generated by ChatGPT
    [TestClass]
    public class RainbowTest
    {
        Rainbow rainbow = new();

        #region test1
        [TestMethod]
        public void Rainbow_Algo_ReturnsCorrectImage()
        {
            // Arrange
            Bitmap image = new Bitmap(100, 100);

            // Act
            Bitmap result = rainbow.algo(image);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(image.Width, result.Width);
            Assert.AreEqual(image.Height, result.Height);
        }
        #endregion

        [TestMethod]
        public void GetDividers_ReturnsCorrectDividers()
        {
            // Act
            var dividers1 = rainbow.GetDividers(10, 20);
            var dividers2 = rainbow.GetDividers(30, 20);
            var dividers3 = rainbow.GetDividers(50, 20);
            var dividers4 = rainbow.GetDividers(70, 20);
            var dividers5 = rainbow.GetDividers(90, 20);

            // Assert
            Assert.AreEqual(1, dividers1.red);
            Assert.AreEqual(1, dividers1.green);
            Assert.AreEqual(1, dividers1.blue);

            Assert.AreEqual(5, dividers2.red);
            Assert.AreEqual(1, dividers2.green);
            Assert.AreEqual(1, dividers2.blue);

            Assert.AreEqual(1, dividers3.red);
            Assert.AreEqual(5, dividers3.green);
            Assert.AreEqual(1, dividers3.blue);

            Assert.AreEqual(5, dividers4.red);
            Assert.AreEqual(1, dividers4.green);
            Assert.AreEqual(5, dividers4.blue);

            Assert.AreEqual(5, dividers5.red);
            Assert.AreEqual(5, dividers5.green);
            Assert.AreEqual(5, dividers5.blue);
        }
    }
}
