using UnityEngine;
using System.Collections;

public class CreateIconMenu : MyScripts
{

    private float topY = -100f;
    private float downY = 100f;


    protected override void CreateDo()
    {
        if (transform.tag.Equals("DiMianWuTi"))
        {
            getTopPoint(transform);
            MyController.CreatePrefabInTransform(transform, MyEnum.ScaneObjectType.icon, new Vector3(transform.position.x, topY, transform.position.z));
        }
        else if (transform.tag.Equals("TianHuaBanWuTi"))
        {
            getDownPoint(transform);
            MyController.CreatePrefabInTransform(transform, MyEnum.ScaneObjectType.icon, new Vector3(transform.position.x, downY, transform.position.z));
        }
        else
        {

        }
    }

    protected override void DestroyDo()
    {

    }

    private void getTopPoint(Transform tran)
    {
        foreach (Transform trams in tran)
        {
            if (trams.childCount == 0)
            {
                foreach (Vector3 vec in trams.GetComponent<Mesh>().vertices)
                {
                    if (vec.y > topY)
                    {
                        topY = vec.y;
                    }
                }
            }
            else
            {
                getTopPoint(trams);
            }
        }
    }

    private void getDownPoint(Transform tran)
    {
        foreach (Transform trams in tran)
        {
            if (trams.childCount == 0)
            {
                foreach (Vector3 vec in trams.GetComponent<Mesh>().vertices)
                {
                    if (vec.y < downY)
                    {
                        downY = vec.y;
                    }
                }
            }
            else
            {
                getDownPoint(trams);
            }
        }
    }

}
