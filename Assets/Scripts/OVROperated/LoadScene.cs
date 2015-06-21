using UnityEngine;
using System.Collections;

public class LoadScene : MyScripts
{
    //异步对象
    private AsyncOperation mAsyn;

    private GameObject LoadMenu;
    //Tip集合，实际开发中需要从外部文件中读取
    private string[] mTips = new string[]
    {
    "异步加载过程中你可以浏览游戏攻略",
    "异步加载过程中你可以查看当前进度",
    "异步加载过程中你可以判断是否加载完成"
    };


    protected override void CreateDo()
    {
        LoadMenu = MyController.CreatePrefabInTransform(transform, MyEnum.ScaneObjectType.LoadMenu, transform.position + transform.forward.normalized);

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
            LoadMenu.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<UILabel>().text = mTips[Random.Range(0, 3)] + "(" + (float)mAsyn.progress * 100 + "%" + ")";
        }
        else
        {
            Application.LoadLevel("home test");
            transform.gameObject.AddComponent<RootController>();
        }
    }
}