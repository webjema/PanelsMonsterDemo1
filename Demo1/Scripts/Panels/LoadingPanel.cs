using com.webjema.PanelsMonster;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingPanel : Panel {

    public RectTransform bar;

    private float? _fullSize = null;

    public void UpdateBar(float progressValue) // 0..100%
    {
        if (this.bar == null)
        {
            throw new UnityException("'Bar' is not linked in 'LoadingPanel'");
        }
        if (this._fullSize == null)
        {
            this._fullSize = this.bar.offsetMax.x;
        }
        float newSize = (float)this._fullSize - ((float)this._fullSize / 100.0f * progressValue);
        Vector2 max = this.bar.offsetMax;
        max.x = newSize;
        this.bar.offsetMax = max;
    } // UpdateBar

} // LoadingPanel