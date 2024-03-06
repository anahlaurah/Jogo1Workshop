using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationscripts : MonoBehaviour
{
    private Animator animator;
    private playermov moveControl;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        moveControl = GetComponent<playermov>();
    }

    // Update is called once per frame
    void Update()
    {
        FlipLogic();
        AnimationLogic();
    }

        public void FlipLogic()
    {
        if (moveControl.MoveValue.x > 0)
        {
            Flip(1);
        }
        else if (moveControl.MoveValue.x < 0)
        {
            Flip(-1);
        }
    }

    public void Flip(int dir)
    {
        Vector2 theScale = transform.localScale;
        theScale.x = dir;
        transform.localScale = theScale;
    }

    public void AnimationLogic()
    {
        animator.SetFloat("Horizontal", moveControl.MoveValue.x);
    }






}
