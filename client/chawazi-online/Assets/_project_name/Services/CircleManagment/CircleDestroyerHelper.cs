using System;
using Object = UnityEngine.Object;

public static class CircleDestroyerHelper
{
    public static void DestroyCircle(this Circle circle)
    {
        circle.gameObject.SetActive(false);
        OnDestroyCircle?.Invoke(circle);
        Object.Destroy(circle.gameObject);
    }


    public static event Action<Circle> OnDestroyCircle;
}