using Assets.Scripts.Events;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private CapsuleCollider collider;
        [SerializeField] private Rigidbody rigidbody;
        [SerializeField] private float jumpForce;
        [SerializeField] private float slideCollideHight;
        [SerializeField] private Animator animator;
        [SerializeField] private Vector3 spawnPosition;

        private Vector3[] pos;

        [SerializeField] private float laneWidth = 2.0f; 
        private int currentLane = 1;
        private bool isActive;
        private EventService eventService;

        public void SetService(EventService eventService)
        {
            this.eventService = eventService;
        }
        private void Awake()
        {
            isActive = false;
            pos = new Vector3[3];
            pos[1] = spawnPosition;
            pos[0] = new Vector3(transform.position.x, transform.position.y, transform.position.z +laneWidth);
            pos[2] = new Vector3(transform.position.x, transform.position.y, transform.position.z-laneWidth);
        }

        public void ResetPlayer()
        {
            isActive = false;
            currentLane = 1;
            transform.position = spawnPosition;
            animator.SetBool("running",false);
        }


        public void OnGameStart()
        {
            ResetPlayer();
            isActive = true;
            animator.SetBool("running", true) ;
        }

        public void OnGamePause()
        {
            isActive = false;
            animator.SetBool("running", false);
        }
        public void OnGameResume()
        {
            isActive = true;
            animator.SetBool("running", true);
        }


        private bool IsGrounded()
        {
            return Physics.Raycast(transform.position, Vector3.down, collider.bounds.extents.y + 0.1f);
        }

        public void Jump(InputAction.CallbackContext context)
        {

            if (context.performed && isActive )
            {
                Debug.Log("jump");
                rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                animator.SetTrigger("jump");
            }
        }

        public void Slide(InputAction.CallbackContext context)
        {
            if (context.performed && isActive)
            {
                StartCoroutine(SlideCoroutine());
            }
        }

        //needed to remove corotuine when animation is fixed 
        private IEnumerator SlideCoroutine()
        {
            // Save the original collider properties
            float originalHeight = collider.height;
            Vector3 originalCenter = collider.center;

            // Reduce the height of the collider for sliding
            collider.height = slideCollideHight;
            collider.center = new Vector3(0,slideCollideHight/2+0.024f,0);

            animator.SetTrigger("slide"); // Trigger the sliding animation

            // Wait for the duration of the slide
            
            yield return new WaitForSeconds(1.0f);

            // Reset the collider properties 
            collider.height = originalHeight;
            collider.center = originalCenter;
        }

        public void GoLeft(InputAction.CallbackContext context)
        {
            if (context.performed && isActive)ChangeLane(-1);
        }
        public void GoRight(InputAction.CallbackContext context)
        {
            if (context.performed && isActive)ChangeLane(1);
        }

        private void ChangeLane(int index)
        {
            int newLane = currentLane + index;
            if (newLane < 0 || newLane > 2) return;
            currentLane = newLane;
            float z = (1 - currentLane) * laneWidth; // Center lane (1) is 0, left (0) is positive, right (2) is negative
            //rigidbody.MovePosition(new Vector3(-4, transform.position.y, z));
        }
        private void Update()
        {
            transform.position = Vector3.Slerp(transform.position, pos[currentLane],0.1f);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision == null) Debug.Log("null");
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                eventService.OnGameEnd.Invoke();
                animator.SetBool("running", false);
                isActive = false;
            }else if (collision.gameObject.CompareTag("Coins"))
            {
                eventService.OnCoinCollected.Invoke();
            }
        }
    }
}
