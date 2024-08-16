using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    [SerializeField]
    private GameObject[] Houses;

    private int housNum;
    public int questCounter;
    private bool questDone = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        Houses = GameObject.FindGameObjectsWithTag("OWQ"); //OWQ = Objects With Quests 
        SetNewQuest();
    }

    private void Update()
    {
        if(questDone == true)
        {
            SetNewQuest();
        }
    }

    private void SetNewQuest()
    {
        questDone = false;
        int newHousNum = Random.Range(0, Houses.Length);
        Houses[housNum].GetComponent<Hous>().SetActive_ForQuest(false);
        Houses[newHousNum].GetComponent<Hous>().SetActive_ForQuest(true);
        housNum = newHousNum;
    }

    public void QuestFinished()
    {
        questDone = true;
        questCounter++; 
    }
}
