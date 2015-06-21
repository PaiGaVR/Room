using UnityEngine;
using System.Collections;

public class InitHead : MyScripts
{

    private GameObject menuObject;

    private bool flag = true;

    private Transform cursor;

    private UISprite sprite;

    private RaycastHit headRatcastHit;

    protected override void CreateDo()
    {
    }

    public void turn(bool flag)
    {
        this.flag = flag;
    }

    void Update()
    {
        if (flag)
        {
            if (Physics.Raycast(MyController.getHeadRay(), out headRatcastHit, 3f))
            {
                if (headRatcastHit.transform != null)
                {
                    cursor = headRatcastHit.transform.GetChild(1);
                    sprite = cursor.GetChild(0).GetComponent<UISprite>();
                    setMenuObjectHover(sprite);
                }
            }
        }
    }
 
    public void setMenuObjectHover(UISprite sprite)
    {
        sprite.fillAmount += Time.deltaTime;
 
        if (sprite.fillAmount >= 1f)
        {
            sprite.fillAmount = 0f;
            MyController.CreatePrefabInTransform(headRatcastHit.transform, MyEnum.ScaneObjectType.FunctionMenu, transform.position - transform.forward.normalized);
            flag = false;
        }
        else
        {
            sprite.fillAmount = 0f;
        }
    }

    public RaycastHit getRaycastHit()
    {
        return headRatcastHit;
    }

    protected override void DestroyDo()
    {
        Destroy(menuObject);
    }
}
