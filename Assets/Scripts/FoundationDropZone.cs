using UnityEngine;
using UnityEngine.EventSystems;

public class FoundationDropZone : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject draggedObject = eventData.pointerDrag;
        Card card = draggedObject.GetComponent<Card>();

        if (card != null && draggedObject.transform.childCount == 0)
        {
            card.transform.SetParent(this.transform);
            card.transform.localPosition = Vector3.zero; 
        }
    }
}