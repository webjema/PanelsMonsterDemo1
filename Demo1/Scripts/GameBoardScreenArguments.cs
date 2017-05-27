using com.webjema.PanelsMonster;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoardScreenArguments : IScreenArguments
{

    public int LevelIndex { get; set; }

    public GameBoardScreenArguments(int levelIndex)
    {
        this.LevelIndex = levelIndex;
    }

    public object GetScreenArguments()
    {
        return this.LevelIndex;
    }
}