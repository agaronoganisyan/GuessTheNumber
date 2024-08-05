using UniRx;

namespace GuessGameplayLogic.InputFieldLogic
{
    public class InputFieldModel
    {
        public ReactiveProperty<string> Input { get; }

        public InputFieldModel()
        {
            Input = new ReactiveProperty<string>();
        }
        
        public void Remove()
        {
            Input.Value = string.Empty;
        }

        public void AddNumber(int number)
        {
            Input.Value += number;
        }
    }
}