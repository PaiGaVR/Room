using UnityEngine;
using System.Collections;

public class m : MonoBehaviour {


    private Ray ray;

    private RaycastHit hit;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        ray.origin = transform.position;
        ray.direction = transform.forward;
        
        Debug.DrawRay(ray.origin, ray.direction, Color.blue);

        if (Physics.Raycast(ray, out hit, 100f))
        {
            hit.transform.gameObject.SetActive(false);
        }
	}
}
