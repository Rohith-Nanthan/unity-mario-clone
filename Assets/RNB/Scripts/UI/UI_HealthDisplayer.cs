using RNB.Core;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace RNB.UI
{
    /// <summary>
    /// Author: rohith.nanthan
    /// </summary>
    public class UI_HealthDisplayer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _healthText;
        [SerializeField] private HealthScriptableBase _health;

        private const string HEALTH_TEXT = "Health";

        private void Start()
        {
            _healthText.text = $"{HEALTH_TEXT}: {_health.CurrentHealth}";
        }

        private void OnEnable()
        {
            _health.OnHealthChanged += UpdateScoreText;
        }

        private void OnDisable()
        {
            _health.OnHealthChanged -= UpdateScoreText;
        }

        private void UpdateScoreText(int previousHealth, int currentHealth)
        {
            _healthText.text = $"{HEALTH_TEXT}: {currentHealth}";
        }
    }
}