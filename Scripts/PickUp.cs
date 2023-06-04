using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PickUp : MonoBehaviour
{
    public int totalWeapons = 6;
    private int collectedWeapons = 0;
    public TextMeshProUGUI weaponCountText;

    public float totalTime = 120f;  // Total time in seconds
    private float currentTime;    // Current time in seconds
    public float increaseTime = 60f;
    public TextMeshProUGUI timerText;

    private void Start()
    {
        currentTime = totalTime;
        UpdateTimerText();
        UpdateWeaponCountText();
    }

    private void Update()
    {
        if (currentTime > 0f)
        {
            currentTime -= Time.deltaTime;
            if (currentTime < 0f)
            {
                currentTime = 0f;
                MoveToScene2(); // Loss
            }

            UpdateTimerText();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            collectedWeapons++;

            if (collectedWeapons == totalWeapons+1)
            {
                Debug.Log("All Colected");
                MoveToScene3();
            }

            other.gameObject.SetActive(false);
            Debug.Log("Collected weapon " + collectedWeapons + "/" + totalWeapons);

            // Add increaseTime seconds to the timer
            currentTime += increaseTime;
            if (currentTime > totalTime)
            {
                currentTime = totalTime; // Prevent exceeding the maximum time
            }

            UpdateWeaponCountText();
        }
    }

    private void UpdateWeaponCountText()
    {
        if (weaponCountText != null)
        {
            weaponCountText.text = collectedWeapons.ToString();
        }
    }

    private void UpdateTimerText()
    {
        if (timerText != null)
        {
            int seconds = Mathf.FloorToInt(currentTime);
            string timeString = string.Format("{0}", seconds);
            timerText.text = "Time: " + timeString;
        }
    }

    private void MoveToScene2()     // loss
    {
        SceneManager.LoadScene(2); // Replace "Scene1" with the actual scene name you want to load
    }
    private void MoveToScene3()     // Win
    {
        SceneManager.LoadScene(3); // Replace "Scene1" with the actual scene name you want to load
    }
}
