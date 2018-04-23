using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraNavBar;
using DevExpress.XtraNavBar.ViewInfo;
using System.Reflection;

namespace WindowsApplication1
{
    public class NavBarGroupStateHelper : Component
    {
        private bool isLocked;

        private int _CheckIndent;
        public int CheckIndent
        {
            get { return _CheckIndent; }
            set { _CheckIndent = value; }
        }

        private RepositoryItemCheckEdit _GroupEdit;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RepositoryItemCheckEdit GroupEdit
        {
            get { return _GroupEdit; }
            set { _GroupEdit = value; }
        }

        private NavBarControl _NavBarControl;
                                     
        public NavBarControl NavBarControl
        {
            get { return _NavBarControl; }
            set { UnsubscribeEvents(value); _NavBarControl = value; SubscribeEvents(value); }
        }

        public NavBarGroupStateHelper()
        {
            GroupEdit = new RepositoryItemCheckEdit();
        }
             

        bool IsCustomDrawNeeded()
        {
            return GroupEdit != null && NavBarControl != null && !isLocked;
        }


        private void SubscribeEvents(NavBarControl navBarControl)
        {
            if (navBarControl != null)
            {
                NavBarControl.CustomDrawGroupCaption += NavBarControl_CustomDrawGroupCaption;
                NavBarControl.MouseClick += NavBarControl_MouseClick;
            }
        }

     
        private void UnsubscribeEvents(NavBarControl navBarControl)
        {
            if (navBarControl == null)
            {
                NavBarControl.CustomDrawGroupCaption -= NavBarControl_CustomDrawGroupCaption;
                NavBarControl.MouseClick -= NavBarControl_MouseClick;
            }
        }

        int GetCheckBoxWidth()
        {
            return CheckIndent * 2 + 10;
        }

        Rectangle GetCaptionBounds(Rectangle originalCaptionBounds)
        {
            return new Rectangle(originalCaptionBounds.Location, new Size(originalCaptionBounds.Width - GetCheckBoxWidth(), originalCaptionBounds.Height));
        }

        Rectangle GetCheckBoxBounds(Rectangle fixedCaptionBounds)
        {
            return new Rectangle(fixedCaptionBounds.Right, fixedCaptionBounds.Top, GetCheckBoxWidth(), fixedCaptionBounds.Height); ;
        }

        void NavBarControl_CustomDrawGroupCaption(object sender, DevExpress.XtraNavBar.ViewInfo.CustomDrawNavBarElementEventArgs e)
        {
            if (!IsCustomDrawNeeded()) return;
            try
            {
                isLocked = true;
                BaseNavGroupPainter painter = NavBarControl.View.CreateGroupPainter(NavBarControl);
                NavGroupInfoArgs info = e.ObjectInfo as NavGroupInfoArgs; 
               
                Rectangle originalCaptionBounds = new Rectangle(info.CaptionClientBounds.X,info.CaptionClientBounds.Y,info.CaptionClientBounds.Width-info.ButtonBounds.Width,info.CaptionClientBounds.Height);
                Rectangle fixedCaptionBounds = GetCaptionBounds(originalCaptionBounds);
                Rectangle checkBoxBounds = GetCheckBoxBounds(fixedCaptionBounds);
                info.CaptionBounds = fixedCaptionBounds;
                painter.DrawObject(info);
                info.CaptionBounds = originalCaptionBounds;
                DrawCheckBox(e.Graphics, checkBoxBounds, IsGroupEnabled(info.Group));
                e.Handled = true;
            }
            finally
            {
                isLocked = false;
            }
        }
        protected void DrawCheckBox(Graphics g, Rectangle r, bool Checked)
        {
            BaseEditPainter painter = GroupEdit.CreatePainter();
            BaseEditViewInfo info = GroupEdit.CreateViewInfo();
            info.EditValue = Checked;
            info.Bounds = r;
            info.CalcViewInfo(g);
            ControlGraphicsInfoArgs args = new ControlGraphicsInfoArgs(info, new DevExpress.Utils.Drawing.GraphicsCache(g), r);
            painter.Draw(args);
            args.Cache.Dispose();
        }
        private Rectangle hotRectangle;
        private NavBarGroup hotGroup;

        static NavBarViewInfo GetNavBarView(NavBarControl NavBar)
        {
            PropertyInfo pi = typeof(NavBarControl).GetProperty("ViewInfo", BindingFlags.Instance | BindingFlags.NonPublic);
            return pi.GetValue(NavBar, null) as NavBarViewInfo;
        }

        bool IsCheckBox(Point p)
        {
            NavBarHitInfo hi = NavBarControl.CalcHitInfo(p);
            if (hi.Group == null) return false; ;
            NavBarViewInfo vi = GetNavBarView(NavBarControl);
            vi.Calc(NavBarControl.ClientRectangle);
            NavGroupInfoArgs groupInfo = vi.GetGroupInfo(hi.Group);
            Rectangle originalCaptionBounds = new Rectangle(groupInfo.CaptionClientBounds.X, groupInfo.CaptionClientBounds.Y, groupInfo.CaptionClientBounds.Width - groupInfo.ButtonBounds.Width, groupInfo.CaptionClientBounds.Height);
            Rectangle checkBounds = GetCheckBoxBounds(GetCaptionBounds(originalCaptionBounds));
            hotGroup = hi.Group;
            hotRectangle = checkBounds;
            return checkBounds.Contains(p);
        }

        void NavBarControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (IsCheckBox(e.Location)) ToggleGroupState(hotGroup);
        }

        static bool IsGroupEnabled(NavBarGroup group)
        {
            return group.Tag == null;
        }

        void ToggleGroupState(NavBarGroup group)
        {
            SetGroupState(group, !IsGroupEnabled(group));
        }

        void SetGroupState(NavBarGroup group, bool enabled)
        {
            foreach (NavBarItemLink link in group.ItemLinks)
            {
                link.Item.Enabled = enabled;
            }
            if (enabled) group.Tag = null;
            else group.Tag = 0;
            NavBarControl.Invalidate(hotRectangle);
        }
    }
}
