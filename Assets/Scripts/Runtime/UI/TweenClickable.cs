using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Core.UI
{
    public class TweenClickable : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private const float ClickScale = 0.85f;
        private const float ClickTweenDuration = 0.08f;
        
        private bool _isTweeningScale = false;
        
        public virtual void OnPointerDown(PointerEventData eventData)
        {
            if (_isTweeningScale == false)
            {
                _isTweeningScale = true;
                transform.DOScale(ClickScale, ClickTweenDuration);
            }
        }

        public virtual void OnPointerUp(PointerEventData eventData)
        {
            if (_isTweeningScale == true)
            {
                transform.DOScale(1f, ClickTweenDuration);
                _isTweeningScale = false;
            }
        }
    }
}
