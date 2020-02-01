using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Transform bar;
    private Vector3 vector3 = new Vector3(1f, 1f);

    // Start is called before the first frame update
    private void Start()
    {
    }

    public void SetValue(float value)
    {
        vector3.x = value;
        bar.localScale = vector3;
    }
}
