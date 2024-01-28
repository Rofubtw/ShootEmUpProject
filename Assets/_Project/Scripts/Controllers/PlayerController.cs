using UnityEngine;

namespace ShootEmUp
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Player Movement")] [SerializeField]
        float speed = 5f;

        [SerializeField] float smoothness = 0.1f;
        [SerializeField] float leanAngle = 30f;
        [SerializeField] float leanSpeed = 4f;

        [SerializeField] GameObject model;

        [Header("Camera Bounds")] [SerializeField]
        Transform mainCamera;

        [SerializeField] float minX = -4.7f;
        [SerializeField] float maxX = 4.7f;
        [SerializeField] float minY = -2.4f;
        [SerializeField] float maxY = 2.6f;

        InputReader input;

        Vector3 currentVelocity;
        Vector3 targetPosition;

        void Start()
        {
            input = GetComponent<InputReader>();
        }

        void Update()
        {
            targetPosition += new Vector3(input.Move.x, input.Move.y, 0f) * (speed * Time.deltaTime);

            // Calculate the min and max X and Y position for the plane
            var minPlayerX = mainCamera.position.x + minX;
            var maxPlayerX = mainCamera.position.x + maxX;
            var minPlayerY = mainCamera.position.y + minY;
            var maxPlayerY = mainCamera.position.y + maxY;

            // Clamp the player's position to the camera view
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPlayerX, maxPlayerX);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPlayerY, maxPlayerY);

            // Lerp the player's position to the target position
            transform.position =
                Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothness);

            // Calculate the rotation effect
            var targetRotationAngle = -input.Move.x * leanAngle;

            var currentYRotation = transform.localEulerAngles.y;
            var newYRotation = Mathf.LerpAngle(currentYRotation, targetRotationAngle, leanSpeed * Time.deltaTime);

            // Apply the rotation effect
            transform.localEulerAngles = new Vector3(0f, newYRotation, 0f);
        }
    }
}