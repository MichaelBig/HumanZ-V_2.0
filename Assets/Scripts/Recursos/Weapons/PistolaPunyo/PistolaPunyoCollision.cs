﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolaPunyoCollision : MonoBehaviour {
	[SerializeField]
	PlayerDisparoPunyo player;
	float power = 100;
	// Use this for initialization
	void Start () {
		/*
        player = transform.parent.parent.parent.parent.gameObject;
        if (player == null)
            Debug.LogError("Player not founded");
        */
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Push(float distance, float enterPower){
		
		power = enterPower;
		transform.localPosition += new Vector3(0, 0, 1) * distance * Time.deltaTime;

	}

	public void Pull(float distance){
	
		transform.localPosition -= new Vector3(0, 0, 1) * distance * Time.deltaTime;

	}

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
			if (collision.gameObject.name != player.name && player.GetComponent<PlayerSetup>().isClient) {
				
                Vector3 direction = transform.parent.TransformDirection(new Vector3(0, 0, 1));
                direction = direction.normalized;
				player.CmdPunyoPush(collision.transform.name, direction, power);
                //GetComponent<Rigidbody>().AddForce(new Vector3(power*direction.x, power*direction.y, power*direction.z),ForceMode.Impulse);
            }
        }
    }
		
}