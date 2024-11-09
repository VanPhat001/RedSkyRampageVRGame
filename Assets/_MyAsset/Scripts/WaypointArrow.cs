using DG.Tweening;
using UnityEngine;

public class WaypointArrow : MonoBehaviour
{
    void Start()
    {
        Sequence effect = DOTween.Sequence();

        effect.Append(this.transform
            .DOMove(this.transform.position + Vector3.up * 1f/2, .8f)
            .SetEase(Ease.Linear));

        effect.Append(this.transform
            .DOMove(this.transform.position, .8f)
            .SetEase(Ease.Linear));

        effect.SetLoops(-1);
    }
}