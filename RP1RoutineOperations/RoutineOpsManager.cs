using System;
using KSP.UI.Screens;
using UnityEngine;

namespace RP1RoutineOperations
{
    [KSPScenario(ScenarioCreationOptions.AddToAllGames, GameScenes.SPACECENTER, GameScenes.FLIGHT, GameScenes.TRACKSTATION, GameScenes.EDITOR)]
    public class RoutineOpsManager : ScenarioModule
    {
        private const ApplicationLauncher.AppScenes buttonTgtScenes = ApplicationLauncher.AppScenes.FLIGHT | ApplicationLauncher.AppScenes.SPACECENTER;

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
                    
                    Utilities.Log("Added application launcher button");
                }
                catch (Exception)
                {
                    Utilities.Log("Exception while adding application launcher button", launcherButton);
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

            if (newScene != GameScenes.FLIGHT && newScene != GameScenes.SPACECENTER && newScene != GameScenes.TRACKSTATION && newScene != GameScenes.EDITOR)
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
                Utilities.Log("Removed application launcher button");
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
