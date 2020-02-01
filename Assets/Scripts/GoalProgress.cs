using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalProgress : MonoBehaviour
{
    // Start is called before the first frame update
    public HealthBar victoryProgress;
    public DamagedComponent engine1;
    public DamagedComponent engine2;
    public DamagedComponent engine3;

    public float progressRate = 5f;

    private int playersInsideRoom = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playersInsideRoom > 0)
        {
            int numberOfBrokenEngines = 0;
            if (engine1.healthBar.currentHealth == 0) numberOfBrokenEngines++;
            if (engine2.healthBar.currentHealth == 0) numberOfBrokenEngines++;
            if (engine3.healthBar.currentHealth == 0) numberOfBrokenEngines++;
            float ratioOfIntactEngines = (3-numberOfBrokenEngines) / 3.0f;
            victoryProgress.currentHealth += progressRate * ratioOfIntactEngines;
            if (victoryProgress.currentHealth >= victoryProgress.maxHealth)
                SceneManager.LoadScene("Win");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playersInsideRoom--;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playersInsideRoom++;
    }
}
