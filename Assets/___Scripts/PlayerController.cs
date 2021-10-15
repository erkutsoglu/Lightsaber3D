using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public Slider AngleSlider;
    [HideInInspector]
    public float _rotateSpeed;
    private bool isAttacing;
    public Animator anim;

    public GameObject mesh;

    public float attackAnimMoveAmount;
    public float attackAnimMoveSpeed;

    public void Update()
    {
        if (!isAttacing)
        {
            transform.rotation = Quaternion.Euler(transform.localEulerAngles.x, transform.rotation.y + (AngleSlider.value * 90), transform.localEulerAngles.z);
        }
    }

    public void RandomDeadAnimationHandler()
    {
        #region Animation Switcher
        int random = Random.Range(0, 1); //in this case we have 2 dead animation!
        switch (random)
        {
            case 0:
                anim.SetTrigger("Dead");
            break;

            case 1:
                anim.SetTrigger("Dead2");
                break;
        }
        #endregion  // if you want to set new dead animations use here!
    }

    public IEnumerator Attack()
    {
        isAttacing = true;
        anim.SetTrigger("Attack");
        yield return new WaitForSeconds(0.2f);
        mesh.transform.DORotate(new Vector3(mesh.transform.rotation.x, mesh.transform.eulerAngles.y - attackAnimMoveAmount ,mesh.transform.rotation.z), attackAnimMoveSpeed);
    }
}
