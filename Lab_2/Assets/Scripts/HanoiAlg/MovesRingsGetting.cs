using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class MovesRingsGetting : MonoBehaviour
    {
        public TMP_InputField RingsNum;

        private static List<Tuple<int, int>> moves;

        public void GetTheMovesRings()
        {
            VarsHolder.RingsNum = int.Parse(RingsNum.text);
            VarsHolder.Moves = Solve(VarsHolder.RingsNum);
            SceneChanger.ChangeTheScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public static List<Tuple<int, int>> Solve(int n)
        {
            moves = new List<Tuple<int, int>>();
            MoveRings(n, 0, 1, 2);
            return moves;
        }

        private static void MoveRings(int n, int source, int auxiliary, int target)
        {
            if (n > 0)
            {
                MoveRings(n - 1, source, target, auxiliary);
                moves.Add(Tuple.Create(source, target));
                MoveRings(n - 1, auxiliary, source, target);
            }
        }
    }
}
