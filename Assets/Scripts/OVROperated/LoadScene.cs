using UnityEngine;
using System.Collections;

public class LoadScene : MyScripts
{
    //异步对象
    private AsyncOperation mAsyn;

    protected override void CreateDo()
    {
        StartCoroutine(Load());
    }

    protected override void DestroyDo()
    {
        
    }

    private IEnumerator Load()
    {
        mAsyn = Application.LoadLevelAsync("home test");
        yield return mAsyn;
    }

    void Update()
    {
        //如果场景没有加载完则显示Tip，否则显示最终的界面
        if (mAsyn != null && !mAsyn.isDone)
        {
        }
        else
        {
            Application.LoadLevel("home test");
            transform.gameObject.AddComponent<RootController>();
        }
    }
}