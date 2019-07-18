using UnityEngine;

namespace LevelGenerator
{
    public class mbLevelGenerator : MonoBehaviour
    {
        public Texture2D mapInput;
        public GameObject groundPrefab;
        public ColorToPrefab[] colorMappings;


        void Start()
        {
            Debug.Log(string.Format("Das Level hat eine Dimension von x:{0} und y:{1}", mapInput.width, mapInput.height));
            GenerateLevel();
        }
        #region Methods
        // Loop that goes through the width and height of the mapInput and uses the GenerateTile method with the looped x and y values. 
        void GenerateLevel()
        {
            GenerateGround(mapInput.width, mapInput.height, groundPrefab);

            for (int x = 0; x  < mapInput.width; x++)
            {
                for (int y = 0; y < mapInput.height; y++)
                {
                    GenerateTile(x, y);
                }
            }
        }


        void GenerateGround(int width, int height, GameObject ground)
        {
            GameObject groundplane = Instantiate(ground, Vector3.zero, Quaternion.identity, transform);
            groundplane.transform.localScale = new Vector3(width, 1, height);

        }

        // Gets the Color information of each pixel 
        void GenerateTile(int x, int y)
        {
            Color pixelColor = mapInput.GetPixel(x, y);

            if (pixelColor.a == 0) return;

            Debug.Log(pixelColor);

            foreach (ColorToPrefab colorMapping in colorMappings)
            {
                Debug.Log("For Each funktioniert");
                if (colorMapping.color.Equals(pixelColor))
                {
                    Debug.Log("Instantiate");
                    Vector3 position = new Vector3(x, 1, y);
                    Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
                }
            }
        }


        #endregion
    }
}
