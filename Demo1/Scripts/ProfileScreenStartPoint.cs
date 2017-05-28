using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.webjema.PanelsMonster;
using com.webjema.Functional;

public class ProfileScreenStartPoint : MonoBehaviour {

    // ProfileScreen start point is here
    void Start()
    {
        this.InitProfilePanel();
    } // Start

    private void InitProfilePanel()
    {
        Panel panel = PanelsManager.Instance.GetPanel("ProfilePanel")
            .Reset()
            .SetProperty(PanelPropertyName.message, "", PanelPropertyType.text)
            .SetNullProperty(PanelPropertyName.button1);

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


        panel = panel
            .SetProperty(PanelPropertyName.message, string.Format("Hello {0}!", user), PanelPropertyType.text)
            .SetProperty(PanelPropertyName.button1, "Logout", PanelPropertyType.button)
            .SetAction(PanelActionName.logout, () =>
            {
                PlayerPrefs.DeleteKey("user");
                ScreensManager.Instance.PopScreen();
            });
    } // InitProfilePanel

} // ProfileScreenStartPoint