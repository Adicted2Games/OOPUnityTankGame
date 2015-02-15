using UnityEngine;
using System.Collections;

public class TempObject : MonoBehaviour {
    private float lifetime;
    public float maxLifeTime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


        lifetime += Time.deltaTime;
        if (lifetime > maxLifeTime)
        {
            Destroy(this.gameObject);
        }
	}
}
