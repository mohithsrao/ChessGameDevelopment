using System;

namespace ChessInfrastructure.Interfaces
{
    public interface IDragable
    {
        /// <summary>
        /// Type of the data item
        /// </summary>
        Type DataType { get; }

        /// <summary>
        /// Bool to determine if the element can be draged
        /// </summary>
        bool CanDrag { get; }

        /// <summary>
        /// Remove the object from the collection
        /// </summary>
        void Remove(object i);
    }
}
