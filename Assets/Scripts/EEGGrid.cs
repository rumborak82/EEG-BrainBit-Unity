using UnityEngine;

public class EEGGrid : MonoBehaviour
{
    public int width = 30;
    public int height = 15;
    public float spacing = 0.3f;

    void Start()
    {
        for (int x = -width; x <= width; x++)
        {
            CreateLine(new Vector3(x * spacing, -height * spacing, 0),
                       new Vector3(x * spacing, height * spacing, 0));
        }

        for (int y = -height; y <= height; y++)
        {
            CreateLine(new Vector3(-width * spacing, y * spacing, 0),
                       new Vector3(width * spacing, y * spacing, 0));
        }
    }

    void CreateLine(Vector3 start, Vector3 end)
    {
        GameObject line = new GameObject("GridLine");
        line.transform.parent = transform;

        LineRenderer lr = line.AddComponent<LineRenderer>();
        lr.positionCount = 2;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);

        lr.startWidth = 0.01f;
        lr.endWidth = 0.01f;

        lr.material = new Material(Shader.Find("Sprites/Default"));
        lr.startColor = new Color(0, 1, 0, 0.15f);
        lr.endColor = new Color(0, 1, 0, 0.15f);
    }
}