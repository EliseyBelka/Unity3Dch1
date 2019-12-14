using UnityEngine;

public class TestScript : MonoBehaviour
{
    [SerializeField] private int count = 1;
    [SerializeField] private int offset = 1;
    [SerializeField] private GameObject obj;
    [SerializeField] private Axis axis;

    enum Axis
    {
        x,y,z
    }
   
    void Start()
    {
        CreateObj();
    }

    public void CreateObj()
    {
        int x = 0;
        int y = 0;
        int z = 0;
        if (axis == Axis.x)
        {
            x = offset;
        }
        else
         if (axis == Axis.y)
        {
            y = offset;
        }
        else
         if (axis == Axis.z)
        {
            z = offset;
        }
        for (int i = 0; i < count; i++)
        {
            Instantiate(obj,new Vector3(x*i,y*i,z*i),Quaternion.identity);
        }
    }
}
