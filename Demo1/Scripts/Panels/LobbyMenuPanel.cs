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
            case "login":
                ScreensManager.Instance.PushScreen(ScreensName.LoginScreenScene);
                break;
            case "profile":
                ScreensManager.Instance.PushScreen(ScreensName.ProfileScreenScene);
                break;
            case "settings":
                ScreensManager.Instance.PushScreen(ScreensName.SettingsScreenScene);
                break;
            case "info_example":
                this.InfoExample();
                break;
            default:
#if PANELS_DEBUG_ON
                Debug.LogWarning(string.Format("[MenuPanel][OnClick] '{0}' action is not found", action));
#endif
                break;
        }
    } // OnClick

    private void InfoExample()
    {
        Action showMoreAction = () => {
            PanelsManager.Instance.GetPanel(PanelName.SmallInfoPanel)
            .Reset()
            .SetProperty(PanelPropertyName.title, null, PanelPropertyType.none)
            .SetProperty(PanelPropertyName.description, "More info modal panel. Click 'OK' button to close.", PanelPropertyType.text)
            .SetProperty(PanelPropertyName.button1, "OK", PanelPropertyType.button)
            .SetAction(PanelActionName.button1click, () => PanelsManager.Instance.GetPanel(PanelName.SmallInfoPanel).Close())
            .SetNullProperty(PanelPropertyName.button2) // hides linked object
            .Show();
        };
        PanelsManager.Instance.GetPanel(PanelName.CustomInfoPanel)
            .Reset()
            .SetProperty(PanelPropertyName.title, "Announcement", PanelPropertyType.text)
            .SetProperty(PanelPropertyName.description, "It's an info panel. Title, description and button properties are filled during runtime.", PanelPropertyType.text)
            .SetProperty(PanelPropertyName.button1, "OK", PanelPropertyType.button)
            .SetAction(PanelActionName.button1click, () => PanelsManager.Instance.GetPanel(PanelName.CustomInfoPanel).Close())
            .SetProperty(PanelPropertyName.button2, "More", PanelPropertyType.button)
            .SetAction(PanelActionName.button2click, showMoreAction)
            .Show();
    } // InfoExample

} // LobbyMenuPanel