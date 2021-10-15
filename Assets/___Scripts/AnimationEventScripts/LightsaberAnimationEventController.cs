using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsaberAnimationEventController : MonoBehaviour
{
    public Lightsaber lightsaberScript;
    public PlayerController player;

    public void ExecuteTrigger()
    {
        Debug.Log(GameController.instance.willHit);
        if (GameController.instance.willHit)
        {
            lightsaberScript.HitParticleExecuter();
            player.RandomDeadAnimationHandler();
        }
    }
}
