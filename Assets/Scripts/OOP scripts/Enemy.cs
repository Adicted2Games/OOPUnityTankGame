using UnityEngine;
using System.Collections;

public class Enemy : Tank {
    public Transform player;
    private float reloadTime;
    public float timeToReload;
    public GameObject bulletPrefab;
    private Transform turret;
    private Transform nozzle;
    public float shootingRange;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame

    void Update()
    {

        if (player != null)
        {
            targetPos = player.position;

            base.Update();
        }

        reloadTime += Time.deltaTime;
        if (reloadTime >= timeToReload)
        {
            CheckForPlayer();

        }


    }

    public void CheckForPlayer()
    {
        Ray myRay = new Ray();

        myRay.origin = turret.position;
        myRay.direction = turret.forward;

        RaycastHit hitInfo;

        //checken met behulp van raycast of de player in zicht is
        if (Physics.Raycast(myRay, out hitInfo, shootingRange))
        {

            string hitObjectName = hitInfo.collider.gameObject.name;


            if (hitObjectName == "Tank1")
            {
                Instantiate(bulletPrefab, nozzle.position, nozzle.rotation);

                reloadTime = 0f;
            }
        }


    }
}
