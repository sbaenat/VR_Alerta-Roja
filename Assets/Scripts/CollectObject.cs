using UnityEngine;

public class CollectObject : MonoBehaviour
{
    EndingManager endingManager;

    public int scoreValue = 10;

    bool alreadyCollected = false;

    public void SetManager(EndingManager manager)
    {
        endingManager = manager;
    }

    public void OnClick()
    {
        if (alreadyCollected) return;

        alreadyCollected = true;

        ScoreManager.instance.AddScore(scoreValue);

        endingManager.ObjectCollected();
    }
}
