using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using SUT = AnvilTotalPriceCalcExcercise.PriceCalc;

namespace AnvilPriceCalcTest
{
    [TestClass]
    public class UnitTest1
    {
        [DataTestMethod]
        [DataRow(0, 10, 0)]
        [DataRow(3, 15, 15)]
        [DataRow(10, 30, 27)]
        [DataRow(13, 10, 9)]
        [DataRow(19, 0, 0)]
        [DataRow(25, 10, 8)]
        public void ReturnDiscountPrice_WhenQuantityAndRegularPricesAreGiven(int inputQty, double inputRegPrice, double expected)
        {
            // Arrange
            double actual;
            // Act
            actual = SUT.CalcPricePerAnvil(inputQty, inputRegPrice);
            // Assert
            Assert.AreEqual(expected, actual);

        }

        // Data row
        [DataTestMethod]
        [DataRow(0, 10)]
        [DataRow(1, 20)]
        [DataRow(2, 30)]
        [DataRow(3, null)]
        [DataRow(-1, null)]
        public void ReturnShippingFee_BasedOnGivenZone(int inputZone, int expected)
        {
            // Arrange
            double actual;
            // Act
            try
            {
                actual = SUT.CalcShippingCostPerAnvil(inputZone);
                // Assert
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual(ex.Message, "Index Out of Range");
            }
        }

        // Dynamic Data
        [DataTestMethod]
        [DynamicData(nameof(GetTestData), DynamicDataSourceType.Method)]
        public void ReturnShippingFee_BasedOnGivenZone2(int inputZone, int expected)
        {
            // Arrange
            double actual;
            // Act
            try
            {
                actual = SUT.CalcShippingCostPerAnvil(inputZone);
                // Assert
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual(ex.Message, "Index Out of Range");
            }
        }

        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[] { 1, 20 };
            yield return new object[] { 0, 10 };
            yield return new object[] { 2, 30 };
            yield return new object[] { 2, 30 };
            yield return new object[] { 3, null };
            yield return new object[] { -1, null };
        }
    }
}
