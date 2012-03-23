using UnityEngine;
using System.Collections;

public class ShakeThemFall : MonoBehaviour {
	
	public GameObject Wreckage;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter () {
		Debug.Log("Collision");
		enabled = true;
	}
	
	void OnEnable () {
		Debug.Log("Enabled");
		Destroy(gameObject);
		Instantiate(Wreckage, transform.position, Random.rotation);
		CreateWreckages(10);
	}
	
	void CreateWreckages (int N) {
		// Number of wreckages: 3*N*(N+1) + 1
		for (int i = 1; i < N; i++) {
			float theta = Mathf.PI/i;
			float radius = 0.2f*i;
			for (int j = 0; j < 6*i; j++) {
				Vector3 pos = transform.position;
				pos.x += radius*Mathf.Cos(theta*j);
				pos.z += radius*Mathf.Sin(theta*j);
				Instantiate(Wreckage, pos, Random.rotation);
			}
		}
	}
}
