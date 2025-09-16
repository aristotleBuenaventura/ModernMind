using UnityEngine;

public class AtlasCounter : MonoBehaviour
{
    private int counter = 0;
    public Scene2CanvasManager canvas;

    public void CounterIncrement()
    {
        counter++;
        if (counter == 5)
        {
            canvas.C21CanvasShow();
            Debug.Log("ATLAS DONE!!!");
        }
    }
}
