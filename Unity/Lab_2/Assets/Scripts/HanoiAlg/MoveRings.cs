using System;
using UnityEngine;
using UnityEngine.UI;
using static Assets.Scripts.VarsHolder;

namespace Assets.Scripts
{
    public class MoveRings : MonoBehaviour
    {
        public Button PrevStep;
        public Button NextStep;
        public Toggle AutoStep;
        public GameObject AutoStepAnim;

        public void StepByStepMove(int step)
        {
            MoveTheRing(step);
            ControlStepButtons();
        }

        public void ControlStepButtons()
        {
            if (PrevStep.interactable && CurrentStep == 0)
                PrevStep.interactable = false;
            else if (!PrevStep.interactable && CurrentStep > 0)
                PrevStep.interactable = true;

            if (NextStep.interactable && CurrentStep == Moves.Count)
                NextStep.interactable = false;
            else if (!NextStep.interactable && CurrentStep < Moves.Count)
                NextStep.interactable = true;
        }

        public void ChangeAutoStepMode()
        {
            if (AutoStep.isOn)
            {
                AutoStepAnim.SetActive(true);
                PrevStep.interactable = false;
                NextStep.interactable = false;
            }
            else
            {
                AutoStepAnim.SetActive(false);
                ControlStepButtons();
            }
        }

        public static void AutoMove()
        {
            MoveTheRing(1);
        }

        public static void MoveTheRing(int step)
        {
            int from = 0, to = 0;
            Tower fromTower, toTower;

            if (step == 1)
            {
                Tuple<int, int> move = Moves[CurrentStep];
                from = move.Item1;
                to = move.Item2;
            }
            else if (step == -1)
            {
                Tuple<int, int> move = Moves[CurrentStep - 1];
                to = move.Item1;
                from = move.Item2;
            }

            fromTower = Towers[from];
            toTower = Towers[to];
            GameObject ring = fromTower.Rings[^1];
            fromTower.Rings.Remove(ring);
            toTower.Rings.Add(ring);
            ring.transform.localPosition = new Vector3(toTower.CoorX,
                Tower.FirstCoorY + (toTower.Rings.Count - 1) * RingHeight, toTower.CoorX);

            CurrentStep += step;
        }
    }
}