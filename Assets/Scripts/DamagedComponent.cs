using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedComponent : MonoBehaviour
{
    [SerializeField] public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetValue(.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
