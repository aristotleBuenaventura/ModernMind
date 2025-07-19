using UnityEngine;
using TMPro;

public class CorrectValue : MonoBehaviour
{

    public TextMeshProUGUI key;
    public KeyManager keyValue;

    void Update()
    {
        key.text = keyValue.GetKeyCount().ToString();
    }

}
