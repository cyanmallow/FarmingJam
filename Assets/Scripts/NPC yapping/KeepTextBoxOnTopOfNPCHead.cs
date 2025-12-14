using UnityEngine;

public class FollowNPC : MonoBehaviour
{
    public Transform npcHead;

    RectTransform rect;

    void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    void LateUpdate()
    {
        if (npcHead == null) return;

        Vector3 screenPos = Camera.main.WorldToScreenPoint(npcHead.position);

        rect.position = screenPos + new Vector3(0, 80, 0); // offset upward
    }
}
