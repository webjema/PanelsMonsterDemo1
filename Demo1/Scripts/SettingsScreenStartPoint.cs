using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.webjema.PanelsMonster;
using com.webjema.Functional;

public class SettingsScreenStartPoint : MonoBehaviour {

    // SettingsScreen start point is here
    void Start () {
        PanelsManager.Instance.GetPanel<SettingsPanel>().MatchAction(
            (panel) => panel.InitPanel(), 
            (e) => Debug.LogError("[SettingsScreenStartPoint] [Start] " + e.Message) 
        );
    } // Start

} // SettingsScreenStartPoint