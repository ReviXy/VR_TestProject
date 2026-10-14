using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(XRGrabInteractable))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(MeshRenderer))]
public class TheRockCube : MonoBehaviour
{
    public AudioClip interactSound;
    public Material defaultMaterial;
    public Material interactMaterial;

    private XRGrabInteractable interactable;
    private AudioSource audioSource;
    private MeshRenderer meshRenderer;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        interactable = GetComponent<XRGrabInteractable>();
        meshRenderer = GetComponent<MeshRenderer>();

        meshRenderer.material = defaultMaterial;

        interactable.selectEntered.AddListener(OnGrab);
        interactable.selectExited.AddListener(OnRelease);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        audioSource.PlayOneShot(interactSound);
        meshRenderer.material = interactMaterial;
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        meshRenderer.material = defaultMaterial;
    }

}
