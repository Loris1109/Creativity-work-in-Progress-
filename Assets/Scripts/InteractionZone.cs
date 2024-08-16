using UnityEngine;

public class InteractionZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.QuestFinished();
        }
    }
}
