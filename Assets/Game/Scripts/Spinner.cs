using System;
using UnityEngine;
using DG.Tweening;

public class Spinner : MonoBehaviour
{
    public RectTransform spinBoard;
    public static float spinDuration = 3f;

    public float totalSpinDuration;

    float _targetRotation;
    public static bool isSpinning = false;

    public static Action OnSpinCompletete;

    public void SpinAnimation(Item item)
    {
        if (!isSpinning) //dont run next until its not spinning
        {
            isSpinning = true;

            float itemRotation = UnityEngine.Random.Range(item.startAngle, item.endAngle);

            _targetRotation = itemRotation;
          //  Debug.Log("_targetRotation :" + _targetRotation);
            float currentAngle = spinBoard.rotation.eulerAngles.z;
            float totalRotation;
            if ((_targetRotation - currentAngle) < 0 ){
                totalRotation = (360f * UnityEngine.Random.Range(5,8)) + (360+(_targetRotation - currentAngle));

            }
            else{
                totalRotation = (360f * UnityEngine.Random.Range(5,8)) + (_targetRotation - currentAngle);

            }
            
            float duration = spinDuration * (totalRotation / 360f);
            duration = totalSpinDuration;

            spinDuration = (duration*360f)/totalRotation;
            Debug.Log("Duration : " + duration);
            Debug.Log("total Rotation : " + totalRotation);


            spinBoard.DORotate(new Vector3(0, 0, currentAngle + totalRotation), duration, RotateMode.FastBeyond360)
                .SetEase(Ease.OutSine)
                .OnComplete(StopSpin);
        }
    }

    void StopSpin()
    {

        //isSpinning = false;
        spinBoard.rotation = Quaternion.Euler(0f, 0f, _targetRotation);

        OnSpinCompletete?.Invoke();
    }
}
