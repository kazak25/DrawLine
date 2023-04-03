using DG.Tweening;
using UnityEngine;

namespace Controllers
{
    public class HelicopterPatrulController : MonoBehaviour
    {

        [SerializeField] private Transform _startPoint;
        [SerializeField] private Transform _finishPoint;

        private void Start()
        {
            transform.position = _startPoint.position;
            Move();
        }

        private void Move()
        {
            var sequence = DOTween.Sequence();
            sequence.Append(transform.DOMove(_finishPoint.position, 5f));
            sequence.Append(transform.DOMove(_startPoint.position, 5f));
            sequence.SetLoops(-1);
        }


    }
}
