using UnityEngine;

[RequireComponent(typeof(InputReader), typeof(BaseAttackSkill), typeof(VampirismSkill))]
public class PlayerCombat : MonoBehaviour
{
    private InputReader _inputReader;
    private BaseAttackSkill _baseAttackSkill;
    private VampirismSkill _vampirismSkill;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _baseAttackSkill = GetComponent<BaseAttackSkill>();
        _vampirismSkill = GetComponent<VampirismSkill>();
    }

    private void OnEnable()
    {
        _inputReader.AttackPressed += UseBaseAttack;
        _inputReader.VampireSkillPressed += UseVampirismSkill;
    }

    private void OnDisable()
    {
        _inputReader.AttackPressed -= UseBaseAttack;
        _inputReader.VampireSkillPressed -= UseVampirismSkill;
    }

    private void UseBaseAttack()
    {
        _baseAttackSkill.Use();
    }

    private void UseVampirismSkill()
    {
        _vampirismSkill.Use();
    }
}
