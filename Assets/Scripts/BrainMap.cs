using UnityEngine;

public class BrainMap : MonoBehaviour
{
    public Transform O1;
    public Transform O2;
    public Transform T3;
    public Transform T4;

    void Update()
    {
        UpdateColor(O1, EEGManager.Instance.O1);
        UpdateColor(O2, EEGManager.Instance.O2);
        UpdateColor(T3, EEGManager.Instance.F1);
        UpdateColor(T4, EEGManager.Instance.F2);
    }

    void UpdateColor(Transform t, float value)
    {
        Renderer r = t.GetComponent<Renderer>();

        float v = Mathf.InverseLerp(-1f, 1f, value);
        Color c = Color.Lerp(Color.blue, Color.red, v);

        r.material.color = c;
    }
}