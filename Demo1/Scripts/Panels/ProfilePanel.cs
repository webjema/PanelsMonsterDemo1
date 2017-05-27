using com.webjema.PanelsMonster;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProfilePanel : Panel {

    public TextMeshProUGUI infoText;
    public GameObject logoutButton;

    public override void InitPanel()
    {
        if (this.onInit != null)
            this.onInit.Invoke(this);

        this.logoutButton.SetActive(false);
        this.infoText.text = "";
        string user = "";
        if (PlayerPrefs.HasKey("user"))
        {
            user = PlayerPrefs.GetString("user");
        }
        if (string.IsNullOrEmpty(user))
        {
            PanelsManager.Instance.GetPanel(PanelName.SmallInfoPanel)
                    .Reset()
                    .SetProperty(PanelPropertyName.title, "Error", PanelPropertyType.text)
                    .SetProperty(PanelPropertyName.description, "Please, login first to check profile info.", PanelPropertyType.text)
                    .SetProperty(PanelPropertyName.button1, "OK", PanelPropertyType.button)
                    .SetAction(PanelActionName.button1click, () => ScreensManager.Instance.PopScreen())
                    .SetNullProperty(PanelPropertyName.button2)
                    .Show();
            return;
        }
        this.infoText.text = string.Format("Hello {0}!", user);
        this.logoutButton.SetActive(true);
    } // Init

    public override void OnClick(string action)
    {
        switch(action.Trim().ToLowerInvariant())
        {
            case "logout":
                PlayerPrefs.DeleteKey("user");
                ScreensManager.Instance.PopScreen();
                break;
            default:
#if PANELS_DEBUG_ON
                Debug.LogWarning(string.Format("[ProfilePanel][OnClick] '{0}' action is not found", action));
#endif
                break;
        }
    } // OnClick

} // ProfilePanel