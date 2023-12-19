using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject damageTextPrefab;

    public Canvas gameCanvas;

    private void Awake()
    {
        gameCanvas = FindObjectOfType<Canvas>();
    }

    private void OnEnable()
    {
        CharacterEvents.characterDamaged += TookDamage;
    }

    private void OnDisable()
    {
        CharacterEvents.characterDamaged -= TookDamage;
    }
    public void TookDamage(GameObject character, int damageReceived)
    {
        Vector3 spawnPosition = Camera.main.WorldToScreenPoint(character.transform.position);

        TMP_Text tmpText = Instantiate(damageTextPrefab, spawnPosition, damageTextPrefab.transform.rotation, gameCanvas.transform).GetComponent<TMP_Text>();
        tmpText.text = damageReceived.ToString();
    }
}
