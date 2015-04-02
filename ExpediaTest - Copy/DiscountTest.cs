using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Expedia;

namespace ExpediaTest
{
	[TestClass]
	public class DiscountTest
	{
		[TestMethod]
		public void TestThatDiscountInitializes()
		{
			var target = new Discount(0.01, 1);
			Assert.IsNotNull(target);
			Assert.AreEqual(0.01, target.ReductionPercent);
			Assert.AreEqual(1, target.FrequentFlyerMilesCost);
		}
	}
}
