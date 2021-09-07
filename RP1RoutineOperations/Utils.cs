using System.IO;
using UnityEngine;
namespace RP1RoutineOperations
{
	public static class Utils
	{
		public static string SaveDir => Path.GetFullPath(Path.Combine(Path.Combine(KSPUtil.ApplicationRootPath, "saves"), HighLogic.SaveFolder));

		public static void Log(string message)
		{
			Debug.Log("[RP1RoutineOps] " + message);
		}

		public static void Log(string message, Object context)
		{
			Debug.Log("[RP1RoutineOps] " + message, context);
		}

		public static void LogWrn(string message)
		{
			Debug.LogWarning("[RP1RoutineOps] " + message);
		}

		public static void LogWrn(string message, Object context)
		{
			Debug.LogWarning("[RP1RoutineOps] " + message, context);
		}

		public static void LogErr(string message)
		{
			Debug.LogError("[RP1RoutineOps] " + message);
		}

		public static void LogErr(string message, Object context)
		{
			Debug.LogError("[RP1RoutineOps] " + message, context);
		}
	}
}
