using UnityEngine;
using System.Collections;

public class Collisions : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnControllerColliderHit (ControllerColliderHit hit) {
		Rigidbody body = hit.collider.attachedRigidbody;
		if (hit.gameObject.name == "WreckablePlane") {
			Debug.Log("WreckablePlane");
			return;
		}
			
		if (body == null || body.isKinematic) {
			//Debug.Log("No RigidBody");
			return;
		}
		
		Debug.Log("CharColl");
	}
}
