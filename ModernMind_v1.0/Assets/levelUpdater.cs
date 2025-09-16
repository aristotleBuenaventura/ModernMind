using UnityEngine;

public class levelUpdater : MonoBehaviour
{
    public string level, stage;

    public void leverUpdaterFunction()
    {
        FirebaseStageUpdater updater = FindObjectOfType<FirebaseStageUpdater>();

        if (updater != null)
        {
            updater.UpdateStage(level, stage, true);
        }
        else
        {
            Debug.LogError("FirebaseStageUpdater not found in the scene!");
        }
    }
}
