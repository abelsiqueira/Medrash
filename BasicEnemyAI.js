#pragma strict

private var attackRange  : float = 10.0;
private var pursuitRange : float = 500.0;
private var tooFarRange  : float = 800.0;

public var AI_idle   : MonoBehaviour;
public var AI_pursue : MonoBehaviour;

private var character : Transform;
private var player : Transform;

private var AI_state : int = 0;

function Awake () {
	character = transform;
	player = GameObject.FindWithTag ("Medrash").transform;
	AI_idle.enabled = true;
	AI_pursue.enabled = false;
}

function OnEnable () {
	AI_idle.enabled = true;
	AI_pursue.enabled = false;
}

function Update () {
	var playerDirection : Vector3 = (player.position - character.position);
	playerDirection.y = 0;
	var playerDist : float = playerDirection.magnitude;
	playerDirection /= playerDist;
	
	if (playerDist < pursuitRange && AI_state == 0) {
		AI_pursue.enabled = true;
		AI_idle.enabled = false;
		AI_state = 1;
	} else if (playerDist > tooFarRange && AI_state != 0) {
		AI_idle.enabled = true;
		AI_pursue.enabled = false;
		AI_state = 0;
	}
	
	character.transform.Rotate (character.transform.up);
}