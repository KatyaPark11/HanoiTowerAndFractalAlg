using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class TowerGenerator : MonoBehaviour
    {
        public GameObject ringPrefab;
        public Image[] Robs = new Image[3];

        private void Start()
        {
            RectTransform rectTransform = ringPrefab.GetComponent<RectTransform>();
            VarsHolder.RingHeight = rectTransform.rect.height;
            VarsHolder.CurrentStep = 0;
            VarsHolder.Towers = new List<Tower>
        {
            GenerateTower(),
            new Tower(Robs[1].rectTransform.anchoredPosition.x),
            new Tower(Robs[2].rectTransform.anchoredPosition.x)
        };
        }

        public Tower GenerateTower()
        {
            Tower firstTower = new(Robs[0].rectTransform.anchoredPosition.x);
            for (int i = 0; i < VarsHolder.RingsNum; i++)
            {
                float width = CalculateRingWidth(i);

                GameObject ring = Instantiate(ringPrefab, transform);
                ring.transform.localScale = new Vector3(width, 1f, width);
                ring.transform.localPosition = new Vector3(firstTower.CoorX, Tower.FirstCoorY + i * VarsHolder.RingHeight, firstTower.CoorX);
                firstTower.Rings.Add(ring);
            }
            return firstTower;
        }

        float CalculateRingWidth(int index)
        {
            float maxWidth = 1.0f;
            float minWidth = 1.0f / 4f;

            float t = (float)index / (VarsHolder.RingsNum - 1);
            float width = Mathf.Lerp(maxWidth, minWidth, t);

            return width;
        }
    }
}