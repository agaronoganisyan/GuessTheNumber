using Cysharp.Threading.Tasks;

namespace GuessGameplayLogic.GuessLogic.FactoryLogic
{
    public interface IGuessFactory
    {
        GuessView Get(GuessViewModel viewModel);
        UniTask Setup();
        void ReturnAllBack();
    }
}