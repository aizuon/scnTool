using NetsphereScnTool.Scene;

namespace NetsphereScnTool.UndoRedo
{
    public class SceneUndoManager : UndoSystem<SceneContainer>
    {
        public SceneUndoManager(uint max)
          : base(max)
        { }

        public override void Save(SceneContainer @object)
        {
            var _container = (SceneContainer)@object.Clone();
            base.Save(_container);
        }

        public SceneContainer GetContainer() => Current_Object.Clone() as SceneContainer;
    }
}