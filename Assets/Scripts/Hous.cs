using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hous : MonoBehaviour
{
    [SerializeField] private GameObject exclamationMark;
    [SerializeField] private GameObject interactionZone;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetActive_ForQuest(bool state)
    {
        exclamationMark.SetActive(state);
        interactionZone.SetActive(state);
    }
}
