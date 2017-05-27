using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.webjema.PanelsMonster;
using com.webjema.Functional;

public class ProfileScreenStartPoint : MonoBehaviour {

    // ProfileScreen start point is here
    void Start () {
        PanelsManager.Instance.GetPanel<ProfilePanel>().MatchAction(
            (panel) => panel.InitPanel(), 
            (e) => Debug.LogError("[ProfileScreenStartPoint] [Start] " + e.Message) 
        );
    } // Start

} // ProfileScreenStartPoint