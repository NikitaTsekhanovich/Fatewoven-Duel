using UnityEngine;

public class SaverGlobalControllers : MonoBehaviour
{
    private void Awake()
    {
        var objs = GameObject.FindGameObjectsWithTag("GlobalControllers");

        if (objs.Length > 1)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
}