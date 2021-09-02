using System;
using Expansions.Missions;
namespace RP1RoutineOperations
{
	public class OperationProfile
	{
		public Orbit Orbit { get; set; }
		public float PayloadMass { get; set; }
		public ShipConstruct ShipConstruct { get; set; }

		public OperationProfile(float mass, Orbit orbit)
		{
			PayloadMass = mass;
			Orbit = orbit;
		}

		public OperationProfile(float mass, double inc, double e, double sma, double lan, double argPe, double mEp, double t, CelestialBody body)
		{
			var o = new Orbit(inc, e, sma, lan, argPe, mEp, t, body);
			PayloadMass = mass;
			Orbit = o;
		}

		public static bool operator <=(OperationProfile a, OperationProfile b)
		{
			if (a.Orbit.referenceBody != b.Orbit.referenceBody)
				throw new InvalidOperationException("Cannot compare orbits around different bodies");
			
			return a.PayloadMass <= b.PayloadMass && a.Orbit.ApA <= b.Orbit.ApA && a.Orbit.PeA <= b.Orbit.PeA;
		}
		
		public static bool operator >=(OperationProfile a, OperationProfile b) => b <= a;
	}
}
