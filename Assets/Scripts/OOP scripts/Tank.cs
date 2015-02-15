using UnityEngine;
using System.Collections;

public class Tank : DesuctibleObject
{
    private Transform[] transforms;//naar base class
    protected Transform Turret;//naar base class
    protected Vector3 targetPos;
    public GameObject bulletPrefab;
    private GameObject turret;
    private GameObject nozzle;
    public Camera camera;

	// Use this for initialization
protected virtual void Start () {
   
    bool turretFound = false;

    Transform[] transforms = GetComponentsInChildren<Transform>();
    foreach (Transform t in transforms)
    {
        if (t.gameObject.name == "Turret")
        {
            turret = t.gameObject;
        }
        if (t.gameObject.name == "nozzle")
        {
            nozzle = t.gameObject;
        }
    }

        if (!turretFound)
        {
            print("ok");
        }
	}

	
	// Update is called once per frame
	 protected virtual void Update () {

         Vector3 mousePos = Input.mousePosition;//(x,y,z)
         mousePos.z = camera.transform.position.y - Turret.transform.position.y;   //- (Turret.transform.localPosition.y - this.transform.position.y);

         Vector3 worldPos = camera.ScreenToWorldPoint(mousePos);

         targetPos = worldPos;

        Turret.LookAt(targetPos);

	}
        

}