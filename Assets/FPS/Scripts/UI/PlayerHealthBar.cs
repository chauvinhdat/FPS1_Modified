using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [Tooltip("Image component dispplaying current health")]
    public Image healthFillImage;
    // 2022-01-26: Image components for current lives
    public Image HealthLivesBar_1;
    public Image HealthLivesBar_2;
    public Image HealthLivesBar_3;

    Health m_PlayerHealth;

    private void Start()
    {
        PlayerCharacterController playerCharacterController = GameObject.FindObjectOfType<PlayerCharacterController>();
        DebugUtility.HandleErrorIfNullFindObject<PlayerCharacterController, PlayerHealthBar>(playerCharacterController, this);

        m_PlayerHealth = playerCharacterController.GetComponent<Health>();
        DebugUtility.HandleErrorIfNullGetComponent<Health, PlayerHealthBar>(m_PlayerHealth, this, playerCharacterController.gameObject);
    }

    void Update()
    {
        // update health bar value
        healthFillImage.fillAmount = m_PlayerHealth.currentHealth / m_PlayerHealth.maxHealth;
        // 2022=01=26 update player lives based on their currentLive counter
        switch(m_PlayerHealth.currentLive)
        {
            case 3:
                HealthLivesBar_3.color = Color.green; //green
                HealthLivesBar_2.color = Color.green;
                HealthLivesBar_1.color = Color.green;
                break;
            case 2:
                HealthLivesBar_3.color = Color.white; //white
                HealthLivesBar_2.color = Color.green;
                HealthLivesBar_1.color = Color.green;
                break;
            case 1:
                HealthLivesBar_3.color = Color.white;
                HealthLivesBar_2.color = Color.white;
                HealthLivesBar_1.color = Color.green;
                break;
            case 0:
                HealthLivesBar_3.color = Color.white;
                HealthLivesBar_2.color = Color.white;
                HealthLivesBar_1.color = Color.white;
                break;
        }
        
    }
}
