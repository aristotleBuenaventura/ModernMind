using UnityEngine;
using TMPro;

public class KeyDisplay : MonoBehaviour
{

    public TextMeshProUGUI key;
    public KeyManager keyValue;

    void Update()
    {
        key.text = keyValue.GetKeyCount() + "/20";
    }

}
