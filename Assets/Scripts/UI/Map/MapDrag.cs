using UnityEngine;
using UnityEngine.EventSystems;

public class MapDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {
    private Vector2 dragStartPosition;
    private RectTransform rectTransform;
    private bool isDragging = false;

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData) {
        isDragging = true;
        dragStartPosition = eventData.position;
    }

    public void OnDrag(PointerEventData eventData) {
        if (isDragging) {
            Vector2 deltaDrag = eventData.position - dragStartPosition;
            rectTransform.anchoredPosition += new Vector2(0, deltaDrag.y);
            dragStartPosition = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData) {
        isDragging = false;
    }
}
