using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBar : MonoBehaviour
{
    public Transform bar;
    private Vector3 vector3 = new Vector3(1f, 1f);

    public float maxEnergy = 100f;
    public float startingEnergy = 100f;
    private float _currentEnergy = 0f;
    public float currentEnergy
    {
        get { return _currentEnergy; }
        set
        {
            if (value < 0f)
            {
                _currentEnergy = 0f;
            } 
            else if (value < maxEnergy)
            {
                _currentEnergy = value;
            }
            else
            {
                _currentEnergy = maxEnergy;
            }
            vector3.x = _currentEnergy / maxEnergy;
            bar.localScale = vector3;
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        currentEnergy = startingEnergy;
    }

    public bool IsFull()
    {
        return currentEnergy >= maxEnergy;
    }
}
