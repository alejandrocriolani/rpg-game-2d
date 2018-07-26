using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG
{
    public class PlayerMovement : MonoBehaviour
    {

        Animator anim;
        Rigidbody2D rb;
        BoxCollider2D frontTrigger;

        int intHashHorizontal = Animator.StringToHash("horizontal");
        int intHashVertical = Animator.StringToHash("vertical");
        int intHashLastMoveX = Animator.StringToHash("lastMoveX");
        int intHashLastMoveY = Animator.StringToHash("lastMoveY");
        int intHashIsMoving = Animator.StringToHash("isMoving");

        float horizontalAxis;
        float verticalAxis;
        [SerializeField]
        float basicVelocity;
        float velocity;

        [SerializeField]
        bool isMoving;
        bool alowMove;

        [SerializeField]
        Vector2 lastMove;

        // Use this for initialization
        void Start()
        {
            anim = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
            SetFrontTrigger();
            lastMove.x = 0;
            lastMove.y = 1;
            isMoving = false;
            alowMove = true;
            basicVelocity = 2f;
            velocity = basicVelocity;
        }

        // Update is called once per frame
        void Update()
        {
            if (alowMove)
            {
                horizontalAxis = Input.GetAxisRaw("Horizontal");
                verticalAxis = Input.GetAxisRaw("Vertical");

                if (horizontalAxis != 0.0f)
                    MoveHorizontal();

                if (verticalAxis != 0.0f)
                    MoveVertical();

                if (horizontalAxis == 0.0f)
                    StopMoveHorizontal();

                if (verticalAxis == 0.0f)
                    StopMoveVertical();

                if (verticalAxis == 0f && horizontalAxis == 0f)
                    isMoving = false;

                if (horizontalAxis != 0.0f && verticalAxis != 0.0f)
                    MoveDiagonal();
                else
                    StopMoveDiagonal();
            }

            SetAnims();
        }

        void SetFrontTrigger()
        {
            BoxCollider2D[] bcs;
            bcs = GetComponents<BoxCollider2D>();

            foreach (BoxCollider2D bc in bcs)
            {
                if (bc.isTrigger)
                    frontTrigger = bc;
            }
        }

        void MoveHorizontal()
        {
            isMoving = true;
            rb.velocity = new Vector2(horizontalAxis * velocity, rb.velocity.y);
            if (horizontalAxis > 0)
            {
                lastMove = new Vector2(1, 0);
                frontTrigger.offset = new Vector2(0.235f, -0.11f);
            }
            else
            {
                lastMove = new Vector2(-1, 0);
                frontTrigger.offset = new Vector2(-0.235f, -0.11f);
            }
        }

        void MoveVertical()
        {
            isMoving = true;
            rb.velocity = new Vector2(rb.velocity.x, verticalAxis * velocity);
            if (verticalAxis > 0)
            {
                lastMove = new Vector2(0, 1);
                frontTrigger.offset = new Vector2(0f, 0.1f);
            }
            else
            {
                lastMove = new Vector2(0, -1);
                frontTrigger.offset = new Vector2(0f, -0.33f);
            }
        }

        void StopMoveHorizontal()
        {
            //isMoving = false;
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }

        void StopMoveVertical()
        {
            //isMoving = false;
            rb.velocity = new Vector2(rb.velocity.x, 0f);
        }

        void MoveDiagonal()
        {
            velocity = basicVelocity * 7 / 10;
            isMoving = true;
        }

        void StopMoveDiagonal()
        {
            velocity = basicVelocity;
            //isMoving = false;
        }

        void SetAnims()
        {
            anim.SetBool(intHashIsMoving, isMoving);
            anim.SetFloat(intHashHorizontal, lastMove.x);
            anim.SetFloat(intHashVertical, lastMove.y);
            anim.SetFloat(intHashLastMoveY, lastMove.y);
            anim.SetFloat(intHashLastMoveX, lastMove.x);
        }

        public bool AlowMove
        {
            get { return alowMove; }
            set { alowMove = value; }
        }
    }
}
