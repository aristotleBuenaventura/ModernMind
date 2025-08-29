using UnityEngine;

public class MobileCameraLook : MonoBehaviour
{
    public Transform player;       // The player transform to orbit around
    public float sensitivity = 2f; // Rotation speed
    public float minY = -40f;      // Minimum vertical angle
    public float maxY = 60f;       // Maximum vertical angle
    public Vector3 offset = new Vector3(0, 2, -4); // Camera offset from player

    private float currentX = 0f;   // Current horizontal rotation
    private float currentY = 20f;  // Current vertical rotation

    void LateUpdate()
    {
        foreach (Touch touch in Input.touches)
        {
            // Check if the touch is on the right side of the screen
            if (touch.position.x > Screen.width / 2)
            {
                if (touch.phase == TouchPhase.Moved)
                {
                    Vector2 delta = touch.deltaPosition;
                    currentX += delta.x * sensitivity * Time.deltaTime;
                    currentY -= delta.y * sensitivity * Time.deltaTime;

                    currentY = Mathf.Clamp(currentY, minY, maxY);
                }
            }
        }

        // Calculate camera position & rotation
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        Vector3 desiredPosition = player.position + rotation * offset;

        transform.position = desiredPosition;
        transform.LookAt(player.position + Vector3.up * 1.5f);
    }
}
