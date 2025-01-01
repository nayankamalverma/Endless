using UnityEngine;

namespace Assets.Scripts.Player
{

    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private CapsuleCollider collider;
        [SerializeField] private Rigidbody rigidbody;
        [SerializeField] private float jumpForce;
        [SerializeField] private Vector3 slideScale;

        public float laneWidth = 2.0f; // Width of each lane
        public float moveSpeed = 10.0f; // Speed of side movement
        private int currentLane = 1; // Current lane (0 = left, 1 = middle, 2 = right)
        public float verticalSpeed = 10.0f; // Speed of vertical movement

        private void Start()
        {
            currentLane = 1;
        }

        void Update()
        {
            // Handle input for lane change
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // Change lane based on horizontal input
            if (horizontalInput < 0 && currentLane > 0)
            {
                ChangeLane(-1);
            }
            else if (horizontalInput > 0 && currentLane < 2)
            {
                ChangeLane(1);
            }

            // Move vertically based on vertical input
            Vector3 verticalMovement = new Vector3(0, verticalInput * verticalSpeed * Time.deltaTime, 0);
            transform.Translate(verticalMovement);
        }

        void ChangeLane(int direction)
        {
            currentLane += direction;
            Vector3 targetPosition = new Vector3(currentLane * laneWidth, transform.position.y, transform.position.z);
            StartCoroutine(MoveToPosition(targetPosition));
        }

        System.Collections.IEnumerator MoveToPosition(Vector3 target)
        {
            while (transform.position.x != target.x)
            {
                transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
                yield return null;
            }
        }
    }

}
