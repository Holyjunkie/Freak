using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PigeonCoopToolkit.Navmesh2D;

public class ZedPathTest : MonoBehaviour {

	public Transform playerTarget;
	List<Vector2> path;

	private Enemy enem;

	void Awake()
	{
		enem = GetComponent<Enemy>();
	}

	void Update()
	{
		if (enem.sus == true) {
			Debug.Log ("Path should be working");
			path = NavMesh2D.GetSmoothedPath(transform.position, playerTarget.position);

			if(path != null && path.Count != 0 && (enem.playerInSight == true | enem.playerInSight2 == true))
			{
				transform.position = Vector2.MoveTowards(transform.position, path[0], enem.speed*Time.deltaTime);
			}
			if(Vector2.Distance(transform.position,path[0]) < 0.01f)
			{
				path.RemoveAt(0);
			} 
		}
	}
}
