using UnityEngine;
using System.Collections;

[RequireComponent (typeof (CharacterController))]
public class BasicEnemyAI : MonoBehaviour {
	
	public enum States { State_Idle, State_Pursue }
	
	public  GameObject player;
	public  float      minDistance = 10.0f;
	public  float      maxDistance = 15.0f;
	private Vector3    moveDirection;
	public  float      speed = 3.0f;
	
	private CharacterController controller;
	
	private States state;
	
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
		state = States.State_Idle;
		player = GameObject.FindGameObjectWithTag("Player");
		
		moveDirection = transform.TransformDirection(Vector3.up);
		
		StartCoroutine(UpdateFSM());
	}
	
	// Update is called once per frame
	void Update () {
		controller.SimpleMove (speed * moveDirection);
	}
	
	IEnumerator UpdateFSM () {
		while (true) {
			if (state == States.State_Idle) {
				if (playerIsClose())
					state = States.State_Pursue;
				else
					Idle();
			} else if (state == States.State_Pursue) {
				if (playerIsFar())
					state = States.State_Idle;
				else
					Pursue();
			}
			
			yield return new WaitForSeconds(0.1f);
		}
	}
	
	bool playerIsClose () {
		Vector3 direction = transform.position - player.transform.position;
		
		if (direction.sqrMagnitude <= minDistance*minDistance)
			return true;
		return false;
	}
	
	bool playerIsFar () {
		Vector3 direction = transform.position - player.transform.position;
		
		if (direction.sqrMagnitude > maxDistance*maxDistance)
			return true;
		return false;
	}
	
	void Idle () {
		//if (Physics.Raycast (transform.position, moveDirection, 1.0f)) {
		//	moveDirection *= -1;
		//}
	}
	
	void Pursue () {
		moveDirection = (player.transform.position - transform.position).normalized;
		moveDirection = transform.TransformDirection(moveDirection);
	}
}
