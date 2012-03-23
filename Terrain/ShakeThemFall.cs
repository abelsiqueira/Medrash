using UnityEngine;
using System.Collections;

public class ShakeThemFall : MonoBehaviour {
	
	public GameObject Wreckage;
	
	public  float waitTime = 3;
	private float startTime;
	private float endTime;
	private float shaking = 0.0005f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Vector3 pos = transform.position;
		//pos.x += 0.003f*(2*Random.value - 1);
		//pos.y += 0.002f*(2*Random.value - 1);
		//pos.z += 0.003f*(2*Random.value - 1);
		Quaternion rot = transform.rotation;
		rot.x += shaking*(2*Random.value - 1);
		rot.y += shaking*(2*Random.value - 1);
		rot.z += shaking*(2*Random.value - 1);
		rot.w += shaking*(2*Random.value - 1);
		shaking *= 1.01f;
		transform.rotation = rot;
		//transform.position = pos;
		if (Time.time < endTime)
			return;
		Destroy(gameObject);
		Instantiate(Wreckage, transform.position, Random.rotation);
		CreateWreckages(10);
	}
	
	void OnCollisionEnter () {
		Debug.Log("Collision");
		enabled = true;
	}
	
	void OnEnable () {
		startTime = Time.time;
		endTime = startTime + waitTime;
		Debug.Log("Enabled");
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
