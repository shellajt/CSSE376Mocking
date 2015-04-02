using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Expedia;
using Rhino.Mocks;

namespace ExpediaTest
{
	[TestClass]
	public class CarTest
	{	
		private Car targetCar;
		private MockRepository mocks;
		
		[TestInitialize]
		public void TestInitialize()
		{
			targetCar = new Car(5);
			mocks = new MockRepository();
		}
		
		[TestMethod]
		public void TestThatCarInitializes()
		{
			Assert.IsNotNull(targetCar);
		}	
		
		[TestMethod]
		public void TestThatCarHasCorrectBasePriceForFiveDays()
		{
			Assert.AreEqual(50, targetCar.getBasePrice()	);
		}
		
		[TestMethod]
		public void TestThatCarHasCorrectBasePriceForTenDays()
		{
            var target = new Car(10);
			Assert.AreEqual(80, target.getBasePrice());	
		}
		
		[TestMethod]
		public void TestThatCarHasCorrectBasePriceForSevenDays()
		{
			var target = new Car(7);
			Assert.AreEqual(10*7*.8, target.getBasePrice());
		}
		
		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void TestThatCarThrowsOnBadLength()
		{
			new Car(-5);
		}

        [TestMethod]
        public void TestGetCarLocaiton()
        {
            IDatabase mockDB = mocks.StrictMock<IDatabase>();

            String carLocation10 = "Location10";
            String carLocation11 = "Location11";

            Expect.Call(mockDB.getCarLocation(10)).Return(carLocation10);
            Expect.Call(mockDB.getCarLocation(11)).Return(carLocation11);

            mocks.ReplayAll();
            Car target = new Car(10);
            
            target.Database = mockDB;

            String result;

            result = target.getCarLocation(10);
            Assert.AreEqual(carLocation10, result);

            result = target.getCarLocation(11);
            Assert.AreEqual(carLocation11, result);

            mocks.VerifyAll();
        }
	}
}
