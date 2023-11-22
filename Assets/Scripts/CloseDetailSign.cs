using UnityEngine;
using UnityEngine.UI;

public class CloseDetailSign : MonoBehaviour
{
    void Awake()
    {
        GetComponent<Button>().onClick.AddListener(CloseDetail);
    }

    private void CloseDetail()
    {
        InteractableItemManager.GetInstance().ReactivateCurrentSign();
        transform.parent.gameObject.SetActive(false);
    }
}
