using System.Collections;
using System.Threading;
using UnityEngine;

public class ForceRenderRate : MonoBehaviour
{
    //public float Rate = 50.0f;
    //float currentFrameTime;
    public int target = 120;

    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 120;
        //currentFrameTime = Time.realtimeSinceStartup;
        //StartCoroutine("WaitForNextFrame");
    }

    void Update() {
        if (target != Application.targetFrameRate) {
            Application.targetFrameRate = target;
        }
    }

/*
    IEnumerator WaitForNextFrame()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            currentFrameTime += 1.0f / Rate;
            var t = Time.realtimeSinceStartup;
            var sleepTime = currentFrameTime - t - 0.01f;
            if (sleepTime > 0)
                Thread.Sleep((int)(sleepTime * 1000));
            while (t < currentFrameTime)
                t = Time.realtimeSinceStartup;
        }
    }
    */

}
