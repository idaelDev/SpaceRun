using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject PlayerPrefab;
    public PlayerControllerScript[] players;

	// Use this for initialization
	void Start () {
        //Instantiate players
        players = new PlayerControllerScript[4];
        for (int i = 0; i < players.Length; i++)
        {
            GameObject o = Instantiate(PlayerPrefab, new Vector3((float)i, 0f, 0f), Quaternion.identity) as GameObject;
            players[i] = o.GetComponent<PlayerControllerScript>();
            players[i].playerId = i;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
