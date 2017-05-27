using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.webjema.PanelsMonster;

public class GameBoardScreenStartPoint : MonoBehaviour {

    // GameBoard Screen start point is here
    void Start () {
        ScreensManager.Instance.CurrentScreenArguments
            .MatchAction(
                (a) => {
                    GameBoardScreenArguments args = a as GameBoardScreenArguments;
                    this.InitLevel(args.LevelIndex);
                }, 
                () => {
                    Debug.LogError("[GameBoardScreenStartPoint] arguments is required to start");
                }
            );
    } // Start

    void InitLevel(int index)
    {
        Debug.Log("[InitLevel] index = " + index);

        // just to show something
        PanelsManager.Instance.GetPanel("FakeGamePanel")
            .SetProperty(PanelPropertyName.title, string.Format("Level {0} started", index), PanelPropertyType.text)
            .Show();
    }

} // GameBoardScreenStartPoint