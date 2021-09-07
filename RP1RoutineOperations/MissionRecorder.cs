using System;
using KerbalConstructionTime;
namespace RP1RoutineOperations
{
	public class MissionRecorder : VesselModule
	{
		public bool IsRecording { get; set; } = false;
		public bool Subscribed { get; set; } = false;
		public MissionData Data { get; set; } = null;

		protected override void OnStart()
		{
			base.OnStart();
			MissionRecordingValidator.Instance.AddMissionRecorderUnique(Data.Id, this);
		}

		private void Update()
		{
			RecordingCheck();
		}

		private void OnDestroy()
		{
			UnsubscribeFromEvents();
			MissionRecordingValidator.Instance.RemoveMissionRecorder(Data.Id);
		}

		private void RecordingCheck()
		{
			// check if the vessel is in prelaunch or in any other valid situation

			if (!IsRecording && vessel.isActiveVessel && vessel.situation == Vessel.Situations.PRELAUNCH)
			{
				IsRecording = true;
				SubscribeToEvents();
				StoreVessel(KCTGameStates.LaunchedVessel);
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

		private void StoreVessel(BuildListVessel blv)
		{
			Data = MissionData.Create(blv);
		}
	}
}
