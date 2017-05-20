using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class BackgroundPlaneAnim : MonoBehaviour {

    [Range(1, 2)]
    public float maxZoom = 1.2f;
    public float zoomingTime = 10f; // seconds
    public float fadeInTime = 1f; // seconds
    public float stayTime = 5f; // seconds
    public float fadeOutTime = 2f; // seconds

    public MeshRenderer meshRenderer;

    private Vector3 _baseSize;
    private float Alpha {
        get
        {
            return this.meshRenderer.material.GetFloat("_Alpha");
        }
        set
        {
            this.meshRenderer.material.SetFloat("_Alpha", value);
        }
    }

    void Awake()
    {
        this._baseSize = this.transform.localScale;
    }

    public void SetTexture(Texture2D texture)
    {
        this.meshRenderer.material.mainTexture = texture;
    }

    public void DoAnim(bool withAlpha, Action<BackgroundPlaneAnim> onFinish)
    {
        this.gameObject.SetActive(true);
        this.transform.localScale = this._baseSize;

        Sequence animSequence = DOTween.Sequence();
        this.Alpha = withAlpha ? 0 : 1;
        if (withAlpha)
        {
            animSequence.Append(DOTween.To(() => this.Alpha, x => this.Alpha = x, 1, this.fadeInTime));
        }
        animSequence.Insert(0, this.transform.DOScale(this._baseSize * this.maxZoom, this.zoomingTime));
        if (this.stayTime > 0)
        {
            animSequence.AppendInterval(this.stayTime);
        }
        animSequence.AppendCallback(() => onFinish.Invoke(this));
    } // DoAnim

    public void FadeOut()
    {
        DOTween.To(() => this.Alpha, x => this.Alpha = x, 1, this.fadeOutTime).OnComplete(() => { this.gameObject.SetActive(false); });
    }

}
