using sweetSystem;
using System.Drawing;

namespace sweetSystem
{
    /// <summary>Central design token registry — single source of truth for colors, fonts, and sizes.</summary>
    public static class Theme
    {
        // ── Palette ───────────────────────────────────────────────────────────

        /// <summary>Use for the sidebar background. Dark Chocolate color to frame the application.</summary>
        public static readonly Color Sidebar = Color.FromArgb(51, 34, 24);

        /// <summary>Use for sidebar hover states.</summary>
        public static readonly Color SidebarHover = Color.FromArgb(77, 51, 36);

        /// <summary>Use for sidebar active items (Caramel).</summary>
        public static readonly Color SidebarActive = Color.FromArgb(212, 143, 53);

        /// <summary>Use for main form backgrounds. A soft 'Vanilla' or warm off-white.</summary>
        public static readonly Color Background = Color.FromArgb(253, 248, 240);

        /// <summary>Use for panels and data grids to create clean contrast against the vanilla background.</summary>
        public static readonly Color Surface = Color.FromArgb(255, 255, 255);

        /// <summary>Use for subtle borders around surfaces, cards, and input fields.</summary>
        public static readonly Color SurfaceBorder = Color.FromArgb(235, 228, 220);

        /// <summary>Use for success status (validation checkmarks). Soft 'Pistachio Green'.</summary>
        public static readonly Color AccentGreen = Color.FromArgb(163, 192, 143);

        /// <summary>Use for primary buttons, highlights, and DataGridView selection rows. Vibrant 'Caramel'/'Gold'.</summary>
        public static readonly Color AccentGold = Color.FromArgb(212, 143, 53);

        /// <summary>Use for errors or delete actions. 'Strawberry Red'.</summary>
        public static readonly Color AccentRed = Color.FromArgb(226, 94, 101);

        /// <summary>Use for informational highlights. A complementary soft blue.</summary>
        public static readonly Color AccentBlue = Color.FromArgb(108, 154, 172);

        /// <summary>Use for primary text. A 'Dark Chocolate' (very dark warm-brown) instead of pure black.</summary>
        public static readonly Color TextPrimary = Color.FromArgb(51, 34, 24);

        /// <summary>Use for secondary text and placeholders. A 'Milk Chocolate' (medium warm-grey).</summary>
        public static readonly Color TextSecondary = Color.FromArgb(138, 107, 90);

        /// <summary>Use for text on dark backgrounds.</summary>
        public static readonly Color TextOnDark = Color.FromArgb(253, 248, 240);

        /// <summary>Use for text placed on accent colors.</summary>
        public static readonly Color TextOnAccent = Color.FromArgb(255, 255, 255);
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
