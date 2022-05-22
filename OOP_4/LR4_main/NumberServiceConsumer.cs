namespace LR4_main
{
    internal class NumberServiceConsumer: INumberServiceConsumer
    {
        NumberService _numberService;
        public NumberServiceConsumer(NumberService numberService)
        {
            _numberService = numberService;
        }

        public void Print()
        {
            _numberService.Print();
        }
    }
}