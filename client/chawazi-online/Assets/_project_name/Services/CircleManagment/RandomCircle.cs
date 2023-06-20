using UnityEngine;

public class RandomCircle : MonoBehaviour
{
    private readonly float buffer = 1f;
    private readonly float movementSpeed = 1f;
    private float boundaryX, boundaryY;
    private Vector3 targetPosition;

    private void Start()
    {
        var screenBounds =
            Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        boundaryX = screenBounds.x - buffer;
        boundaryY = screenBounds.y - buffer;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, movementSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            SetNewTargetPosition();
    }

    private void SetNewTargetPosition()
    {
        var randomX = Random.Range(-boundaryX, boundaryX);
        var randomY = Random.Range(-boundaryY, boundaryY);
        targetPosition = new Vector3(randomX, randomY, 0f);

        while (Vector3.Distance(transform.position, targetPosition) < 0.1f && Vector3.Distance(transform.position,
                   targetPosition) > 2f)
        {
            randomX = Random.Range(-boundaryX, boundaryX);
            randomY = Random.Range(-boundaryY, boundaryY);
            targetPosition = new Vector3(randomX, randomY, 0f);
        }
    }
}