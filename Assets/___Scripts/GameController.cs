using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [Header("Collide angle settings")]
    public float maxDistance;
    public float minDistance;

    [Header("Players")]
    [SerializeField] private PlayerController leftPlayer;
    [SerializeField] private PlayerController rightPlayer;

    [Header("Lightsabers")]
    public Lightsaber leftLightsaber;
    public Lightsaber rightLightsaber;

    [Header("Particle Settings / Recommended is using only one player's effect!")]
    public bool leftPlayerHitParticle;
    public bool rightPlayerHitParticle;

    private float leftSaberAngle;
    private float rightSaberAngle;
    private float angleDiffirence;

    [HideInInspector]
    [Header("UI elements")]
    public Text informationText;

    [HideInInspector]
    public bool canCalculate;
    [HideInInspector]
    public bool willHit;

    public GameObject vCam;

    public void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        LightsaberParticleHandler();
    }

    public void LightsaberParticleHandler()
    {
        //for leftplayer
        if (leftPlayerHitParticle)
        {
            leftLightsaber.executeHitParticle = true;
        }
        else
        {
            leftLightsaber.executeHitParticle = false;
        }

        //for rightplayer
        if (rightPlayerHitParticle)
        {
            rightLightsaber.executeHitParticle = true;
        }
        else
        {
            rightLightsaber.executeHitParticle = false;
        }
    }

    public void AnimationsPlay()
    {
        StartCoroutine(leftPlayer.Attack());
        StartCoroutine(rightPlayer.Attack());
    }

    public void Update()
    {
        if (canCalculate)
        {
            CalculateLightsaberAngles();
        }

        //Debug.Log(angleDiffirence);
        if (angleDiffirence >= minDistance && angleDiffirence <= maxDistance)
        {
            informationText.gameObject.SetActive(true);
            willHit = true;
        }
        else
        {
            informationText.gameObject.SetActive(false);
            willHit = false;
        }
    }

    public void CalculateLightsaberAngles() // this void is calculating the angles for change text!
    {
        leftSaberAngle = leftPlayer.mesh.transform.eulerAngles.y - leftPlayer.attackAnimMoveAmount;
        rightSaberAngle = rightPlayer.mesh.transform.eulerAngles.y - rightPlayer.attackAnimMoveAmount;

        angleDiffirence = (leftSaberAngle - (-rightSaberAngle));
    }

    public void Simulate()
    {
        AnimationsPlay();
        canCalculate = false;
    }
}
