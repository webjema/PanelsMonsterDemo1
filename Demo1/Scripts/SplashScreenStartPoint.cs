using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.webjema.PanelsMonster;

public class SplashScreenStartPoint : MonoBehaviour {

    public SplashScreenFakeLoader loader;

    // SplashScreen start point is here
    void Start () {
        if (this.loader == null)
        {
            Debug.LogError("[SplashScreenStartPoint][Start] 'Loader' is not linked");
            return;
        }

        var loadingPanel = PanelsManager.Instance.GetPanel<LoadingPanel>();
        loadingPanel.MatchAction(
            panel => 
            {
                panel.Show();
                this.loader.Load((s) => panel.UpdateBar(s), () => ScreensManager.Instance.PushScreen(ScreensName.LobbyScreenScene));
            }, 
            e => Debug.LogError("[SplashScreenStartPoint][Start] " + e.Message));
    } // Start

} // SplashScreenStartPoint