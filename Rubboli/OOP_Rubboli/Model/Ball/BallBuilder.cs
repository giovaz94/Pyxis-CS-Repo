using System;
using OOP_Rubboli.util;

namespace OOP_Rubboli
{
    public class BallBuilder : IBallBuilder
    {
        private IVector _pace = null;
        private int? _id = null;
        private ICoord _position = null;
        private BallType _type = BallType.NormalBall;

        private void Check(object inputObject)
        {
            this.NonNull(inputObject);
        }

        private bool IsNull()
        {
            return this._pace == null || this._id == null || this._position == null;
        }

        private void NonNull(object inputObject)
        {
            if (inputObject == null)
            {
                throw new NullReferenceException();
            }
        }

        public IBallBuilder Pace(IVector inputPace)
        {
            this.Check(inputPace);
            this._pace = inputPace;
            return this;
        }

        public IBallBuilder Id(int inputId)
        {
            this.Check(inputId);
            this._id = inputId;
            return this;
        }

        public IBallBuilder InitialPosition(ICoord position)
        {
            this.Check(position);
            this._position = position;
            return this;
        }

        public IBallBuilder Type(BallType type)
        {
            this.Check(type);
            this._type = type;
            return this;
        }

        public Ball Build()
        {
            if (this.IsNull())
            {
                throw new NullReferenceException();
            }

            return new Ball(this._pace,
                this._position,
                this._type,
                this._id.Value);
        }
    }
}