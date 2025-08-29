using UnityEngine;

public class ShowStore : MonoBehaviour
{
    public GameObject store, layunin;
    public bool layuninActivated = false; // flag para malaman kung na-run na

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            store.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            store.SetActive(false);
            ActivateLayunin(); // reuse function para one place lang ang logic
            Debug.Log("WORKING ANG LAYUNIN OUT");
        }
    }

    public void CloseStore()
    {
        store.SetActive(false);
    }

    // 🔹 Function para siguradong once lang mag-aactivate
    public void ActivateLayunin()
    {
        Debug.Log("CALLED ActivateLayunin, flag = " + layuninActivated);

        if (layuninActivated)
        {
            layunin.SetActive(true);
            Debug.Log("WORKING ANG LAYUNIN IN");
            layuninActivated = false;
        }
    }

}
