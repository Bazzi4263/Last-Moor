using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class PostProcessSettings : MonoBehaviour
{
    void Start()
    {
        if (QualitySettings.GetQualityLevel() == 0)
        {
            var volume = GetComponent<Volume>();

            if (volume.profile.TryGet<UnityEngine.Rendering.HighDefinition.Bloom>(out var component))
                component.active = false;

            if (volume.profile.TryGet<UnityEngine.Rendering.HighDefinition.AmbientOcclusion>(out var component2))
                component2.active = false;

            if (volume.profile.TryGet<UnityEngine.Rendering.HighDefinition.MotionBlur>(out var component3))
                component3.active = false;

            if (volume.profile.TryGet<ShadowsMidtonesHighlights>(out var component4))
                component4.active = false;
        }
    }
}
