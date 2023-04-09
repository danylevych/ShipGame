using UnityEngine;


// +=========================================+
// |                                         |
// | This script set the current gunsight in |
// |            Optione scene.               |
// |                                         |
// +=========================================+

public class SelectGunsight : MonoBehaviour
{
    [SerializeField] private GameObject[] images;

    private void Update()
    {
        int userGunsight = PlayerPrefs.GetInt("TypeGunsight", 0);

        for(int i = 0; i < images.Length; i++)
        {
            if (i == userGunsight)
            {
                images[i].SetActive(true);
                continue;
            }
            images[i].SetActive(false);
        }
    }
}