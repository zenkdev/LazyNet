using System;

namespace Dekart.LazyNet
{
    /// <summary> Edits container interface </summary>
    public interface IEditsContainer
    {
        /// <summary> Occur when edit value changed </summary>
        event EventHandler EditValueChanged;
    }
    
    /// <summary> Grid edit bar interface </summary>
    public interface IGridEditBar
    {
        /// <summary>Set allow editing</summary>
        void SetAllowEditing(bool allow);

        /// <summary>Disable buttons</summary>
        void DisableButtons();
    }

    /// <summary> Data pane module interface </summary>
    public interface IDataPaneModule
    {
        /// <summary> Splitter position </summary>
        int SplitterPosition { get; set; }
        /// <summary> Data pane state </summary>
        DataPaneStateEnum DataPaneState { get; set; }
        /// <summary> Data pane enabled </summary>
        bool DataPaneEnabled { get; }
        /// <summary> Data pane changed event </summary>
        event EventHandler DataPaneChanged;
    }

}
