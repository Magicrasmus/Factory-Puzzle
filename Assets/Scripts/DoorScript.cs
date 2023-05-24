using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript: MonoBehaviour
{
    public bool unlock;
    public int levels;
    // Start is called before the first frame update
    void Start()
    {
        unlock = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (unlock && levels == 0)
        {
            Destroy(gameObject);
        }
    }

    public void AddLevel()
    {
        levels++;
    }

    public void RemoveLevel()
    {
        levels--;
        unlock = true;
    }
}
