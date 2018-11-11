using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Manages level triggers etc.

    public GameObject PlayerPrefab;
    private GameObject Player;
    public Vector3 Offset;
    public Transform Camera;

	// Use this for initialization
	void Start ()
	{
	    Player = Instantiate(PlayerPrefab, new Vector3(-6,0,1),Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update ()
	{
		Camera.position = new Vector3(Player.transform.position.x + Offset.x, Player.transform.position.y + Offset.y, Offset.z);
	}
}
