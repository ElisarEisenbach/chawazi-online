using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InitializeRandomCircles : MonoBehaviour
{
    private List<Circle> randomCircles;

    [Inject]
    public void _InitializeRandomCircles(RandomCircle randomCircle)
    {
        for (var i = 0; i < 6; i++) Debug.Log(randomCircle.name);
    }
}