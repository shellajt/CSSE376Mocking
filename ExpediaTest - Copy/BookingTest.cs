
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Expedia;

namespace ExpediaTest
{
	[TestClass]
	public class BookingTest
	{
		private Car targetCar;
		private Flight targetFlight;
		private Hotel targetHotel;
		private readonly int DaysToRentCar = 5;
		private readonly DateTime StartDate = new DateTime(2009, 11, 1);
		private readonly DateTime EndDate = new DateTime(2009, 11, 30);
		private readonly int NightsToRentHotel = 5;
		
		[TestInitialize]
		public void TestInitialize()
		{
			targetCar = new Car(DaysToRentCar);
			targetFlight = new Flight(StartDate, EndDate, 0);
			targetHotel = new Hotel(NightsToRentHotel);
		}
		
		[TestMethod]
		public void TestThatObjectsAreBookings()
		{
			var list = new List<Booking>();
			
			list.Add(targetCar);
			list.Add(targetFlight);
			list.Add(targetHotel);
			
			Assert.IsNotNull(list);
		}
	}
}
