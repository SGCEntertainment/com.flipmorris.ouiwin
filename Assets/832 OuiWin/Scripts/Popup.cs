using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Popup : MonoBehaviour
{
    public void SetData(UnityAction action)
    {
        GetComponent<Button>().onClick.AddListener(action);
    }
}
