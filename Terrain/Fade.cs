using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {
	
	public  float waitTime = 3;
	private float startTime;
	private float endTime;
	// Use this for initialization
	void Start () {
		startTime = Time.time;
		endTime = startTime + waitTime;
	}
	
	private int count = 0;
	private int enoughCount = 100;
	// Update is called once per frame
	void Update () {
		if (Time.time > endTime) {
			transform.localScale *= 0.97f;
			count++;
		} 
		if (count > enoughCount) {
			Destroy(gameObject);
		}
	}
}
