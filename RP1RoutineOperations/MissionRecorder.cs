using System;
using System.Security.Policy;
using Expansions.Missions.Tests;

namespace RP1RoutineOperations
{
	public class MissionRecorder : VesselModule
	{
		public bool IsRecording { get; set; }
		public bool Subscribed { get; set; }
		
		public string LaunchedVesselPath { get; private set; }

		public void OnStart()
		{
			
		}

		private void OnUpdate()
		{
			RecordingCheck();

			if (IsRecording)
			{
				
			}
		}

		private void OnDestroy()
		{
			UnsubscribeFromEvents();
		}

		private void RecordingCheck()
		{
			// check if the vessel is in prelaunch or in any other valid situation

			if (vessel.isActiveVessel && vessel.situation == Vessel.Situations.PRELAUNCH)
			{
				IsRecording = true;
				SubscribeToEvents();
			}
		}

		private void SubscribeToEvents()
		{
			if (Subscribed) return;

			GameEvents.onStageSeparation.Add(OnStaging);
			GameEvents.onDockingComplete.Add(OnDocking);

			Subscribed = true;
		}

		private void UnsubscribeFromEvents()
		{
			if (!Subscribed) return;

			GameEvents.onStageSeparation.Remove(OnStaging);
			GameEvents.onDockingComplete.Remove(OnDocking);
			
			Subscribed = false;
		}

		private void OnStaging(EventReport evt)
		{
			throw new NotImplementedException();
		}

		private void OnDocking(GameEvents.FromToAction<Part, Part> action)
		{
			throw new NotImplementedException();
		}
	}
}
