
using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	private GameManager gameManager;
	public GameObject player;
	private Vector3 offset;


	// Use this for initialization
	void Start ()
	{
		gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
		offset = transform.position - player.transform.position;
	}

	// LateUpdate is called after Update each frame
	void LateUpdate ()
	{
		if (gameManager.isGameActive)
		{
			transform.position = player.transform.position + offset;
		}
		
	}

}























