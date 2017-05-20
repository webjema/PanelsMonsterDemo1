using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAnim : MonoBehaviour {
    public BackgroundPlaneAnim back1;
    public BackgroundPlaneAnim back2;

    public string texturesPath;

    private Texture2D[] _textures;
    private int _currentTextureIndex = 0;

    void Awake()
    {
        this._textures = Resources.LoadAll<Texture2D>(this.texturesPath);
    }

	void Start () {
        this.back2.gameObject.SetActive(false);

        this.SetNextTextureIndex();

        this.DoAnim(this.back1, withAlpha: false);
    }

    void DoAnim(BackgroundPlaneAnim activeBack, bool withAlpha = true)
    {
        Action<BackgroundPlaneAnim> onAnimFinish = (bp) =>
        {
            bp.FadeOut();
            this.SwapBacksPositions();
            this.SetNextTextureIndex();
            BackgroundPlaneAnim newBp = this.GetNextActiveBack(bp);
            this.DoAnim(newBp);
        };

        activeBack.SetTexture(this._textures[this._currentTextureIndex]);
        activeBack.DoAnim(withAlpha, onAnimFinish);
    }

    void SetNextTextureIndex()
    {
        this._currentTextureIndex = (this._currentTextureIndex + 1 >= this._textures.Length) ? 0 : this._currentTextureIndex + 1;
    }

    void SwapBacksPositions()
    {
        Vector3 pos = this.back1.transform.localPosition;
        this.back1.transform.localPosition = this.back2.transform.localPosition;
        this.back2.transform.localPosition = pos;
    }

    BackgroundPlaneAnim GetNextActiveBack(BackgroundPlaneAnim bp)
    {
        return bp == this.back1 ? this.back2 : this.back1;
    }

} // BackgroundAnim