﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorFabric
{
    public class ThemeProvider
    {
        private ITheme _theme;

        public ICollection<FabricTheme> ThemeComponents { get; set; }

        public ITheme Theme { get => _theme; }

        public ThemeProvider()
        {
            ThemeComponents = new HashSet<FabricTheme>();
            _theme = CreateTheme();

        }

        public void UpdateTheme(IPalette palette)
        {
            _theme = CreateTheme(palette);
            foreach (var comp in ThemeComponents)
            {
                comp.UpdateTheme();
            }
        }

        private ITheme CreateTheme(IPalette palette = null)
        {
            var theme = new Theme();
            theme.Palette = palette ?? new DefaultPalette();
            theme.SemanticColors = MakeSemanticColorsFromPalette(theme.Palette, false);
            theme.SemanticTextColors = MakeSemanticTextColorsFromPalette(theme.Palette, false);
            theme.FontStyle = new FontStyle() { FontSize = new DefaultFontSize(), FontWeight = new DefaultFontWeight() };
            return theme;
        }

        private ISemanticColors MakeSemanticColorsFromPalette(IPalette palette, bool isInverted)
        {
            return new SemanticColors()
            {
                BodyBackground = palette.White,
                BodyBackgroundHovered = palette.NeutralLighter,
                BodyBackgroundChecked = palette.NeutralLight,
                BodyStandoutBackground = palette.NeutralLighterAlt,
                BodyFrameBackground = palette.White,
                BodyFrameDivider = palette.NeutralLight,
                BodyDivider = palette.NeutralLight,
                DisabledBorder = palette.NeutralTertiaryAlt,
                FocusBorder = palette.NeutralSecondary,
                VariantBorder = palette.NeutralLight,
                VariantBorderHovered = palette.NeutralTertiary,
                DefaultStateBackground = palette.NeutralLighterAlt,

                // BUTTONS
                ButtonBackground = palette.White,
                ButtonBackgroundChecked = palette.NeutralTertiaryAlt,
                ButtonBackgroundHovered = palette.NeutralLighter,
                ButtonBackgroundCheckedHovered = palette.NeutralLight,
                ButtonBackgroundPressed = palette.NeutralLight,
                ButtonBackgroundDisabled = palette.NeutralLighter,
                ButtonBorder = palette.NeutralSecondaryAlt,
                ButtonBorderDisabled = palette.NeutralLighter,

                PrimaryButtonBackground = palette.ThemePrimary,
                PrimaryButtonBackgroundHovered = palette.ThemeDarkAlt,
                PrimaryButtonBackgroundPressed = palette.ThemeDark,
                PrimaryButtonBackgroundDisabled = palette.NeutralLighter,
                PrimaryButtonBorder = "transparent",

                AccentButtonBackground = palette.Accent,

                // INPUTS
                InputBorder = palette.NeutralSecondary,
                InputBorderHovered = palette.NeutralPrimary,
                InputBackground = palette.White,
                InputBackgroundChecked = palette.ThemePrimary,
                InputBackgroundCheckedHovered = palette.ThemeDark,
                InputPlaceholderBackgroundChecked = palette.ThemeLighter,
                InputForegroundChecked = palette.White,
                InputIcon = palette.ThemePrimary,
                InputIconHovered = palette.ThemeDark,
                InputIconDisabled = palette.NeutralTertiary,
                InputFocusBorderAlt = palette.ThemePrimary,
                SmallInputBorder = palette.NeutralSecondary,
                DisabledBackground = palette.NeutralLighter,

                // LISTS
                ListBackground = palette.White,
                ListItemBackgroundHovered = palette.NeutralLighter,
                ListItemBackgroundChecked = palette.NeutralLight,
                ListItemBackgroundCheckedHovered = palette.NeutralQuaternaryAlt,

                ListHeaderBackgroundHovered = palette.NeutralLighter,
                ListHeaderBackgroundPressed = palette.NeutralLight,

                // MENUS
                MenuBackground = palette.White,
                MenuDivider = palette.NeutralTertiaryAlt,
                MenuIcon = palette.ThemePrimary,
                MenuHeader = palette.ThemePrimary,
                MenuItemBackgroundHovered = palette.NeutralLighter,
                MenuItemBackgroundPressed = palette.NeutralLight,

                ErrorBackground = !isInverted ? "rgba(245, 135, 145, .2)" : "rgba(232, 17, 35, .5)",
                BlockingBackground = !isInverted ? "rgba(250, 65, 0, .2)" : "rgba(234, 67, 0, .5)",
                WarningBackground = !isInverted ? "rgba(255, 200, 10, .2)" : "rgba(255, 251, 0, .6)",
                WarningHighlight = !isInverted ? "#ffb900" : "#fff100",
                SuccessBackground = !isInverted ? "rgba(95, 210, 85, .2)" : "rgba(186, 216, 10, .4)",
            };
        }

        private ISemanticTextColors MakeSemanticTextColorsFromPalette(IPalette palette, bool isInverted)
        {
            return new SemanticTextColors()
            {
                BodyText = palette.NeutralPrimary,
                BodyTextChecked = palette.Black,
                BodySubtext = palette.NeutralSecondary,
                DisabledBodyText = palette.NeutralTertiary,
                DisabledBodySubtext = palette.NeutralTertiaryAlt,

                // LINKS
                ActionLink = palette.NeutralPrimary,
                ActionLinkHovered = palette.NeutralDark,
                Link = palette.ThemePrimary,
                LinkHovered = palette.ThemeDarker,

                // BUTTONS
                ButtonText = palette.NeutralPrimary,
                ButtonTextHovered = palette.NeutralDark,
                ButtonTextChecked = palette.NeutralDark,
                ButtonTextCheckedHovered = palette.Black,
                ButtonTextPressed = palette.NeutralDark,
                ButtonTextDisabled = palette.NeutralTertiary,

                PrimaryButtonText = palette.White,
                PrimaryButtonTextHovered = palette.White,
                PrimaryButtonTextPressed = palette.White,
                PrimaryButtonTextDisabled = palette.NeutralQuaternary,

                AccentButtonText = palette.White,

                // INPUTS
                InputText = palette.NeutralPrimary,
                InputTextHovered = palette.NeutralDark,
                InputPlaceholderText = palette.NeutralSecondary,
                DisabledText = palette.NeutralTertiary,
                DisabledSubtext = palette.NeutralQuaternary,

                // LISTS
                ListText = palette.NeutralPrimary,
                
                // MENUS
                MenuItemText = palette.NeutralPrimary,
                MenuItemTextHovered = palette.NeutralDark,

                ErrorText = !isInverted ? palette.RedDark : "#ff5f5f",
                WarningText = !isInverted ? "#333333" : "#ffffff",
                SuccessText = !isInverted ? "#107C10" : "#92c353"
            };
        }
    }
}