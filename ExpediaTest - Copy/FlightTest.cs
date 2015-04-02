using System;
using System.Collections.Generic;
using Expedia;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace ExpediaTest
{
	[TestClass]
	public class FlightTest
	{
		private Flight targetFlight;
		private readonly DateTime StartDate = new DateTime(2009, 11, 1);
		private readonly DateTime EndDate = new DateTime(2009, 11, 30);
		private MockRepository mocks;
		
		[TestInitialize]
		public void TestInitialize()
		{
			mocks = new MockRepository();
			targetFlight = new Flight(StartDate, EndDate, 0);
		}
		
		[TestMethod]
		public void TestThatFlightInitializes()
		{
			Assert.IsNotNull(targetFlight);
		}
		
		[TestMethod]
		public void TestThatFlightHasCorrectMilesAfterConstruction()
		{
			var target = new Flight(StartDate, EndDate, 500);
			Assert.AreEqual(500, target.Miles);
		}
		
		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void TestThatFlightThrowsOnInvertedDates()
		{
			new Flight(EndDate, StartDate, 500);
		}
		
		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void TestThatFlightThrowsOnBadMiles()
		{
			new Flight(StartDate, EndDate, -500);
		}
		
		[TestMethod]
		public void TestThatFlightHasCorrectBasePriceForSameDayFlight()
		{
			var target = new Flight(DateTime.Today, DateTime.Today, 0);
			Assert.AreEqual(200, target.getBasePrice());
		}
		
		[TestMethod]
		public void TestThatFlightHasCorrectBasePriceForNextDayFlight()
		{
			var target = new Flight(DateTime.Now, DateTime.Now.AddDays(1), 0);
			Assert.AreEqual(220, target.getBasePrice());
		}
		
		[TestMethod]
		public void TestThatFlightHasCorrectBasePriceForFiveDayFlight()
		{
			var target = new Flight(DateTime.Now, DateTime.Now.AddDays(5), 0);
			Assert.AreEqual(300, target.getBasePrice());
		}
		
		[TestMethod]
		public void TestThatFlightDoesGetNumberOfPassengers()
		{
			var mockDatabase = mocks.StrictMock<IDatabase>();
			
			var values = new List<String>();
			for(var i = 0; i < 50; i++)
				values.Add("Bob");
			
			Expect.Call(mockDatabase.Passengers).Return(values);
			mocks.ReplayAll();
			
			var target = new Flight(DateTime.Now, DateTime.Now.AddDays(1), 0);
			
			target.Database = mockDatabase;
			Assert.AreEqual(50, target.NumberOfPassengers);
		}
		
		[TestCleanup]
		public void TearDown()
		{
			mocks.VerifyAll();	
		}
	}
}
