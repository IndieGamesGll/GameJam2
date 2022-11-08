using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class ManController : MonoBehaviour
{
    int blendShapeCount;
    [SerializeField] SkinnedMeshRenderer skinnedMeshRenderer;
    [SerializeField] Slider _slider;
    [SerializeField] Animator _animator;
    Mesh skinnedMesh;

    void Awake() {
        skinnedMesh = skinnedMeshRenderer.GetComponent<SkinnedMeshRenderer>().sharedMesh;
    }

    void Start() {
        blendShapeCount = skinnedMesh.blendShapeCount;
        Debug.Log(blendShapeCount);
    }

    void Update() {
        if (_slider.value < 0f) {
            skinnedMeshRenderer.SetBlendShapeWeight(0, -1f * _slider.value * 100f);
        }
        else {
            skinnedMeshRenderer.SetBlendShapeWeight(1, _slider.value * 100f);
            _animator.SetFloat("fatValue", _slider.value);
        }
    }
}
