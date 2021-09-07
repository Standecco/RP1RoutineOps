using System;
using System.Collections.Generic;
using KSP.UI.Screens;
using UnityEngine;
namespace RP1RoutineOperations
{
	[KSPScenario(ScenarioCreationOptions.AddToAllGames, GameScenes.SPACECENTER, GameScenes.FLIGHT, GameScenes.TRACKSTATION, GameScenes.EDITOR)]
	public class RoutineOpsManager : ScenarioModule
	{
		private const ApplicationLauncher.AppScenes buttonTgtScenes = ApplicationLauncher.AppScenes.FLIGHT | ApplicationLauncher.AppScenes.SPACECENTER;
		private static readonly List<GameScenes> tgtScenes = new List<GameScenes> { GameScenes.FLIGHT, GameScenes.SPACECENTER, GameScenes.TRACKSTATION, GameScenes.EDITOR };

		private static ApplicationLauncherButton launcherButton = null;

		private void Awake()
		{
			GameEvents.onGUIApplicationLauncherReady.Add(CreationEvent);
			GameEvents.onGUIApplicationLauncherUnreadifying.Add(UnreadifyingEvent);
			GameEvents.onGUIApplicationLauncherDestroyed.Add(DestructionEvent);
		}

		private void OnDestroy()
		{
			GameEvents.onGUIApplicationLauncherReady.Remove(CreationEvent);
			GameEvents.onGUIApplicationLauncherUnreadifying.Remove(UnreadifyingEvent);
			GameEvents.onGUIApplicationLauncherDestroyed.Remove(DestructionEvent);
		}

        #region AppLauncherButton

		private void CreationEvent()
		{
			if (ApplicationLauncher.Ready && launcherButton == null)
			{
				try
				{
					launcherButton = ApplicationLauncher.Instance.AddModApplication(
						ClickEventOpen,
						ClickEventClose,
						null,
						null,
						null,
						null,
						buttonTgtScenes,
						texture: Texture2D.whiteTexture);

					Utils.Log("Added application launcher button");
				}
				catch (Exception)
				{
					Utils.Log("Exception while adding application launcher button", launcherButton);
					throw;
				}
			}
		}

		private void UnreadifyingEvent(GameScenes newScene)
		{
			if (launcherButton == null)
			{
				return;
			}

			if (!tgtScenes.Contains(newScene))
			{
				DestructionEvent();
			}
			else
			{
				// hide
				throw new NotImplementedException();
			}
		}

		private void DestructionEvent()
		{
			if (launcherButton != null)
			{
				ApplicationLauncher.Instance.RemoveModApplication(launcherButton);
				Utils.Log("Removed application launcher button");
				launcherButton = null;
			}
		}

		private void ClickEventOpen()
		{
			OpenUI();
		}

		private void ClickEventClose()
		{
			CloseUI();
		}

        #endregion

        #region UI

		public void OpenUI()
		{
			throw new NotImplementedException();
		}

		public void CloseUI()
		{
			throw new NotImplementedException();
		}

        #endregion
	}
}
