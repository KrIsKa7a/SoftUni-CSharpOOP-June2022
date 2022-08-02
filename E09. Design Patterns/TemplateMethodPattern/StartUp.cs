namespace TemplateMethodPattern
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Loop()
            TwelveGrain twelveGrain = new TwelveGrain();
            twelveGrain.Make();

            SourDough sourDough = new SourDough();
            sourDough.Make();

            WholeWheat wholeWheat = new WholeWheat();
            wholeWheat.Make();
        }
    }
}