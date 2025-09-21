using UnityEngine;

public class ShowProductsWhenBoxIsGone : MonoBehaviour
{
    public GameObject Box, products;
    private bool lastState;

    private void Start()
    {
        if (Box != null)
            lastState = Box.activeSelf;
    }

    private void Update()
    {
        if (Box == null) return;

        // Check kung nagbago state
        if (Box.activeSelf != lastState)
        {
            lastState = Box.activeSelf;

            if (!Box.activeSelf)
            {
                Debug.Log("Box is now inactive (SetActive(false))");
                products.SetActive(true);
                // dito mo pwede ilagay logic para mag-show ng products
            }
        }
    }
}
