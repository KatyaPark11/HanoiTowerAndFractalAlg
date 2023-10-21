using System.Diagnostics;
using UnityEngine;

namespace Assets.Scripts
{
    public class Fractal : MonoBehaviour
    {
        public static Process Process;

        public static void DrawTheFractalTree()
        {
            string applicationPath = "..\\..\\FractalGosperCurve\\FractalGosperCurve\\bin\\Debug\\FractalGosperCurve.exe";

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