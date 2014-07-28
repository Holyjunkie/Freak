using UnityEngine;
using System.Collections;

public class RandomTreeSpawn : MonoBehaviour {
	
	public GameObject MapleTree;
	public float rateOfSpawn = 1f;

	float treeMax = 5000;
	private float nextSpawn = 0;

	// Update is called once per frame
	void Update () {
		if (treeMax > nextSpawn) {
			nextSpawn += rateOfSpawn;

			Vector3 rndPosWithin;
			rndPosWithin = new Vector3 (Random.Range(-2000f, 2000f), Random.Range(-2000f, 2000f), 0);
			rndPosWithin = transform.TransformPoint(rndPosWithin * .5f);
			Instantiate (MapleTree, rndPosWithin, transform.rotation);

			Debug.Log("Spawned a tree.");

			if(Physics.CheckSphere(transform.position, 100)){
				Debug.Log ("lel");
			}

		}
	}
}
