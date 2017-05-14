using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreenFakeLoader : MonoBehaviour {

    private Action<float> _statusUpdate;
    private Action _onDone;

    public void Load(Action<float> statusUpdate, Action onDone)
    {
        this._statusUpdate = statusUpdate;
        this._onDone = onDone;

        StartCoroutine(this.FakeLoader());
    } // Load

    IEnumerator FakeLoader()
    {
        float loadTime = 5.0f; // 5 seconds
        float updateStatusDelta = 0.1f; // 0.1 second
        float endTime = Time.realtimeSinceStartup + loadTime;
        float statusUpdatedTime = 0;
        do
        {
            if (statusUpdatedTime < (Time.realtimeSinceStartup - updateStatusDelta))
            {
                float processTime = loadTime - (endTime - Time.realtimeSinceStartup);
                if (this._statusUpdate != null)
                {
                    this._statusUpdate.Invoke(processTime / loadTime * 100.0f);
                }
                statusUpdatedTime = Time.realtimeSinceStartup;
            }
            yield return new WaitForEndOfFrame();

        } while (Time.realtimeSinceStartup < endTime);

        this._statusUpdate.Invoke(100.0f); // 100%

        if (this._onDone != null)
        {
            this._onDone.Invoke();
        }
    } // FakeLoader

} // SplashScreenFakeLoader