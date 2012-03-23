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
		
		if (hit.gameObject.name == "WreckablePlane") {
			hit.gameObject.GetComponent<ShakeThemFall>().enabled = true;
			//Debug.Log(script);
			return;
		}
		Rigidbody body = hit.collider.attachedRigidbody;	
		if (body == null || body.isKinematic) {
			//Debug.Log("No RigidBody");
			return;
		}
	}
}
