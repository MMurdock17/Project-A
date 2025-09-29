using UnityEngine;
using UnityEngine.UI;

public class SelectionArrow : MonoBehaviour
{
    //Info for selection arrow (sound, position, options for positioning)
    private RectTransform rect;
    [SerializeField] private RectTransform[] options;
    [SerializeField] private AudioClip changeSound;
    [SerializeField] private AudioClip interactSound;
    private int currentPosition;

    private void Awake()
    {
        //Getting references
        rect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        //Option navigation
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            ChangePosition(-1);
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            ChangePosition(1);

            //Interaction of current selection
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.E))
            Interact();
    }

    //Trigger selection
    private void Interact()
    {
        SoundManager.instance.PlaySound(interactSound);

        options[currentPosition].GetComponent<Button>().onClick.Invoke();
    }

    //Move selection arrow between options
    private void ChangePosition(int _change)
    {
        currentPosition += _change;

        //Play change sound effect
        if (_change != 0)
            SoundManager.instance.PlaySound(changeSound);

        if (currentPosition < 0)
            currentPosition = options.Length - 1;
        else if (currentPosition > options.Length - 1)
            currentPosition = 0;

            //Update selection arrow position
        rect.position = new Vector3(rect.position.x, options[currentPosition].position.y, 0);
    }

}
