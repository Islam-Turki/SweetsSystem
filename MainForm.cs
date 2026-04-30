using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using sweetSystem.UserControls;

namespace sweetSystem
{
    public partial class MainForm : Form
    {
        private readonly List<NavButton> _navBtns = new();
        private UserControl? _current;

        // Optionally cache instances if you want to preserve their state between navigation,
        // or just recreate them on every click (recreating is typical unless state must persist).
        private Dictionary<int, UserControl> _controlCache = new();

        public MainForm()
        {
            InitializeComponent();

            // Set dynamic properties that might not stick in the designer
            this.BackColor = Theme.Background;
            this.Font = Theme.FontBody;
            _sidebar.BackColor = Theme.Sidebar;
            _contentArea.BackColor = Theme.Background;
            
            navLabel.Font = Theme.FontBadge;
            appSub.Font = Theme.FontSmall;
            footerLabel.Font = Theme.FontSmall;

            // Ensure sidebar docks first (takes its width) and content area fills the rest
            _sidebar.SendToBack();
            _contentArea.BringToFront();

            // Setup nav buttons list for easy management
            _navBtns.AddRange(new[] { 
                btnDashboard, btnOrderEntry, btnDelegation, btnOrderMgmt, 
                btnProdView, btnProdMgmt, btnHR, btnWholesale 
            });

            // Start on Dashboard
            Navigate(0);          
        }

        private void btnDashboard_Click(object sender, EventArgs e) => Navigate(0);
        private void btnOrderEntry_Click(object sender, EventArgs e) => Navigate(1);
        private void btnDelegation_Click(object sender, EventArgs e) => Navigate(2);
        private void btnOrderMgmt_Click(object sender, EventArgs e) => Navigate(3);
        private void btnProdView_Click(object sender, EventArgs e) => Navigate(4);
        private void btnProdMgmt_Click(object sender, EventArgs e) => Navigate(5);
        private void btnHR_Click(object sender, EventArgs e) => Navigate(6);
        private void btnWholesale_Click(object sender, EventArgs e) => Navigate(7);

        // ── Navigation (panel-swap — no TabControl) ────────────────────────────
        private void Navigate(int idx)
        {
            if (!_controlCache.TryGetValue(idx, out UserControl target))
            {
                target = idx switch
                {
                    0 => new DashboardControl(),
                    1 => new OrderEntryControl(),
                    2 => new DelegationHubControl(),
                    3 => new OrderManagementControl(),
                    4 => new ProductionViewControl(),
                    5 => new ProductManagementControl(),
                    6 => new EmployeeHRControl(),
                    7 => new WholesaleClientsControl(),
                    _ => new DashboardControl()
                };
                
                target.Dock = DockStyle.Fill;
                _controlCache[idx] = target;
            }

            // Refresh live data when navigating to specific screens
            // Note: Since you're converting these to UserControls, you will add
            // similar public Refresh/Load methods to your new UserControls.
            if (target is DashboardControl d) d.RefreshData();
            if (target is DelegationHubControl dh) dh.LoadData();
            if (target is ProductionViewControl pv) pv.RefreshGrid();
            if (target is OrderManagementControl om) om.LoadGrid();

            // Swap panels
            if (_current != target)
            {
                if (_current != null)
                {
                    _contentArea.Controls.Remove(_current);
                }
                
                _contentArea.Controls.Add(target);
                target.BringToFront();
                _current = target;
            }

            // Update nav-button states
            for (int i = 0; i < _navBtns.Count; i++)
                _navBtns[i].Active = (i == idx);
        }
    }
}
