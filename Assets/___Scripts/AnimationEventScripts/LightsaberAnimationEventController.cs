using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LightsaberAnimationEventController : MonoBehaviour
{
    public Lightsaber lightsaberScript;
    public PlayerController player;

    public void ExecuteTrigger()
    {
        Debug.Log(GameController.instance.willHit);
        if (GameController.instance.willHit)
        {
            DOTween.Play(GameController.instance.vCam);
            lightsaberScript.HitParticleExecuter();
            player.RandomDeadAnimationHandler();
        }
    }
}
