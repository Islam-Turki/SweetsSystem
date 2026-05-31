using sweetSystem;
using System.Drawing;

namespace sweetSystem
{
    /// <summary>Central design token registry — single source of truth for colors, fonts, and sizes.</summary>
    public static class Theme
    {
        // ── Palette ───────────────────────────────────────────────────────────
        /// <summary>Use for main form backgrounds</summary>
        public static readonly Color Background = Color.FromArgb(253, 248, 245); // Soft Vanilla

        /// <summary>Use for panels and data grids</summary>
        public static readonly Color Surface = Color.FromArgb(255, 255, 255); // Pure white

        /// <summary>Use for borders between panels</summary>
        public static readonly Color SurfaceBorder = Color.FromArgb(240, 235, 230);

        /// <summary>Use for sidebar and dark elements</summary>
        public static readonly Color Sidebar = Color.FromArgb(60, 45, 35); // Dark Chocolate
        public static readonly Color SidebarHover = Color.FromArgb(80, 60, 45);
        public static readonly Color SidebarActive = Color.FromArgb(210, 150, 75); // Caramel

        /// <summary>Use for primary buttons, highlights, and DataGridView selection rows</summary>
        public static readonly Color AccentGold = Color.FromArgb(210, 150, 75); // Caramel

        /// <summary>Use for success (like validation checkmarks)</summary>
        public static readonly Color AccentGreen = Color.FromArgb(147, 197, 114); // Pistachio Green

        /// <summary>Use for errors or delete actions</summary>
        public static readonly Color AccentRed = Color.FromArgb(220, 80, 90); // Strawberry Red

        /// <summary>Secondary accent or informative blue</summary>
        public static readonly Color AccentBlue = Color.FromArgb(70, 140, 180);

        /// <summary>Use for primary text</summary>
        public static readonly Color TextPrimary = Color.FromArgb(60, 45, 35); // Dark Chocolate

        /// <summary>Use for secondary text and placeholders</summary>
        public static readonly Color TextSecondary = Color.FromArgb(120, 95, 80); // Milk Chocolate

        /// <summary>Use for text on dark backgrounds</summary>
        public static readonly Color TextOnDark = Color.FromArgb(253, 248, 245); // Vanilla

        /// <summary>Use for text on accent buttons</summary>
        public static readonly Color TextOnAccent = Color.White;
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
        /// <summary>Format a double as Libyan Dinar: "1,234.56 د.ل"</summary>
        public static string LYD(double amount) => $"{amount:N2} د.ل";
    }
}
