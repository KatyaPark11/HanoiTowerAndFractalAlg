using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Assets.Scripts.VarsHolder;

public class AutoStepMoves : MonoBehaviour
{
    public Toggle AutoStep;
    private int cycleStep = 20;
    private int currentCycle = 0;

    private void FixedUpdate()
    {
        if (CurrentStep != Moves.Count)
        {
            if (currentCycle % cycleStep == 0)
            {
                currentCycle = 0;
                MoveRings.AutoMove();
            }
            currentCycle++;
        }
        else
        {
            AutoStep.isOn = false;
            gameObject.SetActive(false);
        }
    }
}
