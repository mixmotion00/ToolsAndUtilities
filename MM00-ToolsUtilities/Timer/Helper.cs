using UnityEngine;
using UnityEngine.UI;

public class Helper
{
    /// <summary>
    /// Automatically force Unity to rebuild the layout as they might not getting updated properly
    /// </summary>
    /// <param name="main"></param>
    public static void ForceRebuildLayout(Transform main)
    {
        foreach (var layoutGroup in main.GetComponentsInChildren<LayoutGroup>())
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(layoutGroup.GetComponent<RectTransform>());
        }
        //LayoutRebuilder.ForceRebuildLayoutImmediate(mainPanel.GetComponent<RectTransform>());
        main.gameObject.SetActive(false);
        main.gameObject.SetActive(true);
    }

    /// <summary>
    /// Destroy all children of container object
    /// </summary>
    /// <param name="container"></param>
    public static void DestroyChildren(Transform container) 
    {
        foreach (Transform t in container)
        {
            GameObject.Destroy(t.gameObject);
        }
    }
}
