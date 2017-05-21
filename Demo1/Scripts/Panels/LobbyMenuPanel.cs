using com.webjema.PanelsMonster;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyMenuPanel : Panel {

    public override void OnClick(string action)
    {
        switch(action.Trim().ToLowerInvariant())
        {
            case "game_menu":
                ScreensManager.Instance.PushScreen(ScreensName.GameMenuScreenScene);
                break;
            case "info_example":
                //PanelsManager.Instance.GetPanel<LoadingPanel>().MatchAction(p => p.Show(), (e) => Debug.LogError("NotFound!" + e.Message));
                Action showMoreAction = () => {
                    PanelsManager.Instance.GetPanel(PanelName.SmallInfoPanel)
                    .Reset()
                    .SetProperty(PanelPropertyName.title, null, PanelPropertyType.none)
                    .SetProperty(PanelPropertyName.description, "More info modal panel. Click 'OK' button to close.", PanelPropertyType.text)
                    .SetProperty(PanelPropertyName.button1, "OK", PanelPropertyType.button)
                    .SetAction(PanelActionName.button1click, () => PanelsManager.Instance.GetPanel(PanelName.SmallInfoPanel).Close())
                    .SetProperty(PanelPropertyName.button2, null, PanelPropertyType.none)
                    .Show();
                };
                PanelsManager.Instance.GetPanel(PanelName.InfoPanel)
                    .Reset()
                    .SetProperty(PanelPropertyName.title, "Announcement", PanelPropertyType.text)
                    .SetProperty(PanelPropertyName.description, "It's an info panel. Title, description and button properties are filled during runtime.", PanelPropertyType.text)
                    .SetProperty(PanelPropertyName.button1, "OK", PanelPropertyType.button)
                    .SetAction(PanelActionName.button1click, () => PanelsManager.Instance.GetPanel(PanelName.InfoPanel).Close())
                    .SetProperty(PanelPropertyName.button2, "More", PanelPropertyType.button)
                    .SetAction(PanelActionName.button2click, showMoreAction)
                    .Show();
                break;
            default:
#if PANELS_DEBUG_ON
                Debug.LogWarning(string.Format("[MenuPanel][OnClick] '{0}' action is not found", action));
#endif
                break;
        }
    } // OnClick

} // LobbyMenuPanel