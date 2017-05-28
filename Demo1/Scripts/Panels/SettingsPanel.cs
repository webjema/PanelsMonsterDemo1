using com.webjema.PanelsMonster;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SettingsPanel : Panel {

    public Slider slider;
    public TextMeshProUGUI sliderInfoText;

    public override void InitPanel()
    {
        if (this.onInit != null)
            this.onInit.Invoke(this);

        float startValue = 0;
        if (PlayerPrefs.HasKey("settings.slider"))
        {
            startValue = PlayerPrefs.GetFloat("settings.slider");
        }
        this.slider.value = startValue;
    } // Init

    public override void OnClick(string action)
    {
        switch(action.Trim().ToLowerInvariant())
        {
            case "save":
                this.SaveAction();
                break;
            default:
#if PANELS_DEBUG_ON
                Debug.LogWarning(string.Format("[SettingsPanel][OnClick] '{0}' action is not found", action));
#endif
                break;
        }
    } // OnClick

    public void OnSliderUpdate(float value)
    {
        this.sliderInfoText.text = value.ToString();
    }


    private void SaveAction()
    {
        Action saveAction = () => {
            PlayerPrefs.SetFloat("settings.slider", this.slider.value);
            ScreensManager.Instance.PopScreen();
        };
        PanelsManager.Instance.GetPanel(PanelName.InfoPanel)
                    .Reset()
                    .SetProperty(PanelPropertyName.title, "Question", PanelPropertyType.text)
                    .SetProperty(PanelPropertyName.description, "Are you sure you want to save settings?", PanelPropertyType.text)
                    .SetProperty(PanelPropertyName.button1, "YES", PanelPropertyType.button)
                    .SetAction(PanelActionName.button1click, saveAction)
                    .SetProperty(PanelPropertyName.button2, "NO", PanelPropertyType.button)
                    .SetAction(PanelActionName.button2click, () => PanelsManager.Instance.GetPanel(PanelName.InfoPanel).Close())
                    .Show();
    } // SaveAction

} // SettingsPanel