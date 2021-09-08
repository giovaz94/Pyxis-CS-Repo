using OOP_Rubboli.util;

namespace OOP_Rubboli
{
    public abstract class AbstractElement : IElement
    {
        private static double _UPDATE_TIME_MULTIPLIER = 0.001;
        private Dimension _dimension;
        private ICoord _position;
        
        public AbstractElement(Dimension inputDimension, ICoord inputPosition) {
            this._dimension = inputDimension;
            this.Position = inputPosition;
        }
        
        public Dimension Dimension
        {
            get { return this._dimension.CopyOf(); }
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

        public ICoord Position
        {
            get { return this._position.CopyOf(); }
            set { this._position = value; }
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