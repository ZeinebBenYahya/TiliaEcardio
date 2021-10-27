using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MahApps.Metro.Controls.Dialogs;
using MaterialDesignThemes.Wpf;
using Presentation.Components.Dashboard;
using Presentation.Components.MedicalMeetings;
using Presentation.Components.Patients;
using Presentation.Utils;
using Presentation.Windows;

namespace Presentation.Components.Atomic
{
    public partial class SidebarUserControl
    {
        private readonly MainWindow _mainWindow;

        public SidebarUserControl(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleButtonColor(sender, DashboardTextBlock, DashboardIcon);
            _mainWindow.ChangeMainContentArea(new DashboardUserControl());
        }

        private void MedicalAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleButtonColor(sender, MedicalAppointmentTextBlock, MedicalAppointmentIcon);
            _mainWindow.ChangeMainContentArea(new QueryMedicalAppointmentUserControl(_mainWindow));
        }

        private async void MedicalMeetingButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleButtonColor(sender, MedicalMeetingTextBlock, MedicalMeetingIcon);
            _mainWindow.ChangeMainContentArea(new PatientMedicalBackgroundUserControl());
        }

        private async void ClinicalHistoriesButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleButtonColor(sender, ClinicalHistoriesTextBlock, ClinicalHistoriesIcon);
            await _mainWindow.ShowMessageAsync("Tilia", "Clinical histories");
        }

        private async void MedicalNotesButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleButtonColor(sender, MedicalNotesTextBlock, MedicalNotesIcon);
            await _mainWindow.ShowMessageAsync("Tilia", "MedicalNotes");
        }

        private async void AdminButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleButtonColor(sender, AdminTextBlock, AdminIcon);
            await _mainWindow.ShowMessageAsync("Tilia", "Configuration");
        }

        private async void MedicalOrdersButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleButtonColor(sender, MedicalOrdersTextBlock, MedicalOrdersIcon);
            await _mainWindow.ShowMessageAsync("Tilia", "MedicalOrders");
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleButtonColor(sender, LogoutTextBlock, LogoutIcon);
            _mainWindow.LogoutSession();
        }

        private void ToggleButtonColor(object sender, TextBlock textBlock, Control icon)
        {
            ChangeToDefaultColor(ButtonStack);
            ChangeSelectedButtonColor((Button)sender, textBlock, icon);
        }

        private void ChangeToDefaultColor(Panel stackPanel)
        {
            SelectionUtil.RestorePanelButtonsBackground(stackPanel, Brushes.White);
            SelectionUtil.RestoreElementsForeground(GetToolBarIcons(), ColorPalette.Gray);
            SelectionUtil.RestoreElementsForeground(GetToolBarTextBlocks(), ColorPalette.Gray);
        }

        private IEnumerable<TextBlock> GetToolBarTextBlocks()
        {
            return new[]
            {
                DashboardTextBlock, MedicalAppointmentTextBlock,
                ClinicalHistoriesTextBlock, MedicalNotesTextBlock, AdminTextBlock,
                MedicalMeetingTextBlock,
                MedicalOrdersTextBlock, LogoutTextBlock
            };
        }

        private IEnumerable<PackIcon> GetToolBarIcons()
        {
            return new[]
            {
                DashboardIcon, MedicalAppointmentIcon,
                ClinicalHistoriesIcon, MedicalNotesIcon, MedicalMeetingIcon, AdminIcon,
                MedicalOrdersIcon, LogoutIcon
            };
        }

        private static void ChangeSelectedButtonColor(Control selectedButton,
            TextBlock textBlock, Control icon)
        {
            ShadowAssist.SetShadowDepth(selectedButton, ShadowDepth.Depth1);
            selectedButton.Background = ColorPalette.PrimaryColor;
            textBlock.Foreground      = Brushes.White;
            icon.Foreground           = Brushes.White;
        }
    }
}
