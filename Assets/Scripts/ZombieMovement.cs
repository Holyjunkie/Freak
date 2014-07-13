using UnityEngine;
using System.Collections;

public class ZombieMovement : MonoBehaviour
{
	public float zedSpeed;
	public int zedHealth;

	void Start()
	{
		zedSpeed = HashIDs.zombieSpeed;
		zedHealth = HashIDs.zombieHealth;
	}
}
