using System.Drawing;

namespace sweetSystem
{
    /// <summary>Central design token registry — single source of truth for colors, fonts, and sizes.</summary>
    public static class Theme
    {
        // ── Palette ───────────────────────────────────────────────────────────
        public static readonly Color Sidebar       = Color.FromArgb(36,  52,  40);   // dark forest green
        public static readonly Color SidebarHover  = Color.FromArgb(55,  78,  60);
        public static readonly Color SidebarActive = Color.FromArgb(108, 163, 108);  // pistachio active

        public static readonly Color Background    = Color.FromArgb(247, 246, 242);  // milk white
        public static readonly Color Surface       = Color.FromArgb(255, 255, 255);
        public static readonly Color SurfaceBorder = Color.FromArgb(226, 222, 212);

        public static readonly Color AccentGreen   = Color.FromArgb(100, 158, 100);  // pistachio
        public static readonly Color AccentGold    = Color.FromArgb(190, 145,  75);  // caramel / wood
        public static readonly Color AccentRed     = Color.FromArgb(196,  68,  68);
        public static readonly Color AccentBlue    = Color.FromArgb(68,  125, 175);

        public static readonly Color TextPrimary   = Color.FromArgb(36,  36,  36);
        public static readonly Color TextSecondary = Color.FromArgb(108, 108,  98);
        public static readonly Color TextOnDark    = Color.FromArgb(224, 236, 224);
        public static readonly Color TextOnAccent  = Color.White;

        // ── Fonts ─────────────────────────────────────────────────────────────
        public static readonly Font FontH1      = new("Cairo", 16f, FontStyle.Bold);
        public static readonly Font FontH2      = new("Cairo", 11f, FontStyle.Bold);
        public static readonly Font FontBody    = new("Cairo",  9f);
        public static readonly Font FontBodyB   = new("Cairo",  9f, FontStyle.Bold);
        public static readonly Font FontSmall   = new("Cairo",  8f);
        public static readonly Font FontSidebar = new("Cairo", 10f);
        public static readonly Font FontBadge   = new("Cairo",  7f, FontStyle.Bold);
        public static readonly Font FontNav     = new("Cairo",  9f, FontStyle.Bold);

        // ── Sizes ─────────────────────────────────────────────────────────────
        public const int SidebarWidth  = 215;
        public const int HeaderHeight  = 84; // Increased from 64 for more space
        public const int CornerRadius  = 8;
        public const int ButtonHeight  = 36;
        public const int GridRowHeight = 44;
        public const int Padding       = 16;

        // ── Currency helper ───────────────────────────────────────────────────
        /// <summary>Format a decimal as Libyan Dinar: "1,234.56 د.ل"</summary>
        public static string LYD(decimal amount) => $"{amount:N2} د.ل";
    }
}
