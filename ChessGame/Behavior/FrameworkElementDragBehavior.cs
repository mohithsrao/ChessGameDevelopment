using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;
using ChessInfrastructure.Interfaces;

namespace ChessGame.Behavior
{
    public class FrameworkElementDragBehavior : Behavior<FrameworkElement>
    {
        private bool isMouseClicked = false;

        /// <summary>
        /// Initial method to attach events to the Framework Elements
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.PreviewMouseDown += new MouseButtonEventHandler(AssociatedObject_PreviewMouseDown);
            AssociatedObject.MouseUp += new MouseButtonEventHandler(AssociatedObject_MouseUp);
            AssociatedObject.MouseLeave += new MouseEventHandler(AssociatedObject_MouseLeave);
            AssociatedObject.GiveFeedback += new GiveFeedbackEventHandler(AssociatedObject_GiveFeedback);
        }

        /// <summary>
        /// Event to Handle Feedback to change the Mouse cursor based on the Effects
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void AssociatedObject_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            IDragable dragObject = AssociatedObject.DataContext as IDragable;
            if (dragObject != null)
            {
                if (!dragObject.CanDrag) return;
                e.UseDefaultCursors = true;
                switch (e.Effects)
                {
                    case DragDropEffects.None:
                        break;
                    case DragDropEffects.Copy:
                        break;
                    case DragDropEffects.Move:
                        break;
                    case DragDropEffects.Link:
                        break;
                    case DragDropEffects.Scroll:
                        break;
                    case DragDropEffects.All:
                        break;
                    default:
                        e.UseDefaultCursors = true;
                        break;
                }
                e.Handled = true;
            }
        }
        
        /// <summary>
        /// Mouse Down to set the Mouse Clicked Flag
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void AssociatedObject_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            isMouseClicked = true;
        }

        /// <summary>
        /// Mouse up button to unset the mouse clicked flag
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void AssociatedObject_MouseUp(object sender, MouseButtonEventArgs e)
        {
            isMouseClicked = false;
        }

        /// <summary>
        /// Do the Drag operation when the mouse leaves the Framework Element
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void AssociatedObject_MouseLeave(object sender, MouseEventArgs e)
        {
            if (isMouseClicked)
            {
                //set the item's DataContext as the data to be transferred
                IDragable dragObject = AssociatedObject.DataContext as IDragable;
                if (dragObject != null)
                {
                    if (!dragObject.CanDrag) return;
                    DataObject data = new DataObject();
                    data.SetData(dragObject.DataType, AssociatedObject.DataContext);
                    DragDrop.DoDragDrop(AssociatedObject, data, DragDropEffects.Move);
                }
            }
            isMouseClicked = false;
        }
    }
}
