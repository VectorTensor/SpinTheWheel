using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RotateSquare : MonoBehaviour
{
    public RectTransform circle;
    public float spinDuration = 3f; // Duration of the spinning animation
    public float stopRotation = 180f; // Rotation angle where the circle should stop

    private bool isSpinning = false;

    public void StartSpinning()
    {
        if (!isSpinning)
        {
            StartCoroutine(SpinCoroutine());
        }
    }

    private IEnumerator SpinCoroutine()
    {
        isSpinning = true;

        float startRotation = circle.rotation.eulerAngles.z;
        float targetRotation = startRotation + 360f;

        // Calculate the number of degrees to rotate per second
        float degreesPerSecond = 360f / spinDuration;

        float currentRotation = startRotation;
        float elapsedTime = 0f;

        while (elapsedTime < spinDuration)
        {
            // Update the rotation based on the elapsed time and degrees per second
            currentRotation += degreesPerSecond * Time.deltaTime;

            // Ensure the rotation remains within 0-360 degrees range
            if (currentRotation >= 360f)
            {
                currentRotation -= 360f;
            }

            circle.rotation = Quaternion.Euler(0f, 0f, currentRotation);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Snap the circle to the final rotation
        circle.rotation = Quaternion.Euler(0f, 0f, targetRotation);

        isSpinning = false;
    }
}

