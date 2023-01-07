using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TestDiUser : MonoBehaviour
{
   [Inject] private ILogger logger;

    private void Update()
    {
        logger.Log("working!");
    }
}
