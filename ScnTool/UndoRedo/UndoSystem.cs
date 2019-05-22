using System;
using System.Collections.Generic;
using System.Linq;

namespace NetsphereScnTool.UndoRedo
{
    public class UndoSystem<T> where T : new()
    {
        private readonly uint _maxObjects = 0;
        private bool _firstStart = true;

        private T current_object;

        private Stack<T> undo_object { get; set; }
        private Stack<T> redo_object { get; set; }

        public T Current_Object
        {
            get => current_object;
            internal set => current_object = value;
        }

        #region Delegate
        internal delegate void ObjectSavedEventHandler(object sender, EventArgs e);
        #endregion

        #region Handlers
        internal event ObjectSavedEventHandler ObjectSaved;
        #endregion

        #region Manage Events
        protected virtual void OnObjectSaved(EventArgs e) => ObjectSaved.Invoke(this, e);
        #endregion

        public UndoSystem()
        {
            _maxObjects = 50;

            undo_object = new Stack<T>((int)_maxObjects);
            redo_object = new Stack<T>((int)_maxObjects);
        }

        public UndoSystem(uint maxObjects)
          : this()
        {
            _maxObjects = maxObjects;
        }

        public void Undo()
        {
            if (undo_object.Count() <= 0)
                return;

            var @object = undo_object.Pop();

            if (@object == null)
                return;

            redo_object.Push(current_object);
            current_object = @object;
        }

        public void Redo()
        {
            if (redo_object.Count() > 0)
            {
                var @object = redo_object.Pop();

                if (@object == null)
                    return;

                undo_object.Push(current_object);
                current_object = @object;
            }
        }

        public void ClearSystem()
        {
            undo_object.Clear();
            redo_object.Clear();

            current_object = new T();
            _firstStart = true;
        }

        public virtual void Save(T @object)
        {
            if (undo_object.Count() >= _maxObjects)
            {
                var tempStack = undo_object.Reverse();
                tempStack.Pop();
                undo_object = tempStack.Reverse();
            }

            if (_firstStart)
            {
                current_object = @object;
                _firstStart = false;
            }

            if (!current_object.Equals(@object))
                undo_object.Push(current_object);

            current_object = @object;
            redo_object.Clear();

            OnObjectSaved(new EventArgs());
        }

        public bool CanUndo() => undo_object.Count() > 0;
        public bool CanRedo() => redo_object.Count() > 0;
    }
}
