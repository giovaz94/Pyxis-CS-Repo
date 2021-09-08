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
        
        private Dimension Dimension
        {
            get { return this._dimension.CopyOf(); }
        }

        private double Height
        {
            set { this._dimension.SetHeight(value); }
        }

        public Dimension GetDimension()
        {
            return this.Dimension;
        }

        public void SetHeight(double inputHeight)
        {
            this.Height = inputHeight;
        }

        public void IncreaseHeight(double increaseValue)
        {
            this._dimension.IncreaseHeight(increaseValue);
        }

        public void IncreaseWidth(double increaseValue)
        {
            this._dimension.IncreaseWidth(increaseValue);
        }

        public abstract IVector GetPace();

        public abstract void SetPace(IVector inputPace);
        public ICoord GetPosition()
        {
            return this.Position;
        }

        public void SetPosition(ICoord inputPosition)
        {
            this.Position = inputPosition;
        }

        private ICoord Position
        {
            get { return this._position.CopyOf(); }
            set { this._position = value; }
        }
        
        public void Update(double dt)
        {
            throw new System.NotImplementedException();
        }

        public int GetUpdateTimeMultiplier()
        {
            return UpdateTimeMultiplier;
        }

        public void SetWidth(double inputWidth)
        {
            this.Width = inputWidth;
        }

        private int UpdateTimeMultiplier
        {
            get { return this.UpdateTimeMultiplier; }
        }

        private double Width
        {
            set { this._dimension.SetWidth(value); }
        }
    }
}