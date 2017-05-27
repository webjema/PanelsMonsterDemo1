using com.webjema.Functional;
using com.webjema.PanelsMonster;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuPanel : Panel {

    public void StartLevel(int index)
    {
        ScreensManager.Instance.PushScreen(ScreensName.GameBoardScreenScene, new Option<IScreenArguments>(new GameBoardScreenArguments(index)));
    }

    public override void OnClick(string action)
    {
        switch (action.Trim().ToLowerInvariant())
        {
            case "help":
                PanelsManager.Instance.GetPanel(PanelName.InfoPanel)
                    .Reset()
                    .SetProperty(PanelPropertyName.title, "Help", PanelPropertyType.text)
                    .SetProperty(PanelPropertyName.description, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", PanelPropertyType.text)
                    .SetProperty(PanelPropertyName.button1, "OK", PanelPropertyType.button)
                    .SetAction(PanelActionName.button1click, () => PanelsManager.Instance.GetPanel(PanelName.InfoPanel).Close())
                    .SetNullProperty(PanelPropertyName.button2)
                    .Show();
                break;
            default:
#if PANELS_DEBUG_ON
                Debug.LogWarning(string.Format("[GameMenuPanel][OnClick] action '{0}' is not found", action));
#endif
                break;
        }
    } // OnClick

} // GameMenuPanel