﻿using System;
using System.Windows;
using System.Windows.Interactivity;
using ChessInfrastructure.Interfaces;

namespace ChessGame.Behavior
{
    public class FrameworkElementDropBehavior : Behavior<FrameworkElement>
    {
        private Type dataType; //the type of the data that can be dropped into this control
        private FrameworkElementAdorner adorner;

        /// <summary>
        /// Initial method to attach the events for the Framework Element
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.AllowDrop = true;
            AssociatedObject.DragEnter += new DragEventHandler(AssociatedObject_DragEnter);
            AssociatedObject.PreviewDragOver += new DragEventHandler(AssociatedObject_PreviewDragOver);
            AssociatedObject.DragLeave += new DragEventHandler(AssociatedObject_DragLeave);
            AssociatedObject.Drop += new DragEventHandler(AssociatedObject_Drop);
        }

        /// <summary>
        /// Drop event to call the respective classes to handle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void AssociatedObject_Drop(object sender, DragEventArgs e)
        {
            if (dataType != null)
            {
                //if the data type can be dropped 
                if (e.Data.GetDataPresent(dataType))
                {
                    //drop the data
                    IDropable target = AssociatedObject.DataContext as IDropable;
                    if (target.CanDrop)
                    {
                        target.Drop(e.Data.GetData(dataType));

                        //remove the data from the source
                        IDragable source = e.Data.GetData(dataType) as IDragable;
                        source.Remove(e.Data.GetData(dataType));
                    }
                }
            }
            if (adorner != null)
                adorner.Remove();

            e.Handled = true;
            return;
        }

        /// <summary>
        /// Removes the animation when cursor leaves the Dropable area
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void AssociatedObject_DragLeave(object sender, DragEventArgs e)
        {
            if (adorner != null)
                adorner.Remove();
            e.Handled = true;
        }

        /// <summary>
        /// Updates the ardoner after Drag
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void AssociatedObject_PreviewDragOver(object sender, DragEventArgs e)
        {
            IDropable dropObject = this.AssociatedObject.DataContext as IDropable;
            if (dropObject != null)
            {
                if (dropObject.CanDrop)
                {
                    if (dataType != null)
                    {
                        //if item can be dropped
                        if (e.Data.GetDataPresent(dataType))
                        {
                            //give mouse effect
                            SetDragDropEffects(e);
                            //draw the dots
                            if (adorner != null)
                                adorner.Update();
                        }
                    }
                }
            }
            e.Handled = true;
        }

        /// <summary>
        /// Initilizes the adorner when the curser enters the dropable object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void AssociatedObject_DragEnter(object sender, DragEventArgs e)
        {
            //if the DataContext implements IDropable, record the data type that can be dropped
            if (dataType == null)
            {
                if (AssociatedObject.DataContext != null)
                {
                    IDropable dropObject = this.AssociatedObject.DataContext as IDropable;
                    if (dropObject != null)
                    {
                        if (dropObject.CanDrop)
                        {
                            dataType = dropObject.DataType;
                        }
                    }
                }
            }

            if (adorner == null)
                adorner = new FrameworkElementAdorner(sender as UIElement);
            e.Handled = true;
        }

        /// <summary>
        /// Provides feedback on if the data can be dropped
        /// </summary>
        /// <param name="e"></param>
        private void SetDragDropEffects(DragEventArgs e)
        {
            e.Effects = DragDropEffects.None;  //default to None

            //if the data type can be dropped 
            if (e.Data.GetDataPresent(dataType))
            {
                e.Effects = DragDropEffects.Move;
            }
        }

    }
}
