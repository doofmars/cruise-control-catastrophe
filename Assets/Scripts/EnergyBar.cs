using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBar : MonoBehaviour
{
    public Transform bar;
    private Vector3 vector3 = new Vector3(1f, 1f);
    private AudioSource _shieldsfx;
    private bool _shielddown = false;

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
        _shieldsfx = gameObject.GetComponent<AudioSource>();
    }


    private void FixedUpdate()
    {
        if (!_shielddown)
        {
            if (_currentEnergy <= 0.0f)
            {
                _shieldsfx.Play();
                _shielddown = true;
            }
        }
        if (_currentEnergy > 0.0f)
            _shielddown = false;


    }

    public bool IsFull()
    {
        return currentEnergy >= maxEnergy;
    }
}
