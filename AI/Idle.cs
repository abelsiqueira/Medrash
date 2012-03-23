using UnityEngine;
using System.Collections;

public class Idle : State {
	public override void Handle (EnemyAI context) {
		if (context.playerIsClose())
			context.State = new Pursuit ();
		else
			if (Physics.Raycast (context.transform.position, context.direction, 1.0f))
				context.direction *= -1;
	}
}
			
