using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{
    private float _minValue = 0;
    private float _maxValue = 100;

    [SerializeField] private Image fillImage;
    [SerializeField] private Slider _slider;
    [SerializeField] private Player _player;

    void Awake()
    {

        _slider.value = 5000;
        _slider.maxValue = _maxValue;
        _slider.minValue = _minValue;
    }
    void Update()
    {
        if (_slider.value <= _slider.minValue)
        {
            fillImage.enabled = false;
        }
        if (_slider.value > _slider.minValue && !fillImage.enabled)
        {
            fillImage.enabled = true;
        }
        _slider.value = _player.currentHealth;

        if (_slider.value <= 100 && _slider.value >= 70)
        {
            fillImage.color = Color.green;
        }
        else if (_slider.value < 70 && _slider.value >= 30)
        {
            fillImage.color = Color.yellow;
        }
        else if (_slider.value < 30 && _slider.value >= 0)
        {
            fillImage.color = Color.red;
        }

    }
}
