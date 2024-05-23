using RNB.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace RNB.UI
{
    /// <summary>
    /// Author: rohith.nanthan
    /// </summary>
    public class UI_ScoreDisplayer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private InventoryScriptableBase _inventory;

        private const string SCORE_TEXT = "Score";

        private void Start()
        {
            _scoreText.text = $"{SCORE_TEXT}: {_inventory.CurrentScore}";
        }

        private void OnEnable()
        {
            _inventory.OnScoreChange += UpdateScoreText;
        }

        private void OnDisable()
        {
            _inventory.OnScoreChange -= UpdateScoreText;
        }

        private void UpdateScoreText(int previousScore, int currentScore)
        {
            _scoreText.text = $"{SCORE_TEXT}: {currentScore}";
        }
    }
}
