using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipDamageBar : MonoBehaviour
{
    public Transform bar;
    private Vector3 vector3 = new Vector3(1f, 1f);
    public float currentDamage;
    public float maxHealth;
    void Start()
    {

    }

    void Update()
    {
        vector3.x = currentDamage / maxHealth;
        bar.localScale = vector3;
        if (currentDamage >= maxHealth)
        {
            loseGame();
        }
    }

    private void loseGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
