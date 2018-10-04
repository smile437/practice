namespace practice
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    class FigureOutTheFieldException : Exception
    {
        public FigureOutTheFieldException()
        {
        }

        public FigureOutTheFieldException(string message)

            : base(message)
        {
        }

        public FigureOutTheFieldException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected FigureOutTheFieldException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
