using UnityEngine;
using System.Collections;

[System.Reflection.Obfuscation(Exclude = true)]
public class DebugScreen : MyScripts
{
    protected override void CreateDo()
    {
        
    }

    protected override void DestroyDo()
    {
        
    }

    void Update()
    {
        UpdateTick();
    }

    void OnGUI()
    {
        DrawFps();
    }

    private void DrawFps()
    {
        if (mLastFps > 50)
        {
            GUI.color = new Color(0, 1, 0);
        }
        else if (mLastFps > 40)
        {
            GUI.color = new Color(1, 1, 0);
        }
        else
        {
            GUI.color = new Color(1f, 0, 0);
        }
        GUI.Label(new Rect(Screen.width - 100f, 10f, 60f, 30f), "fps: " + mLastFps);
    }

    private long mFrameCount = 0;
    private long mLastFrameTime = 0;
    static long mLastFps = 0;

    private void UpdateTick()
    {
        if (true)
        {
            mFrameCount++;
            long nCurTime = TickToMilliSec(System.DateTime.Now.Ticks);
            if (mLastFrameTime == 0)
            {
                mLastFrameTime = TickToMilliSec(System.DateTime.Now.Ticks);
            }

            if ((nCurTime - mLastFrameTime) >= 1000)
            {
                long fps = (long)(mFrameCount * 1.0f / ((nCurTime - mLastFrameTime) / 1000.0f));
                mLastFps = fps;
                mFrameCount = 0;
                mLastFrameTime = nCurTime;
            }
        }
    }
    public static long TickToMilliSec(long tick)
    {
        return tick / (10 * 1000);
    }
}