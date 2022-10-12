using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathParabola
{
    public static Vector3 Parabola(Vector3 start, Vector3 end, float heigh, float time)
    {
        Func<float, float> f = x => -4 * heigh * x * x + 4 * heigh * x;

        var mid = Vector3.Lerp(start, end, time);

        return new Vector3(mid.x, f(time) + Mathf.Lerp(start.y, end.y, time), mid.z);
    }
}
