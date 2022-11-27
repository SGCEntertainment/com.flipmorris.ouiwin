using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Popup : MonoBehaviour
{
    public void SetData(UnityAction action)
    {
        GetComponentInChildren<Button>().onClick.AddListener(action);
        GetComponentInChildren<Button>().onClick.AddListener(() =>
        {
            Destroy(gameObject);
        });
    }
}
