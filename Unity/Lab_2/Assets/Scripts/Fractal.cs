using System.Diagnostics;
using UnityEngine;

namespace Assets.Scripts
{
    public class Fractal : MonoBehaviour
    {
        public static Process Process;

        public static void DrawTheFractalTree()
        {
            string applicationPath = "..\\..\\FractalTree1\\FractalTree1\\bin\\Debug\\FractalTree.exe";

            ProcessStartInfo startInfo = new()
            {
                FileName = applicationPath
            };

            Process = new()
            {
                StartInfo = startInfo
            };
            Process.Start();
        }
    }
}