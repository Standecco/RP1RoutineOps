using System.Collections.Generic;
using UnityEngine;
namespace RP1RoutineOperations
{
	/// <summary>
	/// starts each time flight scene is loaded, and manages the data recorded by MissionRecorders
	/// </summary>
	[KSPAddon(KSPAddon.Startup.Flight, false)]
	public class MissionRecordingValidator : MonoBehaviour
	{
		public static MissionRecordingValidator Instance { get; private set; }
		private Dictionary<int, MissionRecorder> LoadedMissions { get; } = new Dictionary<int, MissionRecorder>();

		private void Awake()
		{
			Instance = this;
		}

		private void OnDestroy()
		{
			Instance = null;
		}

		public bool AddMissionRecorderUnique(int id, MissionRecorder mission)
		{
			bool valid = !LoadedMissions.ContainsKey(id) && mission != null;

			if (valid)
			{
				LoadedMissions[id] = mission;
			}

			return valid;
		}

		public void RemoveMissionRecorder(int id)
		{
			if (LoadedMissions.ContainsKey(id))
			{
				LoadedMissions.Remove(id);
			}
		}

		public MissionRecorder GetMissionRecorder(int id) => LoadedMissions.ContainsKey(id) ? LoadedMissions[id] : null;
	}
}
