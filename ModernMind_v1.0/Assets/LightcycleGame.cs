using UnityEngine;
using System.Collections;

public class LightCycle : MonoBehaviour
{
    public GameObject player;
    public GameObject startingPositionCube;
    public GameObject rotatingObject;
    public Light sceneLight;

    public Color greenColor = new Color32(0x0B, 0xFF, 0x00, 0xFF);
    public Color redColor = new Color32(0xFF, 0x27, 0x00, 0xFF);

    public float minGreenTime = 1f;
    public float maxGreenTime = 3f;
    public float minRedTime = 1f;
    public float maxRedTime = 3f;
    public float freezeDuration = 0.5f;
    public float rotationSpeed = 120f;

    private bool isRedLight = false;
    private bool redDelayActive = false;
    private bool isFrozen = false;
    private Vector3 lastPlayerPosition;

    private void Start()
    {
        if (player == null || startingPositionCube == null) { enabled = false; return; }
        if (sceneLight == null)
        {
            sceneLight = GetComponent<Light>();
            if (sceneLight == null) { enabled = false; return; }
        }

        lastPlayerPosition = player.transform.position;
        StartCoroutine(LightCycleRoutine());
    }

    private IEnumerator LightCycleRoutine()
    {
        while (true)
        {
            SetLightColor(greenColor);
            isRedLight = false;
            redDelayActive = false;
            StartCoroutine(RotateToAngle(-90f));
            yield return new WaitForSeconds(Random.Range(minGreenTime, maxGreenTime));

            SetLightColor(redColor);
            isRedLight = true;
            StartCoroutine(RotateToAngle(90f));
            yield return new WaitForSeconds(0.4f);
            redDelayActive = true;
            yield return new WaitForSeconds(Random.Range(minRedTime, maxRedTime));
        }
    }

    private IEnumerator RotateToAngle(float targetY)
    {
        if (rotatingObject == null) yield break;
        Quaternion startRot = rotatingObject.transform.rotation;
        Quaternion endRot = Quaternion.Euler(0f, targetY, 0f);
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * rotationSpeed / 90f;
            rotatingObject.transform.rotation = Quaternion.Slerp(startRot, endRot, t);
            yield return null;
        }
    }

    private void Update()
    {
        if (isRedLight && redDelayActive && !isFrozen)
        {
            Vector3 currentPos = player.transform.position;
            if (Vector3.Distance(currentPos, lastPlayerPosition) > 0.01f)
                StartCoroutine(PlayerCaught());
            lastPlayerPosition = currentPos;
        }
        else
        {
            lastPlayerPosition = player.transform.position;
        }
    }

    private void SetLightColor(Color color)
    {
        if (sceneLight != null) sceneLight.color = color;
    }

    private IEnumerator PlayerCaught()
    {
        isFrozen = true;
        Debug.Log("Player moved during RED LIGHT!");
        player.transform.position = startingPositionCube.transform.position;
        yield return new WaitForSeconds(freezeDuration);
        isFrozen = false;
    }
}
