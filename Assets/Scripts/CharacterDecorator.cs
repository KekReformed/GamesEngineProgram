public abstract class CharacterDecorator : Character
{
    protected Character character;

    public CharacterDecorator(Character character)
    {
        this.character = character;
    }

    public override void Attack()
    {
        character.Attack();
    }

    public override void Jump()
    {
        character.Jump();
    }
}