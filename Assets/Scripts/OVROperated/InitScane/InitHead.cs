using UnityEngine;
using System.Collections;

public class InitHead : MyScripts
{
    private LayerMask layerMask = 1 << 1;

    private GameObject menuObject;

    private bool flag = true;

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
            if (Physics.Raycast(MyController.getHeadRay(), out headRatcastHit, 3f, layerMask))
            {
                if (headRatcastHit.transform != null)
                {
                    MyController.CreatePrefabInTransform(transform.root.parent, MyEnum.ScaneObjectType.test, headRatcastHit.point);
                    //setMenuObjectHover(sprite);
                }
            }
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
