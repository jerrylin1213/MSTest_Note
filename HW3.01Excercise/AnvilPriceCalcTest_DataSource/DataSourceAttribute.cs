using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using SUT = AnvilTotalPriceCalcExcercise.PriceCalc;

namespace AnvilPriceCalcTest_DataSource
{
    [TestClass]
    public class DataSourceAttribute : Attribute, ITestDataSource
    {
        // Data source
        [TestMethod]
        [DataSource]
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

        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            yield return new object[] { 1, 20 };
            yield return new object[] { 0, 10 };
            yield return new object[] { 2, 30 };
            yield return new object[] { 2, 30 };
            yield return new object[] { 3, null };
            yield return new object[] { -1, null };
            //throw new NotImplementedException();
        }

        public string GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            if (data != null)
                return string.Format(CultureInfo.CurrentCulture, "Custom - {0} ({1})", methodInfo.Name, string.Join(",", data));

            return null;
        }
    }
}
