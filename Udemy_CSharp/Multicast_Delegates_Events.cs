#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Udemy_CSharp
{
    public class Multicast_Delegates_Events
    {
        public static void PseudoMain()
        {
            //Create engines
            GraphicEngine graphic = new GraphicEngine();
            SoundEngine sound = new SoundEngine();
            //Create Players
            Player playa1 = new Player("DaSilva1");
            Player playa2 = new Player("LeMinho2");


            //Game start from multicast:
            GameEventManager.TriggerGameStart();

            Console.WriteLine("\nGame started. Press any key to stop the game.\n");
            Console.ReadKey();

            //Game stop from multicast
            GameEventManager.TriggerGameOver();
        }
    }

    public class GameEventManager
    {
        public delegate void GameEvent();

        //Delegates and calling methods can be static as we don't have to create an instance of GameEventManaged class in order to call events!
        // EVENT keyword will make it impossible to call the event from outside of this class! Also it forces statement to behave as a list (we can only add or remove subscribers)
        public static event GameEvent OnGameStart, OnGameOver;

        //Static method to call OnGameStart
        public static void TriggerGameStart()
        {
            //If OnGameStart is not null (meaning if other methods already subscribed to it)
            if (OnGameStart is not null)
            {                
                Console.WriteLine("Game Start event triggered...");
                //Call the event - it will call all methods which was subscribed!
                OnGameStart();
            }
        }

        public static void TriggerGameOver()
        {
            if (OnGameOver is not null)
            {
                Console.WriteLine("Game Over event triggered...");
                OnGameOver();
            }
        }
    }

    #region Example Classes

    public class Player
    {
        public string Name { get; set; }

        //Subscribe OnGameStart and OnGameOver events in constructor
        //Once event appears methods will be called.
        public Player(string name)
        {
            Name = name;
            GameEventManager.OnGameStart += Start;
            GameEventManager.OnGameOver += Stop;
            // += operator ADDS method to multicast
            // = operator will OVERRIDE ALL OTHER METHODS! Potentialy hazardous situation - POSSIBLE ONLY FOR DELEGATES! Use events to avoid this.
        }

        //Subscribed method can (and should) be private - it will be called anyway.
        void Start() => Console.WriteLine("Spawning {0}...", Name);
        void Stop() => Console.WriteLine("Removing {0}...", Name);
    }

    public class GraphicEngine
    {
        public GraphicEngine()
        {
            GameEventManager.OnGameStart += Start;
            GameEventManager.OnGameOver += Stop;
        }

        void Start() => Console.WriteLine("Starting graphics...");
        void Stop() => Console.WriteLine("Stopping graphics...");
    }

    public class SoundEngine
    {
        public SoundEngine()
        {
            GameEventManager.OnGameStart += Start;
            GameEventManager.OnGameOver += Stop;
        }

        void Start() => Console.WriteLine("Starting audio...");
        void Stop() => Console.WriteLine("Stopping audio...");
    }

    #endregion
}
