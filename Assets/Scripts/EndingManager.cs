using System;
using System.Collections.Generic;
using UnityEngine;

public class EndingManager : MonoBehaviour
{
    public static EndingManager instance;

    public GameObject ending1;
    public GameObject ending2;
    public GameObject ending3;
    public GameObject ending4;
    public GameObject endingTime;

    public GameObject globalPopup;
    public GameObject timer;
    public GameObject counter;
    public GameObject noticiero;
    public List<CollectObject> objects;

    public int objectsNeeded = 5;
    int objectsCollected = 0;

    bool endingShown = false;

    public Action<int> onObjectCollected;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        foreach (var obj in objects)
        {
            obj.SetManager(this);
        }
    }

    public void ObjectCollected()
    {
        if (endingShown) return;

        objectsCollected++;

        onObjectCollected?.Invoke(objectsCollected);

        if (objectsCollected >= objectsNeeded)
        {
            ShowScoreEnding();
        }
    }

    void ShowScoreEnding()
    {
        endingShown = true;

        ActivateGlobalPopup();
        DisableAllHotspots();
        DisableOthers();

        int score = ScoreManager.instance.score;

        if (score < 40)
            ending1.SetActive(true);
        else if (score <= 70)
            ending2.SetActive(true);
        else
            ending3.SetActive(true);
    }

    public void TimeUp()
    {
        if (endingShown) return;

        endingShown = true;

        ActivateGlobalPopup();
        DisableAllHotspots();
        DisableOthers();

        ending4.SetActive(true);

        endingTime.SetActive(true);
    }

    void ActivateGlobalPopup()
    {
        if (globalPopup != null)
            globalPopup.SetActive(true);
    }

    void DisableAllHotspots()
    {
        foreach (var obj in objects)
        {
            if (obj != null)
                obj.gameObject.SetActive(false);
        }
    }

    void DisableOthers()
    {
        if (timer != null)
            timer.SetActive(false);

        if (counter != null)
            counter.SetActive(false);

        if (noticiero != null)
            noticiero.SetActive(false);
    }

    public bool IsEndingShown()
    {
        return endingShown;
    }
}
