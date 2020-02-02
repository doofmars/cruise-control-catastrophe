using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaaace : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _spriteRenderer.transform.Rotate(Vector3.forward * 0.001f);
    }
}
