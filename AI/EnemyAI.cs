using UnityEngine;
using System.Collections;

[RequireComponent (typeof (CharacterController))]
public class EnemyAI : MonoBehaviour {
	
	public  GameObject player;
	public  float      minDistance =  3.0f;
	public  float      maxDistance = 10.0f;
	public  Vector3    direction;
	public  float      speed = 2.0f;
	
	private CharacterController controller;
	
	private State state;
	
	public State State {
		get {
			return state;
		}
		set {
			state = value;
		}
	}
	
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
		state = new Idle();
		player = GameObject.FindGameObjectWithTag("Player");
		
		direction = transform.TransformDirection(Vector3.forward);
		
		StartCoroutine(UpdateFSM());
	}
	
	// Update is called once per frame
	void Update () {
		//controller.SimpleMove (speed * transform.forward);
		controller.SimpleMove (speed * direction);
		transform.forward = Vector3.Slerp(transform.forward, direction, 5.0f*Time.deltaTime);
	}
	
	IEnumerator UpdateFSM () {
		while (true) {
			state.Handle(this);
			
			yield return new WaitForSeconds(0.1f);
		}
	}
	
	public bool playerIsClose () {
		Vector3 d = transform.position - player.transform.position;
		
		if (d.sqrMagnitude <= minDistance*minDistance)
			return true;
		return false;
	}
	
	public bool playerIsFar () {
		Vector3 d = transform.position - player.transform.position;
		
		if (d.sqrMagnitude > maxDistance*maxDistance)
			return true;
		return false;
	}
}

