using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement2D : MovingObject
{
    Animator anim;
    Rigidbody2D rb;

    int intHashHorizontal = Animator.StringToHash("horizontal");
    int intHashVertical = Animator.StringToHash("vertical");
    int intHashLastMoveX = Animator.StringToHash("lastMoveX");
    int intHashLastMoveY = Animator.StringToHash("lastMoveY");
    int intHashIsMoving = Animator.StringToHash("isMoving");

    [SerializeField]
    Vector2 lastMove;

    [SerializeField]
    float horizontal, vertical;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        horizontal = vertical = 0;
        lastMove.x = 0;
        lastMove.y = -1;
    }

    // Update is called once per frame
    void Update()
    {
        //horizontal = 0;
        //vertical = 0;

        if((horizontal = CrossPlatformInputManager.GetAxisRaw("Horizontal")) != 0)
        {
                lastMove.x = horizontal;
                lastMove.y = 0;
        }

        if((vertical = CrossPlatformInputManager.GetAxisRaw("Vertical")) != 0)
        {
                lastMove.y = vertical;
                lastMove.x = 0;
        }

        if (vertical != 0)
            horizontal = 0;
 
        if((horizontal != 0 || vertical != 0) && isMoving == false)
        {
            rb.transform.position = new Vector3();
        }

        anim.SetFloat(intHashHorizontal, lastMove.x);
        anim.SetFloat(intHashVertical, lastMove.y);
        anim.SetBool(intHashIsMoving, isMoving);

        anim.SetFloat(intHashLastMoveY, lastMove.y);
        anim.SetFloat(intHashLastMoveX, lastMove.x);
    }

    protected override void AttemptMove(int xDir, int yDir)
    {
        base.AttemptMove(xDir, yDir);

        RaycastHit2D hit;

        if (Move(xDir, yDir, out hit))
        {
            
        }
    }
}
