using System;
using System.Collections.Generic;
using UnityEngine;

namespace RP1RoutineOperations
{
	// starts each time flight scene is loaded, and manages the data recorded by the Mission
	[KSPAddon(KSPAddon.Startup.Flight, false)]
	public class MissionRecordingValidator : MonoBehaviour
	{
		public static MissionRecordingValidator Instance { get; private set; }
		private Dictionary<string, MissionRecorder> Missions { get; } = new Dictionary<string, MissionRecorder>();

		private void Awake()
		{
			Instance = this;
		}

		private void OnDestroy()
		{
			Instance = null;
		}

		public bool AddMissionRecorder(string guid, MissionRecorder mission)
		{
			bool valid = !Missions.ContainsKey(guid) && mission != null;
			
			if(valid)
			{
				Missions[guid] = mission;
			}

			return valid;
		}
		
		public MissionRecorder GetMissionRecorder(string guid) => Missions.ContainsKey(guid) ? Missions[guid] : null;
	}
}
