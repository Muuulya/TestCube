using UnityEngine;
using DG.Tweening;

public class Cube : MonoBehaviour
{
    public void Initialize(float duration, Vector3 finish)
    {
        var sequence = DOTween.Sequence();
        sequence.Append(gameObject.transform.DOMove(finish, duration));
        sequence.AppendCallback((() => Destroy(gameObject)));
    }
}
