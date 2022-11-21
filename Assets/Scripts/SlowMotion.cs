using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    public float slowMotionTimescale;

    float startTimescale;
    float startFixedDeltaTime;

    private void Awake()
    {
        GameManager.Instance.slowMotion = this; // make script accessible to GameManager singleton instance
    }

    void Start()
    {
        startTimescale = Time.timeScale;
        startFixedDeltaTime = Time.fixedDeltaTime;
    }

    public void start(float value)
    {
        Time.timeScale = value;
        Time.fixedDeltaTime = startFixedDeltaTime * value;
    }

    public void start()
    {
        Time.timeScale = slowMotionTimescale;
        Time.fixedDeltaTime = startFixedDeltaTime * slowMotionTimescale;
    }

    public void stop()
    {
        Time.timeScale = startTimescale;
        Time.fixedDeltaTime = startFixedDeltaTime;
    }
}