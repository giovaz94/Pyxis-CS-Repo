using OOP_Rubboli.util;

namespace OOP_Rubboli
{
    public abstract class AbstractElement : IElement
    {
        private static double _UPDATE_TIME_MULTIPLIER = 0.001;
        private Dimension _dimension;
        private Coord _position;
        
        public AbstractElement(Dimension inputDimension, Coord inputPosition) {
            this._dimension = inputDimension;
            this._position = inputPosition;
        }
        
        public Dimension Dimension
        {
            get;
        }

        public double Height
        {
            set { this._dimension.Height = value; }
        }
        
        public void IncreaseHeight(double increaseValue)
        {
            this._dimension.IncreaseHeight(increaseValue);
        }

        public void IncreaseWidth(double increaseValue)
        {
            this._dimension.IncreaseWidth(increaseValue);
        }

        public Vector Pace { get; set; }

        public Coord Position
        {
            get;
            set;
        }
        
        public void Update(double dt)
        {
            throw new System.NotImplementedException();
        }

        public int UpdateTimeMultiplier
        {
            get;
        }

        public double Width
        {
            set { this._dimension.Width = value; }
        }
    }
}