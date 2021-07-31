using UnityEngine;

public class Skill : MonoBehaviour
{
    public string id;

    public Sprite layerOn;
    public Sprite layerPathOn;
    
    public GameObject previousSkill;
    public GameObject pathObject;

    public bool activated;
    public bool isFirst = false;

    private void OnMouseUpAsButton()
    {
        if (isFirst)
        {
            activated = true;
            GetComponent<SpriteRenderer>().sprite = layerOn;
        }
        else if (previousSkill.GetComponent<Skill>().activated && !activated)
        {
            activated = true;
            GetComponent<SkillList>().SkillProperty();
            GetComponent<SpriteRenderer>().sprite = layerOn;
            pathObject.GetComponent<SpriteRenderer>().sprite = layerPathOn;
        }
    }
}
