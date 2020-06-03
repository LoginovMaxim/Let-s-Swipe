using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WorldPalette : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _valueColorOffset;
    [SerializeField] private float _saturation;
    [SerializeField] private float _value;

    private float _colorOffset;
    private int _schemeColor;

    private float _fixedSaturation;
    private float _fixedValue;

    public Color PlayerColor { get; private set; }
    public Color BackgroundUpColor { get; private set; }
    public Color BackgroundDownColor { get; private set; }
    public Color EnemyColor { get; private set; }
    public Color CubesColor { get; private set; }

    private void Awake()
    {
        _fixedSaturation = _saturation;
        _fixedValue = _value;

        _colorOffset = GradToHSV(_valueColorOffset);

        _schemeColor = Random.Range(0, 6);
        UpdateAllColors();

        _player.ChangedColor += OnChangeSaturation;
    }

    public void UpdateAllColors()
    {
        switch (_schemeColor)
        {
            case 0:
                {
                    SetAllColors(GradToHSV(180f), GradToHSV(0f));
                    break;
                }
            case 1:
                {
                    SetAllColors(GradToHSV(240f), GradToHSV(60f));
                    break;
                }
            case 2:
                {
                    SetAllColors(GradToHSV(300f), GradToHSV(120f));
                    break;
                }
            case 3:
                {
                    SetAllColors(GradToHSV(360f), GradToHSV(180f));
                    break;
                }
            case 4:
                {
                    SetAllColors(GradToHSV(60f), GradToHSV(240f));
                    break;
                }
            case 5:
                {
                    SetAllColors(GradToHSV(120f), GradToHSV(300f));
                    break;
                }
        }
    }

    private void SetAllColors(float playerHue, float emenyHue)
    {
        PlayerColor = Color.HSVToRGB(SetColor(playerHue), _saturation, _fixedValue);

        BackgroundUpColor = Color.HSVToRGB(SetColor(emenyHue + _colorOffset), _fixedSaturation, _value);
        BackgroundDownColor = Color.HSVToRGB(SetColor(emenyHue - _colorOffset), _fixedSaturation, _value);

        if(Random.Range(0, 2) == 0)
        {
            EnemyColor = Color.HSVToRGB(SetColor(emenyHue - _colorOffset / 2), _saturation * 1.333f, _value * 1.333f);
        }
        else
        {
            EnemyColor = Color.HSVToRGB(SetColor(emenyHue + _colorOffset / 2), _saturation * 1.333f, _value * 1.333f);
        }

        CubesColor = Color.HSVToRGB(SetColor(emenyHue), _saturation, _value * 1.333f);
    }

    private void OnChangeSaturation()
    {
        _saturation *= 0.99f;
        _value *= 0.99f; 
        UpdateAllColors();
    }

    private float GradToHSV(float value)
    {
        if (value == 0)
            return 0f;
        else
            return value / 360f;
    }

    private float SetColor(float value)
    {
        if (value <= 0)
            return 1f - Mathf.Abs(value);
        else
            return value;
    }

    private void OnDisable()
    {
        _player.ChangedColor -= OnChangeSaturation;
    }
}
