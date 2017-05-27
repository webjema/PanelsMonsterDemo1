using com.webjema.PanelsMonster;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoginPanel : Panel {

    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;

    public override void OnClick(string action)
    {
        switch(action.Trim().ToLowerInvariant())
        {
            case "login":
                this.DoLogin();
                break;
            default:
#if PANELS_DEBUG_ON
                Debug.LogWarning(string.Format("[LoginPanel][OnClick] '{0}' action is not found", action));
#endif
                break;
        }
    } // OnClick

    private void DoLogin()
    {
        // very simple validation first
        if (string.IsNullOrEmpty(this.usernameInput.text) || string.IsNullOrEmpty(this.passwordInput.text))
        {
            PanelsManager.Instance.GetPanel(PanelName.SmallInfoPanel)
                    .Reset()
                    .SetProperty(PanelPropertyName.title, "Warning", PanelPropertyType.text)
                    .SetProperty(PanelPropertyName.description, "Please, fill the required fields (username and password).", PanelPropertyType.text)
                    .SetProperty(PanelPropertyName.button1, "OK", PanelPropertyType.button)
                    .SetAction(PanelActionName.button1click, () => PanelsManager.Instance.GetPanel(PanelName.SmallInfoPanel).Close())
                    .SetNullProperty(PanelPropertyName.button2)
                    .Show();
            return;
        }
        if (this.usernameInput.text != "demo" || this.passwordInput.text != "demo")
        {
            PanelsManager.Instance.GetPanel(PanelName.SmallInfoPanel)
                    .Reset()
                    .SetProperty(PanelPropertyName.title, "Error", PanelPropertyType.text)
                    .SetProperty(PanelPropertyName.description, "Username and password do not match.", PanelPropertyType.text)
                    .SetProperty(PanelPropertyName.button1, "OK", PanelPropertyType.button)
                    .SetAction(PanelActionName.button1click, () => PanelsManager.Instance.GetPanel(PanelName.SmallInfoPanel).Close())
                    .SetNullProperty(PanelPropertyName.button2)
                    .Show();

            return;
        }

        PlayerPrefs.SetString("user", "demo");
        ScreensManager.Instance.PopScreen();
    } // DoLogin

} // LoginPanel