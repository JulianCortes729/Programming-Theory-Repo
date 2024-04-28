using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class Ball1 : Ball
{
    private new void Start() {
        Speed = 8.0f;
        base.Start();
    }
}
