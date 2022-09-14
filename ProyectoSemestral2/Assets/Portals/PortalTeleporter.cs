using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour {

	public Transform player;
	public Transform reciever;

	GameManager gameManager;

	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	protected void Start()
	{
		gameManager = GameObject.Find("GameManager").GetComponent <GameManager> ();
	}
	// Update is called once per frame
	void Update () {
		if (gameManager.playerIsOverlapping)
		{
			Vector3 PlayerFromPortal = transform.InverseTransformPoint(player.transform.position);
			
			if(PlayerFromPortal.z <= 0.02)
			{
				player.position = reciever.position += new Vector3(-PlayerFromPortal.x, PlayerFromPortal.y,-PlayerFromPortal.z);
				
				
				StartCoroutine(Wait());
				
			
			}
			
		}
	}
	
	IEnumerator Wait(){
		yield return new WaitForSeconds(0.1f);
		gameManager.playerIsOverlapping = false;
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player")
		{
			gameManager.playerIsOverlapping = true;
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.tag == "Player")
		{
			gameManager.playerIsOverlapping = false;
		}
	}
}
