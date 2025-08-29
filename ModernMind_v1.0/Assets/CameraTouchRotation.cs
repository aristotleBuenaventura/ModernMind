using UnityEngine;

public class CameraTouchRotation : MonoBehaviour
{
    public Transform player;        // Player to orbit around
    public GameObject cam;           // The camera object to rotate
    public float rotationSpeed = 2f; // Rotation sensitivity
    public float distance = 10f;      // Camera distance from player
    public float height = 2f;        // Camera height above player

    private Vector2 lastTouchPos;
    private bool rotating = false;
    private float currentAngle = 0f;

    void Start()
    {
        // Position the camera initially
        UpdateCameraPosition();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Check if touch is on right half of the screen
            if (touch.position.x > Screen.width / 2)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    lastTouchPos = touch.position;
                    rotating = true;
                }
                else if (touch.phase == TouchPhase.Moved && rotating)
                {
                    Vector2 delta = touch.position - lastTouchPos;
                    lastTouchPos = touch.position;

                    // Change the orbit angle based on horizontal swipe
                    currentAngle += delta.x * rotationSpeed * Time.deltaTime;

                    UpdateCameraPosition();
                }
                else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    rotating = false;
                }
            }
        }
    }

    void UpdateCameraPosition()
    {
        // Calculate position around player
        Vector3 offset = new Vector3(
            Mathf.Sin(currentAngle) * distance,
            height,
            Mathf.Cos(currentAngle) * distance
        );

        cam.transform.position = player.position + offset;
        cam.transform.LookAt(player.position + Vector3.up * 1.5f); // Looks at player's upper body
    }
}
