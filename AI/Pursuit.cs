using UnityEngine;
using System.Collections;

public class Pursuit : State {

	public override void Handle (EnemyAI context) {
		if (context.playerIsFar())
			context.State = new Idle();
		else
			context.direction = (context.player.transform.position - context.transform.position).normalized;
	}
}
