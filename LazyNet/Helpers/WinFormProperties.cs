using DevExpress.Data.Filtering;
using DevExpress.LookAndFeel;
using DevExpress.Xpo;

namespace Dekart.LazyNet.Helpers
{
    public class WinFormProperties
    {
        readonly UnitOfWork _session;

        public WinFormProperties(UnitOfWork session)
        {
            _session = session;
        }

        public WinFormProperty CurrentProperty
        {
            get
            {
                var wfProperty = _session.FindObject<WinFormProperty>(CriteriaOperator.Parse("CreatedBy = ?", DataHelper.CurrentUserId));
                if (wfProperty == null)
                {
                    wfProperty = new WinFormProperty(_session);
                    Save();
                }
                return wfProperty;
            }
        }

        public bool ShowObjectCount
        {
            get { return CurrentProperty.ShowObjectCount; }
            set
            {
                if (CurrentProperty.ShowObjectCount == value) return;
                CurrentProperty.ShowObjectCount = value;
                Save();
            }
        }
        public int PreviewLineCount
        {
            get { return CurrentProperty.PreviewLineCount; }
            set
            {
                if (CurrentProperty.PreviewLineCount == value) return;
                CurrentProperty.PreviewLineCount = value;
                Save();
            }
        }

        public void Save()
        {
            SessionHelper.CommitSession(_session, new ExceptionProcesser(null));
        }

        public void LoadDefaultSkin()
        {
            if (CurrentProperty.DefaultSkinName == null) return;
            var lfName = CurrentProperty.DefaultSkinName.Split('@');
            if (lfName.Length < 2) return;
            switch (lfName[0])
            {
                case "WindowsXP":
                    UserLookAndFeel.Default.SetWindowsXPStyle();
                    break;
                case "Office2003":
                    UserLookAndFeel.Default.SetOffice2003Style();
                    break;
                case "Flat":
                    UserLookAndFeel.Default.SetFlatStyle();
                    break;
                case "Style3D":
                    UserLookAndFeel.Default.SetStyle3D();
                    break;
                case "UltraFlat":
                    UserLookAndFeel.Default.SetUltraFlatStyle();
                    break;
                default:
                    UserLookAndFeel.Default.SetSkinStyle(lfName[1]);
                    break;
            }
        }

        public void SaveDefaultProperties(FolderPaneVisibilityEnum visibility, int splitterPosition)
        {
            SaveDefaultSkin();
            CurrentProperty.FolderPaneVisibility = visibility;
            CurrentProperty.SplitterPosition = splitterPosition;
            Save();
        }

        void SaveDefaultSkin()
        {
            CurrentProperty.DefaultSkinName = string.Format("{0}@{1}", UserLookAndFeel.Default.ActiveStyle, UserLookAndFeel.Default.ActiveSkinName);
        }
    }
}