using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG
{
    public class MovingObject : MonoBehaviour
    {

        public float moveTime = 0.1f;
        public LayerMask blockingLayer;

        [SerializeField]
        protected bool isMoving;

        private BoxCollider2D boxCollider;
        private Rigidbody2D rb;
        private float inverseMoveTime;


        // Use this for initialization
        protected virtual void Start()
        {
            boxCollider = GetComponent<BoxCollider2D>();
            rb = GetComponent<Rigidbody2D>();
            inverseMoveTime = 1f / moveTime;
            isMoving = false;
        }

        protected bool Move(int xDir, int yDir, out RaycastHit2D hit)
        {
            Vector2 start = transform.position;
            Vector2 end = start + new Vector2(xDir, yDir);

            boxCollider.enabled = false;
            hit = Physics2D.Linecast(start, end);
            boxCollider.enabled = true;

            if (hit.transform == null && isMoving == false)
            {
                StartCoroutine(SmootMovement(end));
                return true;
            }

            return false;
        }

        protected IEnumerator SmootMovement(Vector3 end)
        {
            float sqrRemainingDistance = (transform.position - end).sqrMagnitude;
            Vector2 pos;
            isMoving = true;

            while (sqrRemainingDistance > float.Epsilon)
            {
                Vector3 newPosition = Vector3.MoveTowards(rb.position, end, inverseMoveTime * Time.deltaTime);
                rb.MovePosition(newPosition);
                sqrRemainingDistance = (transform.position - end).sqrMagnitude;
                yield return null;
            }

            pos.x = (int)transform.position.x;
            pos.y = (int)transform.position.y;
            transform.position = pos;
            isMoving = false;
        }

        protected virtual void AttemptMove/*<T>*/(int xDir, int yDir)
        //where T : Component
        {
            RaycastHit2D hit;
            //bool canMove = 
            Move(xDir, yDir, out hit);

            /*
            if (hit.transform == null)
                return;

            /*TGameObject hitComponent = hit.transform.GetComponent<GameObject>();*/

            /*
            if (!canMove && hitComponent != null)
                OnCantMove(hitComponent);
            */

        }

        //protected abstract void OnCantMove<T>(T component)
        //where T : Component;
    }
}

