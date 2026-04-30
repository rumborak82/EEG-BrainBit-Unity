using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(LineRenderer))]
public class EEGLine : MonoBehaviour
{
    public enum Channel { O1, O2, T3, T4 }
    public Channel channel;

    private LineRenderer line;
    private List<float> values = new List<float>();

    private int maxPoints = 200;

    void Start()
    {
        line = GetComponent<LineRenderer>();

        // начални точки (празна линия)
        for (int i = 0; i < maxPoints; i++)
        {
            values.Add(0);
        }
    }

    void Update()
    {
        float v = GetValue();

        // премахваме най-старата стойност
        values.RemoveAt(0);

        // добавяме новата (като поток)
        values.Add(v);

        line.positionCount = values.Count;

        float offsetX = -10f;

        for (int i = 0; i < values.Count; i++)
        {
            float x = i * 0.08f;
            float channelOffset = 0;

            switch (channel)
            {
                case Channel.O1: channelOffset = 2f; break;
                case Channel.O2: channelOffset = 0f; break;
                case Channel.T3: channelOffset = -2f; break;
                case Channel.T4: channelOffset = -4f; break;
            }

            float y = values[i] * 1.2f + channelOffset;

            line.SetPosition(i, new Vector3(x + offsetX, y, 0));
        }
    }

    float GetValue()
    {
        switch (channel)
        {
            case Channel.O1: return EEGManager.Instance.O1;
            case Channel.O2: return EEGManager.Instance.O2;
            case Channel.T3: return EEGManager.Instance.F1;
            case Channel.T4: return EEGManager.Instance.F2;
        }
        return 0;
    }
}