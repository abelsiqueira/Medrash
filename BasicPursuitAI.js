public var character : Transform;

private var player : Transform;

private var AI_state : int = 0;

function Awake () {
	player = GameObject.FindWithTag ("Medrash").transform;
}

function Update () {
	var playerDirection : Vector3 = (player.position - character.position);
	playerDirection.y = 0;
	var playerDist : float = playerDirection.magnitude;
	playerDirection /= playerDist;
	
	character.transform.Translate(playerDirection);
}