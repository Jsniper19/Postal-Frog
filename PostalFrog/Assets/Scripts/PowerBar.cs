﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour
{
    public Slider slider;
    public ChargeUp chargeUp;

    public void Update()
    {
        slider.value = chargeUp._percentage;
    }
}
