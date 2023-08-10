
namespace Core
{
    internal class Game
    {
        private Bike _bike;
        private Location _location;

        public Game()
        {
            
        }

        public void Initialize()
        {
            _bike = new Bike();
            _location = new Location();
        }

        public void Update()
        {
            _bike.Update();
            _location.Update();
        }
    }
}
