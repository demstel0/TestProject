using UnityEngine;
using UnityEngine.EventSystems;

public class TableauDropZone : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Card card = eventData.pointerDrag.GetComponent<Card>();
        if (card != null)
        {
            card.transform.SetParent(this.transform);
        }
    }
}