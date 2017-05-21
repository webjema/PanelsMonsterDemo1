using com.webjema.Functional;
using com.webjema.PanelsMonster;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuPanel : Panel {

    public void StartLevel(int index)
    {
        ScreensManager.Instance.PushScreen(ScreensName.GameBoardScreenScene, new Option<IScreenArguments>(new GameBoardScreenArguments(1)));
    }

} // GameMenuPanel