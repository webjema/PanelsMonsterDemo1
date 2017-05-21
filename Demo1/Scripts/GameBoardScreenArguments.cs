using com.webjema.PanelsMonster;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoardScreenArguments : IScreenArguments
{

    private int _levelIndex;

    public GameBoardScreenArguments(int arguments)
    {
        this._levelIndex = arguments;
    }

    public object GetScreenArguments()
    {
        return this._levelIndex;
    }

    public int GetTypedScreenArguments()
    {
        return this._levelIndex;
    }
}
