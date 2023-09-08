using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public static TimerManager Instance;

    float _timerTime;

    [SerializeField] Image _image;
    [SerializeField] float _maxTimerValue;

    bool _isActive;

    public UnityEvent OnTimerEnded;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("There is more than one TimerManager in the scene");
            return;
        }
        Instance = this;
        _isActive = false;
        _image.fillAmount = 1;
        _timerTime = _maxTimerValue;
    }

    private void Update()
    {
        if (!_isActive) return;
        _timerTime -= Time.deltaTime;
        _image.fillAmount = Mathf.Clamp01(_timerTime / _maxTimerValue);
        if (_timerTime <= 0f)
        {
            //Change Character
            OnTimerEnded?.Invoke();
            _timerTime = _maxTimerValue;
        }
    }
    public void PlayTimer(bool value)
    {
        if (value == _isActive) return;
        _timerTime = _maxTimerValue;
        _isActive = value;
    }
}
