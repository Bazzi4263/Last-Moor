using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.Rendering.PostProcessing;

public class QuailitySettingManager : MonoBehaviour
{
    // 성능별로 만들어진 PipelineAsset List
    [SerializeField]
    List<RenderPipelineAsset> RenderPipelineAssets;

    public void SetPipeline(int value)
    {
        QualitySettings.SetQualityLevel(2 - value);
        QualitySettings.renderPipeline = RenderPipelineAssets[value];
        if (value == 2)
        {
            var volumes = FindObjectsOfType<Volume>();
            if (volumes != null)
            {
                foreach (var volume in volumes)
                {
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
        else
        {
            var volumes = FindObjectsOfType<Volume>();
            if (volumes != null)
            {
                foreach (var volume in volumes)
                {
                    if (volume.profile.TryGet<UnityEngine.Rendering.HighDefinition.Bloom>(out var component))
                        component.active = true;

                    if (volume.profile.TryGet<UnityEngine.Rendering.HighDefinition.AmbientOcclusion>(out var component2))
                        component2.active = true;

                    if (volume.profile.TryGet<UnityEngine.Rendering.HighDefinition.MotionBlur>(out var component3))
                        component3.active = true;

                    if (volume.profile.TryGet<ShadowsMidtonesHighlights>(out var component4))
                        component4.active = true;
                }
            }
        }
    }
}
