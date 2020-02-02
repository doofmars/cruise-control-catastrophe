using UnityEngine;

public class Room : MonoBehaviour
{
    public bool isOnFire = false;

    public GameObject fireInstance;

    public string roomName;
    public LayoutManager layoutManager;

    public float temperature = 290f;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        fireInstance.SetActive(isOnFire);
    }

    private void FixedUpdate()
    {
        var time = Time.deltaTime;
        if (isOnFire)
        {
            temperature += time * 15f;
        }
        else
        {
            temperature -= 0.1f * (temperature - 290f) * time;
        }
    }
}
